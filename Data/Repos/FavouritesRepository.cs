using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Favourites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly ApplicationDbContext _context;
        public FavouritesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Favourite>> GetAll ()
        {
            return await _context.Favourites
                .Include (i=> i.Product)
                .ToListAsync();
        }

        public async Task<Favourite> Get (string id)
        {
            return await _context.Favourites
                .Include(i => i.Product)
                .FirstOrDefaultAsync(f => f.FavouriteId == id);
        }

        public async Task<CreateFavouriteViewModel> Create (CreateFavouriteViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var user = await _context.Users.FirstOrDefaultAsync (f=> f.UserName == model.UserName);
                    if (user != null)
                    {
                        if ((await _context.Favourites.FirstOrDefaultAsync(f => f.ProductId == model.ProductId && f.UserId == user.Id)) == null)
                        {
                            Favourite favourite = new Favourite ()
                            {
                                FavouriteId = Guid.NewGuid ().ToString (),
                                ProductId = model.ProductId,
                                UserId = user.Id
                            };
                            _context.Favourites.Add(favourite);
                            await _context.SaveChangesAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "Ten produkt jest już dodany do ulubionych.";
                        }
                    }
                    else
                    {
                        model.Result = "User is null";
                    }
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Model is null.";
            }
            return model;
        }
         

        public async Task<bool> Delete (string id)
        {
            bool deleteResult = false;
            try
            {
                var favourite = await _context.Favourites.FirstOrDefaultAsync (f=>f.FavouriteId == id);
                if (favourite != null)
                {
                    _context.Favourites.Remove(favourite);
                    await _context.SaveChangesAsync();
                    deleteResult = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return deleteResult;
        }

    }
}