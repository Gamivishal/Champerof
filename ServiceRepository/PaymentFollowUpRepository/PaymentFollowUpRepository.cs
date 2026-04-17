using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.PaymentFollowUpRepository
{
    public class PaymentFollowUpRepository : IPaymentFollowUpRepository
    {
        private readonly IRepositoryBase<PaymentFollowUp> _repositoryBase;

        public PaymentFollowUpRepository(IRepositoryBase<PaymentFollowUp> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<PaymentFollowUp>> GetAll(
         int start,
         int length,
         string sortColumn,
         string sortColumnDir,
         string searchValue,
         long invoiceId)
        {
            SqlParameter[] parameters = new[]
            {
        new SqlParameter("@Id", DBNull.Value),
        new SqlParameter("@InvoiceId", invoiceId)
    };

            var result = _repositoryBase.ExecuteWithPagination(
                "SP_PaymentFollowUp_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<PaymentFollowUp?> GetById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@InvoiceId", DBNull.Value)
            };

            var result = _repositoryBase.ExecuteSingle("SP_PaymentFollowUp_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdate(PaymentFollowUp model)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@InvoiceId", model.InvoiceId ?? (object)DBNull.Value),
                new SqlParameter("@DueDate", model.DueDate ?? (object)DBNull.Value),
                new SqlParameter("@FollowUpDate", model.FollowUpDate ?? (object)DBNull.Value),
                new SqlParameter("@NextFollowUpDate", model.NextFollowUpDate ?? (object)DBNull.Value),
                new SqlParameter("@Status", model.Status ?? (object)DBNull.Value),
                new SqlParameter("@Remark", model.Remark ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", model.Id == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("SP_PaymentFollowUp_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> Delete(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("SP_PaymentFollowUp_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}
