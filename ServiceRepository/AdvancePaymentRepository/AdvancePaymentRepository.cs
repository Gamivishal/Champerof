using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.AdvancePaymentRepository
{
    public class AdvancePaymentRepository : IAdvancePaymentRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<AdvancePayment> _repositoryBase;

        public AdvancePaymentRepository(DataContext context, IRepositoryBase<AdvancePayment> repositoryBase)
        {
            _context = context;
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<AdvancePayment>> GetAllAdvancePayments(
            int start,
            int length,
            string sortColumn,
            string sortColumnDir,
            string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_AdvancePayment_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateAdvancePayment(AdvancePayment model)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@ClientId", model.ClientId ?? (object)DBNull.Value),
                new SqlParameter("@TotalAmount", model.TotalAmount ?? (object)DBNull.Value),
                new SqlParameter("@RemainingAmount", model.RemainingAmount ?? (object)DBNull.Value),
                new SqlParameter("@Status", model.Status ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", model.Id == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_AdvancePayment_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<AdvancePayment?> GetAdvancePaymentById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_AdvancePayment_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteAdvancePayment(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_AdvancePayment_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}