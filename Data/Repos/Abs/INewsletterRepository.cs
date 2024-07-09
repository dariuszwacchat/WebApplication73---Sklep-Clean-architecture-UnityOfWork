using Domain.Models;
using Domain.ViewModels.Newsletters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface INewsletterRepository
    {
        Task<List<Newsletter>> GetAll ();
        Task<Newsletter> Get (string id);
        Task<CreateNewsletterViewModel> Create (CreateNewsletterViewModel model);
        Task<bool> Delete (string id);
    }
}
