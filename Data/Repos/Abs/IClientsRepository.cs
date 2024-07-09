using Domain.Models;
using Domain.ViewModels.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IClientsRepository
    {
        Task<List<Client>> GetAll ();
        Task<Client> Get (string id);
        Task<CreateClientViewModel> Create (CreateClientViewModel model);
        Task<EditClientViewModel> Update (EditClientViewModel model);
        Task<bool> Delete (string id);
    }
}
