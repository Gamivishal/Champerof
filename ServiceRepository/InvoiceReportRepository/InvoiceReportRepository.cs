using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.InvoiceReportRepository
{
    public interface IInvoiceReportRepository
    {
        Task<PagedResult<Invoices>> InvoiceReport(int start, int length, string sortColumn, string sortColumnDir, string searchValue,
               DateTime? fromDate,
    DateTime? toDate,
    long? clientId,
    string? invoiceType,
    string? statuse);
    }
    public class InvoiceReportRepository : IInvoiceReportRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<Invoices> _repositoryBase;
        private readonly IRepositoryBase<InvoiceFullDto> _repositoryBaseinvoive;

        public InvoiceReportRepository(DataContext context, IRepositoryBase<Invoices> repositoryBase, IRepositoryBase<InvoiceFullDto> repositoryBaseinvoive)
        {
            _context = context;
            _repositoryBase = repositoryBase;
            _repositoryBaseinvoive = repositoryBaseinvoive;
        }


        public async Task<PagedResult<Invoices>> InvoiceReport(
     int start,
     int length,
     string sortColumn,
     string sortColumnDir,
     string searchValue, DateTime? fromDate,
    DateTime? toDate,
    long? clientId,
    string? invoiceType,
    string? status)
        {
            //SqlParameter[] parameters = null;
            SqlParameter[] parameters = new SqlParameter[]
{
        new SqlParameter("@ClientId", (object?)clientId ?? DBNull.Value),
        new SqlParameter("@InvoiceType", (object?)invoiceType ?? DBNull.Value),
        new SqlParameter("@FromDate", (object?)fromDate ?? DBNull.Value),
        new SqlParameter("@ToDate", (object?)toDate ?? DBNull.Value),
        new SqlParameter("@Status", (object?)status ?? DBNull.Value)
};

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_Invoice_Report",
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
