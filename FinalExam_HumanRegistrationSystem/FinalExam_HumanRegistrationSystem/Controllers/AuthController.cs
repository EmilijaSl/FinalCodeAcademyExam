using BusinessLogic;
using FinalExam_HumanRegistrationSystem.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalExam_HumanRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userAccountService;
        private readonly IJwtService _jwtService;
        private readonly IImagesService _imagesService;

        public AuthController(IUserService usersService, IJwtService jwtService, IImagesService imagesService)
        {
            _userAccountService = usersService;
            _jwtService = jwtService;
            _imagesService = imagesService;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(SignupDto signupDto)

        {
            using var memoryStream = new MemoryStream();
            signupDto.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var savedImage = await _imagesService.AddImageAsync(imageBytes, signupDto.Image.ContentType);

            var success = await _userAccountService.CreateUserAsync(signupDto.Username, signupDto.Password, signupDto.Name, signupDto.LastName, signupDto.PersonalCode, signupDto.PhoneNumber, signupDto.Email, signupDto.City, signupDto.Street, signupDto.HouseNumber, signupDto.ApartmentNumber, savedImage);

            return success ? Ok() : BadRequest(new { ErrorMessage = "User already exist" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var (loginSuccess, user) = await _userAccountService.LoginAsync(loginDto.Username, loginDto.Password);

            if (loginSuccess)
            {
                return Ok(new { Token = _jwtService.GetJwt(user) });
            }

            return BadRequest(new { ErrorMessage = "Login failed" });
        }
        [HttpGet("Get User Information")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            var user = await _userAccountService.GetUserByIdAsync(userId);

            var infoToReturn = new GetUserDto
            {
                UserName = user.Username,
                Role = user.Role,
                Name = user.userInformation.Name,
                LastName = user.userInformation.LastName,
                PersonalCode = user.userInformation.PersonalCode,
                Phone = user.userInformation.PhoneNumber,
                Email = user.userInformation.Email,
                City = user.userInformation.PlaceOfResidenceInfo.City,
                Street = user.userInformation.PlaceOfResidenceInfo.Street,
                HouseNumber = user.userInformation.PlaceOfResidenceInfo.HouseNumber,
                ApartmentNumber = user.userInformation.PlaceOfResidenceInfo.ApartmentNumber,
                ProfilePicture = user.userInformation.ProfilePicture.ImageBytes
            };
            return Ok(infoToReturn);
        }
        [HttpDelete("Delete User")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userAccountService.DeleteUserAsync(userId);
            return Ok();
        }

    }
}
