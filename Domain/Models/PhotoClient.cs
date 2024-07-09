using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PhotoClient
    {
        [Key]
        public string PhotoClientId { get; set; }
        public byte[] PhotoData { get; set; }

         

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
