using Domain.Models;
using Domain.ViewModels.Marki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IMarkiRepository
    {
        Task<List<Marka>> GetAll ();
        Task<Marka> Get (string id);
        Task<CreateMarkaViewModel> Create (CreateMarkaViewModel model);
        Task<EditMarkaViewModel> Update (EditMarkaViewModel model);
        Task<bool> Delete (string id);
    }
}
