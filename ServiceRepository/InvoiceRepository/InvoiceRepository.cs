using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.InvoiceRepository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<Invoices> _repositoryBase;

        public InvoiceRepository(DataContext context, IRepositoryBase<Invoices> repositoryBase)
        {
            _context = context;
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<Invoices>> GetAllInvoices(
            int start,
            int length,
            string sortColumn,
            string sortColumnDir,
            string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_Invoice_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateInvoice(Invoices invoice)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@InvoiceId", invoice.InvoiceId),
                new SqlParameter("@ClientId", invoice.ClientId ?? (object)DBNull.Value),
                new SqlParameter("@InvoiceNumber", invoice.InvoiceNumber ?? (object)DBNull.Value),
                new SqlParameter("@InvoiceDate", invoice.InvoiceDate ?? (object)DBNull.Value),
                new SqlParameter("@DueDate", invoice.DueDate ?? (object)DBNull.Value),
                new SqlParameter("@SubTotal", invoice.SubTotal ?? (object)DBNull.Value),
                new SqlParameter("@Discount", invoice.Discount ?? (object)DBNull.Value),
                new SqlParameter("@TaxAmount", invoice.TaxAmount ?? (object)DBNull.Value),
                new SqlParameter("@FinalAmount", invoice.FinalAmount ?? (object)DBNull.Value),
                new SqlParameter("@Status", invoice.Status ?? (object)DBNull.Value),
                new SqlParameter("@Notes", invoice.Notes ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", invoice.InvoiceId == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Invoice_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<Invoices?> GetInvoiceById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceId", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_Invoice_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteInvoice(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@InvoiceId", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Invoice_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}