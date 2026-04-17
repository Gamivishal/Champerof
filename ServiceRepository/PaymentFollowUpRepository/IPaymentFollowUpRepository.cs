using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.PaymentFollowUpRepository
{
    public interface IPaymentFollowUpRepository
    {
        Task<PagedResult<PaymentFollowUp>> GetAll(
    int start,
    int length,
    string sortColumn,
    string sortColumnDir,
    string searchValue,
    long invoiceId);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdate(PaymentFollowUp model);

        Task<PaymentFollowUp?> GetById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> Delete(long id);
    }
}
