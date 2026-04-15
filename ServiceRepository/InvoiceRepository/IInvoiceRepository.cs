using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.InvoiceRepository
{
    public interface IInvoiceRepository
    {
        Task<PagedResult<Invoices>> GetAllInvoices(int start, int length, string sortColumn, string sortColumnDir, string searchValue);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateInvoice(Invoices invoice);
        Task<Invoices?> GetInvoiceById(long id);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteInvoice(long id);
    }
}
