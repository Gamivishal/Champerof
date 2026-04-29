using Champerof.Infra;
using Champerof.Models;
using Champerof.ServiceRepository.PaymentFollowUpRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentFollowUpController : ControllerBase
    {
        private readonly IPaymentFollowUpRepository _repository;
        private readonly CommonViewModel CommonViewModel = new();

        public PaymentFollowUpController(IPaymentFollowUpRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll(
            int start = 0,
            int length = 10,
            string sortColumn = "",
            string sortColumnDir = "asc",
            string searchValue = "",
            long invoiceId = 0)
        {
            var data = await _repository.GetAll(start, length, sortColumn, sortColumnDir, searchValue, invoiceId);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _repository.GetById(id);

            if (data != null)
            {
                CommonViewModel.IsSuccess = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Data = data;
            }
            else
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Record not found";
                CommonViewModel.StatusCode = ResponseStatusCode.NotFound;
            }

            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Add(PaymentFollowUp model)
        {
            var now = DateTime.Now;
            if (model.InvoiceId == null || model.InvoiceId <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Invoice is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            //if (model.DueDate == null)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Due Date is required";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}
            //if (model.DueDate <= now)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Due Date must be a future date";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            if (model.NextFollowUpDate == null)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Next FollowUp Date is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            if (model.NextFollowUpDate <= now)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Next FollowUp Date must be a future date";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            //if (model.NextFollowUpDate >= model.DueDate)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Next FollowUp Date must be earlier than Due Date";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            if (string.IsNullOrWhiteSpace(model.Remark))
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Remark is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }

            var (IsSuccess, Message, Id, Extra) = await _repository.AddOrUpdate(model);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;
            CommonViewModel.Data = Id;

            return Ok(CommonViewModel);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> Delete(long id)
        {
            var (IsSuccess, Message, Id, Extra) = await _repository.Delete(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll2(
      int start = 0,
      int length = 10,
      string sortColumn = "",
      string sortColumnDir = "asc",
      string searchValue = "",
      long invoiceId = 0)
        {
            var data = await _repository.GetAllpending(start, length, sortColumn, sortColumnDir, searchValue, invoiceId);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById2(long id)
        {
            var data = await _repository.GetByIdpending(id);

            if (data != null)
            {
                CommonViewModel.IsSuccess = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Data = data;
            }
            else
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Record not found";
                CommonViewModel.StatusCode = ResponseStatusCode.NotFound;
            }

            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Add2(PaymentFollowUp model)
        {
            var now = DateTime.Now;
            if (model.InvoiceId == null || model.InvoiceId <= 0)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Invoice is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            //if (model.DueDate == null)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Due Date is required";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}
            //if (model.DueDate <= now)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Due Date must be a future date";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            if (model.NextFollowUpDate == null)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Next FollowUp Date is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            if (model.NextFollowUpDate <= now)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Next FollowUp Date must be a future date";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }  

            //if (model.NextFollowUpDate >= model.DueDate)
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Next FollowUp Date must be earlier than Due Date";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            if (string.IsNullOrWhiteSpace(model.Remark))
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.Message = "Remark is required";
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                return Ok(CommonViewModel);
            }
            //if (string.IsNullOrWhiteSpace(model.Status))
            //{
            //    CommonViewModel.IsSuccess = false;
            //    CommonViewModel.Message = "Status is required";
            //    CommonViewModel.StatusCode = ResponseStatusCode.Error;
            //    return Ok(CommonViewModel);
            //}

            var (IsSuccess, Message, Id, Extra) = await _repository.AddOrUpdatePending(model);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;
            CommonViewModel.Data = Id;

            return Ok(CommonViewModel);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> Delete2(long id)
        {
            var (IsSuccess, Message, Id, Extra) = await _repository.DeletePending(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllPaymentHistory(
int start = 0,
int length = 10,
string sortColumn = "",
string sortColumnDir = "asc",
string searchValue = "",
long FollowupId = 0)
        {
            var data = await _repository.GetAllHistory(start, length, sortColumn, sortColumnDir, searchValue, FollowupId);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }
    }
}
