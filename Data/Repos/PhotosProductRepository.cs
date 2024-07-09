using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.PhotosProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class PhotosProductRepository : IPhotosProductRepository
    {
        private readonly ApplicationDbContext _context;
        public PhotosProductRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhotoProduct>> GetAll ()
        {
            return await _context.PhotosProduct.ToListAsync();
        }

        public async Task<PhotoProduct> Get (string id)
        {
            return await _context.PhotosProduct.FirstOrDefaultAsync(f => f.PhotoProductId == id);
        }


        public async Task<CreatePhotoClientViewModel> Create (CreatePhotoClientViewModel model)
        {
            if (model != null)
            {
                try
                {
                    PhotoProduct photoProduct = new PhotoProduct ()
                    {
                        PhotoProductId = Guid.NewGuid ().ToString (),
                        PhotoData = model.PhotoData,
                        ProductId = model.ProductId
                    };
                    _context.PhotosProduct.Add(photoProduct);
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
                    var photoProduct = await _context.PhotosProduct.FirstOrDefaultAsync (f=> f.PhotoProductId == model.PhotoProductId);
                    if (photoProduct != null)
                    {
                        photoProduct.PhotoData = model.PhotoData;

                        _context.Entry(photoProduct).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "PhotoProduct is null.";
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
                var photoProduct = await _context.PhotosProduct.FirstOrDefaultAsync (f=>f.PhotoProductId == id);
                if (photoProduct != null)
                {
                    _context.PhotosProduct.Remove(photoProduct);
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


        public async Task<bool> DeletePhotoProductByProductId (string productId, string photoProductId)
        {
            bool deleteResult = false;
            try
            {
                var photoProduct = await _context.PhotosProduct.FirstOrDefaultAsync (f=> f.ProductId == productId && f.PhotoProductId == photoProductId);
                if (photoProduct != null)
                {
                    _context.PhotosProduct.Remove(photoProduct);
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
