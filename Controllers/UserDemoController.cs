using CommonForReact.Infra;
using CommonForReact.Models;
using CommonForReact.ServiceRepository.UserDemoRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommonForReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDemoController : ControllerBase
    {
        private readonly IUserDemoRepository _repo;
        private readonly ValidationService _validation;
        private readonly CommonViewModel CommonViewModel = new();

        public UserDemoController(IUserDemoRepository repo, ValidationService validation)
        {
            _repo = repo;
            _validation = validation;
        }


        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            try
            {
                var data = await _repo.GetAllUserDemo(start, length, sortColumn, sortColumnDir, searchValue);
                CommonViewModel.IsSuccess = true;
                CommonViewModel.StatusCode = ResponseStatusCode.Success;
                CommonViewModel.Data = data;
            }
            catch (Exception ex)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                CommonViewModel.Message = ex.Message;

                string actionName = ControllerContext.RouteData.Values["action"]?.ToString();
                string controllerName = ControllerContext.RouteData.Values["controller"]?.ToString();
                string requestUrl = $"{Request?.Scheme}://{Request?.Host}{Request?.Path}{Request?.QueryString}";
                string userAgent = Request?.Headers["User-Agent"].ToString();
                string clientIp = HttpContext.Connection?.RemoteIpAddress?.ToString();
                string requestPayload = null;
                long? userId = AppHttpContextAccessor.JwtUserId;
                var log = new ErrorLog
                {
                    ApplicationName = AppHttpContextAccessor.ApplicationName,
                    ControllerName = controllerName + "_" + actionName,
                    ErrorMessage = ex.Message,
                    ErrorType = ex.GetType().FullName,
                    StackTrace = ex.ToString(),
                    RequestUrl = requestUrl,
                    RequestPayload = requestPayload,
                    UserAgent = userAgent,
                    UserId = userId,
                    ClientIP = clientIp,

                    CreatedBy = User?.Identity?.Name
                };

                LogEntry.InsertLogEntry(log);

            }
            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add(
            [FromForm] UserDemoFormDto dto,
            IFormFile? attachment = null)
        {
            try
            {
                byte[]? fileBytes = null;
                string? fileName = null;
                string? contentType = null;
                long? fileSize = null;

                if (attachment != null && attachment.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await attachment.CopyToAsync(ms);

                    fileBytes = ms.ToArray();
                    fileName = attachment.FileName;
                    contentType = attachment.ContentType;
                    fileSize = attachment.Length;
                }

                var model = new UserDemo
                {
                    Id = dto.UserId,
                    UserName = dto.UserName,
                    Password = dto.Password,
                    Email = dto.Email,
                    MobileNumber = dto.MobileNumber,

                    FileName = fileName,
                    ContentType = contentType,
                    FileSize = fileSize,
                    FileData = fileBytes
                };

                var result = await _repo.AddOrUpdateUserDemo(model);

                CommonViewModel.IsSuccess = result.IsSuccess;
                CommonViewModel.StatusCode = result.IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
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



        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var data = await _repo.GetUserDemoById(id);
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
                    CommonViewModel.Message = ResponseStatusMessage.NotFound;
                }
            }
            catch (Exception ex)
            {
                CommonViewModel.IsSuccess = false;
                CommonViewModel.StatusCode = ResponseStatusCode.Error;
                CommonViewModel.Message = ex.Message;

                string actionName = ControllerContext.RouteData.Values["action"]?.ToString();
                string controllerName = ControllerContext.RouteData.Values["controller"]?.ToString();
                string requestUrl = $"{Request?.Scheme}://{Request?.Host}{Request?.Path}{Request?.QueryString}";
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
                string clientIp = HttpContext.Connection?.RemoteIpAddress?.ToString();
                string requestPayload = System.Text.Json.JsonSerializer.Serialize(new { id });
                long? userId = AppHttpContextAccessor.JwtUserId;
                var log = new ErrorLog
                {
                    ApplicationName = AppHttpContextAccessor.ApplicationName,
                    ControllerName = controllerName + "_" + actionName,
                    ErrorMessage = ex.Message,
                    ErrorType = ex.GetType().FullName,
                    StackTrace = ex.ToString(),
                    RequestUrl = requestUrl,
                    RequestPayload = requestPayload,
                    UserAgent = userAgent,
                    UserId = userId,
                    ClientIP = clientIp,

                    CreatedBy = User?.Identity?.Name
                };

                LogEntry.InsertLogEntry(log);
                return null;

            }
            return Ok(CommonViewModel);
        }
    }
}