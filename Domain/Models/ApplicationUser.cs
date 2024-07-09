using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser <string>
    {
        public int IloscZalogowan { get; set; }
        public string DataOstatniegoZalogowania { get; set; }
        public DateTime DataDodania { get; set; }

          

        public string ClientId { get; set; }
        public Client? Client { get; set; }


        public List<Order>? Orders { get; set; }
        public List<Favourite>? Favourites { get; set; }
        public List<SendMessage>? SendMessages { get; set; }
        public List<ReceiveMessage>? ReceiveMessages { get; set; }
        public List<LoggingError>? LoggingErrors { get; set; }
    }
}
