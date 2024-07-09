using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LoggingError
    {
        [Key]
        public string LoggingErrorId { get; set; }
        public string Controller { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public DateTime DataUtworzenia { get; set; }



        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }


        public string ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
