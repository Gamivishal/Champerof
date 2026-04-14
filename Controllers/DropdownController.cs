using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CommonForReact.Infra;
using CommonForReact.Models;

namespace CommonForReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DropdownController : ControllerBase
    {
        private readonly IRepositoryBase<Dropdownname> _repositoryBase;
        private readonly IRepositoryBase<Lov_Master> _Base;
        private readonly CommonViewModel CommonViewModel = new();

        public DropdownController(IRepositoryBase<Dropdownname> repositoryBase, IRepositoryBase<Lov_Master> Base)
        {
            _repositoryBase = repositoryBase;
            _Base = Base;
        }

        [HttpGet("[Action]")]
        public IActionResult LovMaster(string Lov_column)
        {
            try
            {

                var parameters1 = new[]
                {
                   new SqlParameter("@LOV_Column", Lov_column)
                };

                var data = _Base.ExecuteForDropdown("Sp_Love_Combo", parameters1);

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
                string clientIp = HttpContext.Connection?.RemoteIpAddress?.ToString();
                string requestPayload = System.Text.Json.JsonSerializer.Serialize(new { Lov_column });
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

        [HttpGet("[Action]")]
        public IActionResult UserName()
        {
            try
            {

                var data = _repositoryBase.ExecuteForDropdown("SP_GetusersList");

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
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

        [HttpGet("[Action]")]
        public IActionResult RoleName()
        {
            try
            {

                var data = _repositoryBase.ExecuteForDropdown("SP_GetRoleList");

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
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

        [HttpGet("[Action]")]
        public IActionResult MenuList()
        {
            try
            {
                // only child name get
                var data = _repositoryBase.ExecuteForDropdown("SP_GetMenuList");

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
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

        [HttpGet("[Action]")]
        public IActionResult CountryName()
        {
            try
            {

                var data = _repositoryBase.ExecuteForDropdown("Sp_CountryNameList_Get");

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
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
        [HttpGet("[Action]")]
        // this is pendng
        public IActionResult CityNameList(long? RegionId)
        {

            try
            {

                var parameters = new[]
                {
                    new SqlParameter("@RegionId", RegionId)
                };

                var data = _repositoryBase.ExecuteForDropdown("Sp_CityNameList_ByRegion_Get", parameters);

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
                string clientIp = HttpContext.Connection?.RemoteIpAddress?.ToString();
                string requestPayload = System.Text.Json.JsonSerializer.Serialize(new { RegionId });
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
        [HttpGet("[Action]")]
        // this is pendng Or state
        public IActionResult RegionNameList(long? CountryId)
        {

            try
            {

                var parameters1 = new[]
                {
                    new SqlParameter("@CountryId", CountryId)
                };

                var data = _repositoryBase.ExecuteForDropdown("Sp_RegionNameList_ByCountry_Get", parameters1);

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
                string userAgent = Request?.Headers["User-Agent"].ToString(); //broser name and servion
                string clientIp = HttpContext.Connection?.RemoteIpAddress?.ToString();
                string requestPayload = System.Text.Json.JsonSerializer.Serialize(new { CountryId });
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

    }
}
