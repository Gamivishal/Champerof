using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.PaymentRepository
{
    public interface IPaymentRepository
    {
        Task<PagedResult<Payments>> GetAllPayments(int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdatePayment(Payments model);

        Task<Payments?> GetPaymentById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeletePayment(long id);

        Task<PagedResult<Payments>> AdvancePaymentHistory(int start, int length, string sortColumn, string sortColumnDir, string searchValue,long AdvancePaymentId);
    }
}
