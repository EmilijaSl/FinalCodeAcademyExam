using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] ImageBytes { get; set; }
        [ForeignKey("UserInformation")]
        public int? UserInformationId { get; set; }
        public UserInformation? UserInformation { get; set; }
        public Image()
        { }
    }
}
