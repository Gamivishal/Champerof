using Champerof.Infra;
using Champerof.Models;
using Champerof.ServiceRepository.AdvancePaymentRepository;
using Champerof.ServiceRepository.PaymentRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancePaymentController : ControllerBase
    {
        private readonly IAdvancePaymentRepository _repository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;
        private readonly IPaymentRepository _payment;

        public AdvancePaymentController(IAdvancePaymentRepository repository, ValidationService validation,IPaymentRepository payment)
        {
            _repository = repository;
            _validation = validation;
            _payment = payment;
        }

        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            var data = await _repository.GetAllAdvancePayments(start, length, sortColumn, sortColumnDir, searchValue);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }


        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> AdvancePaymentHistory(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "", long AdvancePaymentId=0)
        {
            var data = await _payment.AdvancePaymentHistory(start, length, sortColumn, sortColumnDir, searchValue, AdvancePaymentId);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Add(AdvancePayment model)
            {

            if (model.ClientId == null || model.ClientId <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Client Name is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            if (model.TotalAmount == null || model.TotalAmount <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Total amount is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }


            var (IsSuccess, Message, Id, Extra) = await _repository.AddOrUpdateAdvancePayment(model);

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
            var data = await _repository.GetAdvancePaymentById(id);

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
            var (IsSuccess, Message, Id, Extra) = await _repository.DeleteAdvancePayment(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }
    }
}
