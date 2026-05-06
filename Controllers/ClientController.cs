using Champerof.Infra;
using Champerof.Models;
using Champerof.ServiceRepository.ClientRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientRepository _clientRepository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;

        public ClientController(IClientRepository clientRepository, ValidationService validation)
        {
            _clientRepository = clientRepository;
            _validation = validation;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "")
        {
            var data = await _clientRepository.GetAllClients(start, length, sortColumn, sortColumnDir, searchValue);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Add(Clients client)
        {
            var validation = _validation.ValidateRequired(client.ClientName, "Client Name");
            if (!validation.IsSuccess) return Ok(validation);

            //var email = _validation.ValidateEmail(client.Email);
            //if (!email.IsSuccess) return Ok(email);

            //var mobileValidation = _validation.ValidateMobile(client.Phone);
            //if (!mobileValidation.IsSuccess) { return Ok(mobileValidation); }

            //var City = _validation.ValidateRequired(client.City, "City Name");
            //if (!City.IsSuccess) return Ok(City);

            //var State = _validation.ValidateRequired(client.State, "State Name");
            //if (!State.IsSuccess) return Ok(State);

            //var Pincode = _validation.ValidateRequired(client.Pincode, "Pin Code");
            //if (!Pincode.IsSuccess) return Ok(Pincode);
            
            
    //            if (string.IsNullOrWhiteSpace(client.Pincode)
    //|| !System.Text.RegularExpressions.Regex.IsMatch(client.Pincode, @"^\d{6}$"))
    //            {
    //                CommonViewModel.IsSuccess = false;
    //                CommonViewModel.Message = "Pincode must be exactly 6 digits";
    //                CommonViewModel.StatusCode = ResponseStatusCode.Error;
    //                return Ok(CommonViewModel);
    //            }
           



            var (IsSuccess, Message, Id, Extra) = await _clientRepository.AddOrUpdateClient(client);

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
            var data = await _clientRepository.GetClientById(id);

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
                CommonViewModel.Message = "Client not found";
            }

            return Ok(CommonViewModel);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> Delete(long id)
        {
            var (IsSuccess, Message, Id, Extra) = await _clientRepository.DeleteClient(id);

            CommonViewModel.IsSuccess = IsSuccess;
            CommonViewModel.IsConfirm = true;
            CommonViewModel.StatusCode = IsSuccess ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            CommonViewModel.Message = Message;

            return Ok(CommonViewModel);
        }
    }
}