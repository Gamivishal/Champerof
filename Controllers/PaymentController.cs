using Champerof.Infra;
using Champerof.Models;
using Champerof.ServiceRepository.PaymentRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;

        public PaymentController(IPaymentRepository repository, ValidationService validation)
        {
            _repository = repository;
            _validation = validation;
        }

        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            var data = await _repository.GetAllPayments(start, length, sortColumn, sortColumnDir, searchValue);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Add(Payments model)
        {
            if (model.ClientId == null || model.ClientId <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Client is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.InvoiceId == null || model.InvoiceId <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Invoice is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.PaymentDate == null)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Payment date is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            else if (model.PaymentDate.Value.Date > DateTime.Today)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Payment date cannot be in the future";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.Amount == null || model.Amount <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Amount is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (string.IsNullOrWhiteSpace(model.PaymentMode))
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Payment mode is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            var (IsSuccess, Message, Id, Extra) = await _repository.AddOrUpdatePayment(model);

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
            var data = await _repository.GetPaymentById(id);

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
                CommonViewModel.Message = "Record not found";
            }

            return Ok(CommonViewModel);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> Delete(long id)
        {
            var (IsSuccess, Message, Id, Extra) = await _repository.DeletePayment(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }
    }
}
