using BusinessLogic;
using FinalExam_HumanRegistrationSystem.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
