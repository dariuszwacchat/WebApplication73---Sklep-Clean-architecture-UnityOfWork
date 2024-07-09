using Domain.Models;
using Domain.ViewModels.PhotosProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IPhotosProductRepository
    {
        Task<List<PhotoProduct>> GetAll ();
        Task<PhotoProduct> Get (string id);
        Task<CreatePhotoClientViewModel> Create (CreatePhotoClientViewModel model);
        Task<EditPhotoClientViewModel> Update (EditPhotoClientViewModel model);
        Task<bool> Delete (string id);
        Task<bool> DeletePhotoProductByProductId (string productId, string photoProductId);
    }
}
