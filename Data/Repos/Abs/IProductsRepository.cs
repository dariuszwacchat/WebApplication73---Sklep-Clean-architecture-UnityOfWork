using Domain.Models;
using Domain.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAll ();
        Task<Product> Get (string id);
        Task<CreateProductViewModel> Create (CreateProductViewModel model);
        Task<EditProductViewModel> Update (EditProductViewModel model);
        Task<bool> Delete (string id);
    }
}
