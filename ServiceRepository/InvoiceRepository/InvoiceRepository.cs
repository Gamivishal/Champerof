using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.InvoiceRepository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<Invoices> _repositoryBase;
        private readonly IRepositoryBase<InvoiceFullDto> _repositoryBaseinvoive;

        public InvoiceRepository(DataContext context, IRepositoryBase<Invoices> repositoryBase, IRepositoryBase<InvoiceFullDto> repositoryBaseinvoive)
        {
            _context = context;
            _repositoryBase = repositoryBase;
            _repositoryBaseinvoive = repositoryBaseinvoive;
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




        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateInvoiceCombo(InvoiceCombo model)
        {
            try

            {
                var itemsJson = Newtonsoft.Json.JsonConvert.SerializeObject(model.Items);

                List<SqlParameter> oParams = new()
    {
        new SqlParameter("@InvoiceId", model.Invoice.InvoiceId),
        new SqlParameter("@ClientId", model.Invoice.ClientId ?? (object)DBNull.Value),
        new SqlParameter("@InvoiceNumber", model.Invoice.InvoiceNumber ?? (object)DBNull.Value),
        new SqlParameter("@InvoiceDate", model.Invoice.InvoiceDate ?? (object)DBNull.Value),
        new SqlParameter("@DueDate", model.Invoice.DueDate ?? (object)DBNull.Value),
        new SqlParameter("@SubTotal", model.Invoice.SubTotal ?? (object)DBNull.Value),
        new SqlParameter("@Discount", model.Invoice.Discount ?? (object)DBNull.Value),
        new SqlParameter("@TaxAmount", model.Invoice.TaxAmount ?? (object)DBNull.Value),
        new SqlParameter("@FinalAmount", model.Invoice.FinalAmount ?? (object)DBNull.Value),
        new SqlParameter("@Status", model.Invoice.Status ?? (object)DBNull.Value),
        new SqlParameter("@InvoiceType", model.Invoice.InvoiceType ?? (object)DBNull.Value),
        new SqlParameter("@Notes", model.Invoice.Notes ?? (object)DBNull.Value),

        new SqlParameter("@Items", itemsJson),  // 🔥 JSON

        new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
        new SqlParameter("@Action", model.Invoice.InvoiceId == 0 ? "INSERT" : "UPDATE")
    };
                Console.WriteLine($"InvoiceId: {model.Invoice.InvoiceId}");
                var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Invoicesavecombo_Save", oParams, true);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InvoiceCombo?> GetInvoiceWithItems(long id)
        {
            List<SqlParameter> parameters = new()
    {
        new SqlParameter("@InvoiceId", id)
    };

            var ds = _repositoryBase.ExecuteStoredProcedureDataSet("sp_Invoice_Get", parameters);

            if (ds == null || ds.Tables.Count < 2)
                return null;

            // 🔹 Invoice (first table)
            var invoiceJson = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
            var invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Invoices>>(invoiceJson)?.FirstOrDefault();

            // 🔹 Items (second table)
            var itemsJson = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[1]);
            var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InvoiceItems>>(itemsJson);

            if (invoice == null) return null;

            return new InvoiceCombo
            {
                Invoice = invoice,
                Items = items ?? new List<InvoiceItems>()
            };
        }



        public async Task<PagedResult<Invoices>> Unpaid_Invoice(
    int start,
    int length,
    string sortColumn,
    string sortColumnDir,
    string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_Invoice_GetUnpaid",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }
   

    public async Task<InvoiceFullDto?> GetInvoicesLayoutdata(long id)
        {
            List<SqlParameter> parameters = new()
    {
        new SqlParameter("@InvoiceId", id)
    };

            var ds = _repositoryBase.ExecuteStoredProcedureDataSet("sp_InvoiceLayout_Get", parameters);

            if (ds == null || ds.Tables.Count < 2)
                return null;

            // 🔹 Invoice (first table)
            var invoiceJson = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
            var invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Invoices>>(invoiceJson)?.FirstOrDefault();

            // 🔹 Items (second table)
            var itemsJson = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[1]);
            var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InvoiceItems>>(itemsJson);

            var CompanyMasterJson = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[2]);
            var CompanyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CompanyMaster>>(CompanyMasterJson).FirstOrDefault();

            var TermsAndConditionsJson = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[3]);
            var TermsAndConditions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TermsAndConditions>>(TermsAndConditionsJson);

            if (invoice == null) return null;

            return new InvoiceFullDto
            {
                Invoice = invoice,
                Company = CompanyMaster,
                Terms = TermsAndConditions,
                Items = items ?? new List<InvoiceItems>()
            };
        }
    }
}