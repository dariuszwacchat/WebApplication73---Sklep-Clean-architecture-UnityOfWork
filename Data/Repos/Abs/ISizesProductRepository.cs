using Domain.Models;
using Domain.ViewModels.SizesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface ISizesProductRepository
    {
        Task<List<SizeProduct>> GetAll ();
        Task<SizeProduct> Get (string id);
        Task<CreateSizeProductViewModel> Create (CreateSizeProductViewModel model);
        Task<EditSizeProductViewModel> Update (EditSizeProductViewModel model);
        Task<bool> Delete (string id);
    }
}
