using Domain.Models;
using Domain.ViewModels.Favourites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IFavouritesRepository
    {
        Task<List<Favourite>> GetAll ();
        Task<Favourite> Get (string id);
        Task<CreateFavouriteViewModel> Create (CreateFavouriteViewModel model);
        Task<bool> Delete (string id);
    }
}
