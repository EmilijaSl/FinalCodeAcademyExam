using Microsoft.AspNetCore.Http;
using Validation;

namespace FinalExam_HumanRegistrationSystem.Dto
{
    public class SignupDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        [MaxFileSize(5 * 200 * 200)]
        [AllowedExtensions(new[] { ".png", ".jpg" })]
        public IFormFile Image { get; set; }
    }
}
