using Domain.Models;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abs
{
    public interface IUsersService
    {
        Task<List<ApplicationUser>> GetAll ();
        Task<ApplicationUser> Get (string id);
        Task<CreateUserViewModel> Create (CreateUserViewModel model);
        Task<EditUserViewModel> Update (EditUserViewModel model);
        Task<bool> DeleteByUserName (string userName);
    }
}
