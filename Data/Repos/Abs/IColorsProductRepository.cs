using Domain.Models;
using Domain.ViewModels.ColorsProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IColorsProductRepository
    {
        Task<List<ColorProduct>> GetAll ();
        Task<ColorProduct> Get (string id);
        Task<CreateColorProductViewModel> Create (CreateColorProductViewModel model);
        Task<EditColorProductViewModel> Update (EditColorProductViewModel model);
        Task<bool> Delete (string id);
    }
}
