using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Favourites
{
    public class FavouritesViewModel : BaseViewModel <Favourite>
    {
        public List<Favourite> Favourites { get; set; }
    }
}
