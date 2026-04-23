using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.PaymentRepository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<Payments> _repositoryBase;

        public PaymentRepository(DataContext context, IRepositoryBase<Payments> repositoryBase)
        {
            _context = context;
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<Payments>> GetAllPayments(
            int start,
            int length,
            string sortColumn,
            string sortColumnDir,
            string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_Payment_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdatePayment(Payments model)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@PaymentId", model.PaymentId),
                new SqlParameter("@ClientId", model.ClientId ?? (object)DBNull.Value),
                new SqlParameter("@IS_Advance", model.IS_Advance ?? (object)DBNull.Value),
                new SqlParameter("@InvoiceId", model.InvoiceId ?? (object)DBNull.Value),
                new SqlParameter("@PaymentDate", model.PaymentDate ?? (object)DBNull.Value),
                new SqlParameter("@Amount", model.Amount ?? (object)DBNull.Value),
                new SqlParameter("@AdvanvePayment", model.AdvancePayment ??(object) DBNull.Value),
                new SqlParameter("@PaymentMode", model.PaymentMode ?? (object)DBNull.Value),
                new SqlParameter("@ReferenceNo", model.ReferenceNo ?? (object)DBNull.Value),
                new SqlParameter("@Notes", model.Notes ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Advance_ID", model.Advance_ID ?? (object)DBNull.Value),
                new SqlParameter("@Action", model.PaymentId == 0 ? "INSERT" : "UPDATE"),
                new SqlParameter("@Flage", model.IS_Advance == true ? true : false)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Payment_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<Payments?> GetPaymentById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@PaymentId", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_Payment_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeletePayment(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@PaymentId", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Payment_Delete", parameters, true);

            return await Task.FromResult(result);
        }


        public async Task<PagedResult<Payments>> AdvancePaymentHistory(
    int start,
    int length,
    string sortColumn,
    string sortColumnDir,
    string searchValue, long AdvancePaymentId)
        {
            //  SqlParameter[] parameters = null;
            SqlParameter[] parameters = new SqlParameter[]
      {
        new SqlParameter("@AdvanceId", AdvancePaymentId)
      };

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_PaymentHistoryByAdvanceID_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }
    }
}
