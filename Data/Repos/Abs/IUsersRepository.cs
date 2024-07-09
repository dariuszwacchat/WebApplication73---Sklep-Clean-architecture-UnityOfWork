using Domain.Models;
using Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Data.Repos.Abs
{
    public interface IUsersRepository
    {
        Task<List<ApplicationUser>> GetAll ();
        Task<ApplicationUser> Get (string id);
        Task <CreateUserViewModel> Create (CreateUserViewModel model, string password);
        Task <EditUserViewModel> Update (EditUserViewModel model);
        Task<bool> Delete (string id);
    }
}
