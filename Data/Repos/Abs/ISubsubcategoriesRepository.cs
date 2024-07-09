using Domain.Models;
using Domain.ViewModels.Subsubcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface ISubsubcategoriesRepository
    {
        Task<List<Subsubcategory>> GetAll ();
        Task<Subsubcategory> Get (string id);
        Task<CreateSubsubcategoryViewModel> Create (CreateSubsubcategoryViewModel model);
        Task<EditSubsubcategoryViewModel> Update (EditSubsubcategoryViewModel model);
        Task<bool> Delete (string id);
    }
}
