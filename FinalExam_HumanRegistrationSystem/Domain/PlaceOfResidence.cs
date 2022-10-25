using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlaceOfResidence
    {
        public string City { get; set; }    
        public string Street { get; set; }  
        public string HouseNumber { get; set; } 
        public string ApartmentNumber { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
