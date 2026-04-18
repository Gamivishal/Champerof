using Champerof.Infra;
using Champerof.Models;
using Champerof.ServiceRepository.CompanyRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyMasterController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;

        public CompanyMasterController(ICompanyRepository companyRepository, ValidationService validation)
        {
            _companyRepository = companyRepository;
            _validation = validation;
        }

        //-----------------------------------------
        // GET ALL (PAGINATION)
        //-----------------------------------------
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllpage(
            int start = 0,
            int length = 10,
            string sortColumn = "",
            string sortColumnDir = "asc",
            string searchValue = "")
        {
            var data = await _companyRepository.GetAll(start, length, sortColumn, sortColumnDir, searchValue);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        //-----------------------------------------
        // ADD / UPDATE
        //-----------------------------------------
        [HttpPost("[Action]")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add(
            [FromForm] CompanyMasterFormDto dto,
            IFormFile? file = null)
        {
            try
            {
                var res = _validation.ValidateRequired(dto.AccountNo, "Account No");
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateRequired(dto.AccountName, "Account Name");
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateRequired(dto.Bank, "Bank");
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateRequired(dto.IFSCCode, "IFSC Code");
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateRequired(dto.PAN, "PAN");
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateMobile(dto.Mobile);
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateEmail(dto.Email);
                if (!res.IsSuccess) return Ok(res);

                res = _validation.ValidateRequired(dto.Address, "Address");
                if (!res.IsSuccess) return Ok(res);
              
                byte[]? fileBytes = null;
                string? fileName = null;
                string? contentType = null;

                //-----------------------------------------
                // FILE HANDLING
                //-----------------------------------------
                if (file == null || file.Length == 0)
                {
                    CommonViewModel.IsSuccess = false;
                    CommonViewModel.StatusCode = ResponseStatusCode.Error;
                    CommonViewModel.Message = "Please Select Photo";
                    return Ok(CommonViewModel);
                }
                if (file != null && file.Length > 0)
                {
                    if (!AppHttpContextAccessor.IsValidFileExtension(file.FileName))
                    {
                        CommonViewModel.IsConfirm = false;
                        CommonViewModel.IsSuccess = false;
                        CommonViewModel.StatusCode = ResponseStatusCode.Error;
                        CommonViewModel.Message = "Only .jpg, .jpeg and .png files are allowed.";
                        return Ok(CommonViewModel);
                    }

                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);

                    fileBytes = ms.ToArray();
                    fileName = file.FileName;
                    contentType = file.ContentType;
                }
              
               
                //-----------------------------------------
                // MAP TO ENTITY
                //-----------------------------------------
                var model = new CompanyMaster
                {
                    Id = dto.Id,
                    AccountNo = dto.AccountNo,
                    AccountName = dto.AccountName,
                    Bank = dto.Bank,
                    IFSCCode = dto.IFSCCode,
                    PAN = dto.PAN,

                    Mobile = dto.Mobile,
                    Email = dto.Email,
                    Address = dto.Address,

                    SignFileName = fileName,
                    SignContentType = contentType,
                    SignData = fileBytes
                };

                //-----------------------------------------
                // SAVE
                //-----------------------------------------
                var result = await _companyRepository.AddOrUpdate(model);

                CommonViewModel.IsSuccess = true;
                CommonViewModel.IsConfirm = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Message = result.Message;
                CommonViewModel.Data = result.Id;

                return Ok(CommonViewModel);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        //-----------------------------------------
        // GET BY ID
        //-----------------------------------------
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _companyRepository.GetById(id);

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

        //-----------------------------------------
        // DELETE
        //-----------------------------------------
        [HttpDelete("[Action]")]
        public async Task<IActionResult> Delete(long id)
        {
            var (IsSuccess, Message, Id, Extra) = await _companyRepository.Delete(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }
    }
}