using Domain.Models;
using Domain.ViewModels.PhotosClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IPhotosClientRepository
    {
        Task<List<PhotoClient>> GetAll ();
        Task<PhotoClient> Get (string id);
        Task<CreatePhotoClientViewModel> Create (CreatePhotoClientViewModel model);
        Task<EditPhotoClientViewModel> Update (EditPhotoClientViewModel model);
        Task<bool> Delete (string id);
    }
}
