using Champerof.Infra;
using Champerof.ServiceRepository.InvoiceReportRepository;
using Champerof.ServiceRepository.InvoiceRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceReportController : ControllerBase
    {
        private readonly IInvoiceReportRepository _invoiceRepository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;

        public InvoiceReportController(IInvoiceReportRepository invoiceRepository, ValidationService validation)
        {
            _invoiceRepository = invoiceRepository;
            _validation = validation;
        }

        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "", DateTime? fromDate = null,
    DateTime? toDate = null,
    long? clientId = null,
    string? invoiceType = null,
    string? status = null)
        {
            var data = await _invoiceRepository.InvoiceReport(start, length, sortColumn, sortColumnDir, searchValue, fromDate,
        toDate,
        clientId,
        invoiceType,
        status);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }


    }
}
