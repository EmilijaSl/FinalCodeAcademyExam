using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalExam_HumanRegistrationSystem.Controllers
{
    [Route("api/[controller]")]

    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationService _userInformationService;
        public UserInformationController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }
        [HttpPut("Update Name")]
        [Authorize]
        public async Task<IActionResult> ChangeNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _userInformationService.UpdateUserNameAsync(userId, name);
            return Ok();
        }
        [HttpPut("Update Lastname")]
        [Authorize]
        public async Task<IActionResult> ChangeLastnameAsync(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _userInformationService.UpdateUserLastNameAsync(userId, lastname);
            return Ok();
        }
        [HttpPut("Update Personal Code")]
        [Authorize]
        public async Task<IActionResult> ChangePersonalCodeAsync(string pk)
        {
            if (string.IsNullOrWhiteSpace(pk))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _userInformationService.UpdateUserPKAsync(userId, pk);
            return Ok();
        }
        [HttpPut("Update Phone")]
        [Authorize]
        public async Task<IActionResult> ChangePhoneAsync(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _userInformationService.UpdateUserPhoneAsync(userId, phone);
            return Ok();
        }
        [HttpPut("Update Email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _userInformationService.UpdateUserEmailAsync(userId, email);
            return Ok();
        }
    }
}
