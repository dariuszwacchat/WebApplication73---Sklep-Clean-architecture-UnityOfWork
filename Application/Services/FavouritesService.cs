using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Favourites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FavouritesService : IFavouritesService
    {
        private readonly IUnityOfWork _unityOfWork;

        public FavouritesService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Favourite>> GetAll ()
        {
            return await _unityOfWork.FavouritesRepository.GetAll();
        }

        public async Task<Favourite> Get (string id)
        {
            return await _unityOfWork.FavouritesRepository.Get(id);
        }

        public async Task<CreateFavouriteViewModel> Create (CreateFavouriteViewModel model)
        {
            return await _unityOfWork.FavouritesRepository.Create(model);
        }
         

        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.FavouritesRepository.Delete(id);
        }
    }
}