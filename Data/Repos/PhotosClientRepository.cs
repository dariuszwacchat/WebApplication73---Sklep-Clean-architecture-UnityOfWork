using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.PhotosClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class PhotosClientRepository : IPhotosClientRepository
    {
        private readonly ApplicationDbContext _context;
        public PhotosClientRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhotoClient>> GetAll ()
        {
            return await _context.PhotosClient.ToListAsync();
        }

        public async Task<PhotoClient> Get (string id)
        {
            return await _context.PhotosClient.FirstOrDefaultAsync(f => f.PhotoClientId == id);
        }


        public async Task<CreatePhotoClientViewModel> Create (CreatePhotoClientViewModel model)
        {
            if (model != null)
            {
                try
                {
                    PhotoClient photoClient = new PhotoClient ()
                    {
                        PhotoClientId = Guid.NewGuid ().ToString (),
                        PhotoData = model.PhotoData,
                        ClientId = model.ClientId
                    };
                    _context.PhotosClient.Add(photoClient);
                    await _context.SaveChangesAsync();
                    model.Success = true;
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



        public async Task<EditPhotoClientViewModel> Update (EditPhotoClientViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var photoClient = await _context.PhotosClient.FirstOrDefaultAsync (f=> f.PhotoClientId == model.PhotoClientId);
                    if (photoClient != null)
                    {
                        photoClient.PhotoData = model.PhotoData;

                        _context.Entry(photoClient).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "PhotoClient is null.";
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
                var photoClient = await _context.PhotosClient.FirstOrDefaultAsync (f=> f.PhotoClientId == id);
                if (photoClient != null)
                {
                    _context.PhotosClient.Remove(photoClient);
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
