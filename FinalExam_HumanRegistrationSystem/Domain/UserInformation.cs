using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class UserInformation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public Image ProfilePicture { get; set; }
        public PlaceOfResidence PlaceOfResidenceInfo { get; set; }
        public UserInformation()
        { }
    }
}
