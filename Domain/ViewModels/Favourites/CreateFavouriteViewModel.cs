using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Favourites
{
    public class CreateFavouriteViewModel
    {
        public string FavouriteId { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string ProductId { get; set; }



        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
