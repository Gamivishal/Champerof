using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.InvoiceItemRepository
{
    public interface IInvoiceItemRepository
    {
        Task<PagedResult<InvoiceItems>> GetAll(int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdate(InvoiceItems model);

        Task<InvoiceItems?> GetById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> Delete(long id);
    }
}
