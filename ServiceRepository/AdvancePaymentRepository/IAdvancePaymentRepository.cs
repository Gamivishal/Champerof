using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.AdvancePaymentRepository
{
    public interface IAdvancePaymentRepository
    {
        Task<PagedResult<AdvancePayment>> GetAllAdvancePayments(int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateAdvancePayment(AdvancePayment model);

        Task<AdvancePayment?> GetAdvancePaymentById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteAdvancePayment(long id);


    }
}
