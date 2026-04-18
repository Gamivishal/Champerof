using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.TermsRepository
{
    public class TermsRepository :ITermsRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<TermsAndConditions> _repositoryBase;

        public TermsRepository(DataContext context, IRepositoryBase<TermsAndConditions> repositoryBase)
        {
            _context = context;
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<TermsAndConditions>> GetAllTerms(
            int start,
            int length,
            string sortColumn,
            string sortColumnDir,
            string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_TermsAndConditions_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateTerms(TermsAndConditions terms)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@Id", terms.Id),
                new SqlParameter("@Terms", terms.Terms ?? (object)DBNull.Value),
                new SqlParameter("@DisplaySeqNo", terms.DisplaySeqNo ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", terms.Id == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_TermsAndConditions_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<TermsAndConditions?> GetTermsById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_TermsAndConditions_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteTerms(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_TermsAndConditions_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}
