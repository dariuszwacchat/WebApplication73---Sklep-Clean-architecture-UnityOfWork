using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Favourite
    {
        [Key]
        public string FavouriteId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
