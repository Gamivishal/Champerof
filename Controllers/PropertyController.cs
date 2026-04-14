using CommonForReact.Infra;
using CommonForReact.Models;
using CommonForReact.ServiceRepository.PropertyRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommonForReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly CommonViewModel CommonViewModel = new();

        public PropertyController(IPropertyRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            try
            {
                var data = await _repo.GetAllProperty(start, length, sortColumn, sortColumnDir, searchValue);
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


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var data = await _repo.GetPropertyById(id);
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


        [HttpPost("Update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProperty(
      [FromForm] int propertyId,
      [FromForm] string title,
      [FromForm] string? description,
      [FromForm] decimal? price,
      [FromForm] string? address,
      [FromForm] List<int>? existingImageIds,
      [FromForm] List<IFormFile>? files)
        {
            try
            {
                //-----------------------------------
                // UPDATE PROPERTY
                //-----------------------------------
                var result = await _repo.SaveProperty(new Property
                {
                    Id = propertyId,
                    Title = title,
                    Description = description,
                    Price = price,
                    Address = address
                });

                if (!result.IsSuccess)
                    return Ok(result);

                //-----------------------------------
                // GET OLD IMAGES
                //-----------------------------------
                var oldImages = await _repo.GetPropertyImages(propertyId);

                //-----------------------------------
                // DELETE REMOVED IMAGES
                //-----------------------------------
                if (existingImageIds != null)
                {
                    var toDelete = oldImages
                        .Where(x => !existingImageIds.Contains(x.Id))
                        .ToList();

                    foreach (var img in toDelete)
                    {
                        await _repo.DeletePropertyImage(img.Id);
                    }
                }

                //-----------------------------------
                // INSERT NEW FILES
                //-----------------------------------
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            await file.CopyToAsync(ms);

                            await _repo.SavePropertyImage(new Property
                            {
                                Id = propertyId,
                                FileName = file.FileName,
                                ContentType = file.ContentType,
                                FileSize = file.Length,
                                FileData = ms.ToArray()
                            });
                        }
                    }
                }

                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Updated successfully"
                });
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


        [HttpPost("SaveOrUpdate")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SaveOrUpdateProperty(
            [FromForm] int propertyId,
            [FromForm] string title,
            [FromForm] string? description,
            [FromForm] decimal? price,
            [FromForm] string? address,
            [FromForm] List<int>? existingImageIds,
            [FromForm] List<IFormFile>? files)
        {
            try
            {
                //-----------------------------------
                // STEP 1: INSERT / UPDATE PROPERTY
                //-----------------------------------
                var result = await _repo.SaveProperty(new Property
                {
                    Id = propertyId,
                    Title = title,
                    Description = description,
                    Price = price,
                    Address = address
                });

                if (!result.IsSuccess)
                    return Ok(result);

                var savedPropertyId = propertyId == 0 ? result.Id : propertyId;

                //-----------------------------------
                // STEP 2: HANDLE IMAGES
                //-----------------------------------

                // 🔵 CASE 1: UPDATE (DELETE OLD IMAGES)
                if (propertyId > 0 && existingImageIds != null)
                {
                    var oldImages = await _repo.GetPropertyImages(propertyId);

                    var toDelete = oldImages
                        .Where(x => !existingImageIds.Contains(x.Id))
                        .ToList();

                    foreach (var img in toDelete)
                    {
                        await _repo.DeletePropertyImage(img.Id);
                    }
                }

                // 🟢 CASE 2: INSERT / UPDATE → ADD NEW FILES
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            await file.CopyToAsync(ms);

                            await _repo.SavePropertyImage(new Property
                            {
                                Id = (int)savedPropertyId,
                                FileName = file.FileName,
                                ContentType = file.ContentType,
                                FileSize = file.Length,
                                FileData = ms.ToArray()
                            });
                        }
                    }
                }

                return Ok(new
                {
                    IsSuccess = true,
                    Message = propertyId == 0 ? "Created successfully" : "Updated successfully",
                    PropertyId = savedPropertyId
                });
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

    }
}