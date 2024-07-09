using Domain.Models;
using Domain.ViewModels.Subcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface ISubcategoriesRepository
    {
        Task<List<Subcategory>> GetAll ();
        Task<Subcategory> Get (string id);
        Task<CreateSubcategoryViewModel> Create (CreateSubcategoryViewModel model);
        Task<EditSubcategoryViewModel> Update (EditSubcategoryViewModel model);
        Task<bool> Delete (string id);
    }
}
