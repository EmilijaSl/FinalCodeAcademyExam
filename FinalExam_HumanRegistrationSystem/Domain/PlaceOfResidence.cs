using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class PlaceOfResidence
    {
        public int Id { get; set; }
        public string City { get; set; }    
        public string Street { get; set; }  
        public string HouseNumber { get; set; } 
        public string ApartmentNumber { get; set; }
        [ForeignKey("UserInformation")]
        public int UserInformationId { get; set; }
        public UserInformation UserInformation { get; set; }
        public PlaceOfResidence()
        { }
    }
}
