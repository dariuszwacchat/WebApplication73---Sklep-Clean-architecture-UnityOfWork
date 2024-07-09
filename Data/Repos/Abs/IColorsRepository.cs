using Domain.Models;
using Domain.ViewModels.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IColorsRepository
    {
        Task<List<Color>> GetAll ();
        Task<Color> Get (string id);
        Task<CreateColorViewModel> Create (CreateColorViewModel model);
        Task<EditColorViewModel> Update (EditColorViewModel model);
        Task<bool> Delete (string id);
    }
}
