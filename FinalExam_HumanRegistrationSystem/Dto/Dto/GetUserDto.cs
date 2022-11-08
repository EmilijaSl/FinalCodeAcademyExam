namespace FinalExam_HumanRegistrationSystem.Dto
{
    public class GetUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }    
        public string Street { get; set; }
        public string HouseNumber { get; set; } 
        public string ApartmentNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
