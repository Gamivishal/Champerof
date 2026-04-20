using Champerof.Infra;
using Champerof.Models;
using Champerof.ServiceRepository.InvoiceRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;

        public InvoiceController(IInvoiceRepository invoiceRepository, ValidationService validation)
        {
            _invoiceRepository = invoiceRepository;
            _validation = validation;
        }

        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            var data = await _invoiceRepository.GetAllInvoices(start, length, sortColumn, sortColumnDir, searchValue);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Add(Invoices invoice)
        {
            //var validation = _validation.ValidateRequired(invoice.ClientId, "Client");
            //if (!validation.IsSuccess) return Ok(validation);

            var validation2 = _validation.ValidateRequired(invoice.InvoiceNumber, "Invoice Number");
            if (!validation2.IsSuccess) return Ok(validation2);

            var (IsSuccess, Message, Id, Extra) = await _invoiceRepository.AddOrUpdateInvoice(invoice);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;
            CommonViewModel.Data = Id;

            return Ok(CommonViewModel);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _invoiceRepository.GetInvoiceById(id);

            if (data != null)
            {
                CommonViewModel.IsSuccess = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Data = data;
            }
            else
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.StatusCode = ResponseStatusCode.NotFound;
                CommonViewModel.Message = "Invoice not found";
            }

            return Ok(CommonViewModel);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> Delete(long id)
        {
            var (IsSuccess, Message, Id, Extra) = await _invoiceRepository.DeleteInvoice(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }


        [HttpPost("SaveWithItems")]
        public async Task<IActionResult> SaveWithItems(InvoiceCombo model)
        {


            //if (model.Items == null || model.Items.Count == 0)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "At least one item is required";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            //if (model.Invoice == null)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Invoice data is required";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            if (model.Invoice.ClientId == null || model.Invoice.ClientId <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Client is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (string.IsNullOrWhiteSpace(model.Invoice.InvoiceNumber))
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Invoice number is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.Invoice.InvoiceDate == null)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Invoice date is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            else if (model.Invoice.InvoiceDate > DateTime.Now)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Invoice date must be in the past";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.Invoice.DueDate == null)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Due date is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            else if (model.Invoice.DueDate <= DateTime.Now)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Due date must be in the future";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.Invoice.SubTotal == null || model.Invoice.SubTotal < 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Subtotal must be valid";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.Invoice.Discount == null || model.Invoice.Discount < 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Discount must be valid";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            //if (model.Invoice.TaxAmount == null || model.Invoice.TaxAmount < 0)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Tax amount must be valid";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            if (model.Invoice.FinalAmount == null || model.Invoice.FinalAmount < 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Final amount must be valid";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (string.IsNullOrWhiteSpace(model.Invoice.Status))
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Status is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            var (IsSuccess, Message, Id, Extra) = await _invoiceRepository.AddOrUpdateInvoiceCombo(model);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;
            CommonViewModel.Data = Id;

            return Ok(CommonViewModel);
        }

        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById2(long id)
        {
            var data = await _invoiceRepository.GetInvoiceWithItems(id);

            if (data != null)
            {
                CommonViewModel.IsSuccess = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Data = data;
            }
            else
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.StatusCode = ResponseStatusCode.NotFound;
                CommonViewModel.Message = "Invoice not found";
            }

            return Ok(CommonViewModel);
        }


        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> PendingPayment(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            var data = await _invoiceRepository.Unpaid_Invoice(start, length, sortColumn, sortColumnDir, searchValue);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }


        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInvoicesLayoutdata(long id)
        {
            var data = await _invoiceRepository.GetInvoicesLayoutdata(id);

            if (data != null)
            {
                CommonViewModel.IsSuccess = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Data = data;
            }
            else
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.StatusCode = ResponseStatusCode.NotFound;
                CommonViewModel.Message = "Invoice not found";
            }

            return Ok(CommonViewModel);
        }


    }
}
