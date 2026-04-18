using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Champerof.ServiceRepository.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IRepositoryBase<CompanyMaster> _repositoryBase;

        public CompanyRepository(IRepositoryBase<CompanyMaster> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<CompanyMaster>> GetAll(int start, int length, string sortColumn, string sortColumnDir, string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_CompanyMaster_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdate(CompanyMaster company)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@Id", company.Id),
                new SqlParameter("@AccountNo", company.AccountNo ?? (object)DBNull.Value),
                new SqlParameter("@AccountName", company.AccountName ?? (object)DBNull.Value),
                new SqlParameter("@Bank", company.Bank ?? (object)DBNull.Value),
                new SqlParameter("@IFSCCode", company.IFSCCode ?? (object)DBNull.Value),
                new SqlParameter("@PAN", company.PAN ?? (object)DBNull.Value),

                new SqlParameter("@SignFileName", company.SignFileName ?? (object)DBNull.Value),
                new SqlParameter("@SignContentType", company.SignContentType ?? (object)DBNull.Value),

                new SqlParameter("@SignData", SqlDbType.VarBinary) {Value = company.SignData ?? (object)DBNull.Value},

                new SqlParameter("@Mobile", company.Mobile ?? (object)DBNull.Value),
                new SqlParameter("@Email", company.Email ?? (object)DBNull.Value),
                new SqlParameter("@Address", company.Address ?? (object)DBNull.Value),

                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", company.Id == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_CompanyMaster_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<CompanyMaster?> GetById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_CompanyMaster_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> Delete(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_CompanyMaster_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}