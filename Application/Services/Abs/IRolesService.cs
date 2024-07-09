using Domain.Models;
using Domain.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Abs
{
    public interface IRolesService
    {
        Task<List<ApplicationRole>> GetAll ();
        Task<ApplicationRole> Get (string id);
        Task <CreateRoleViewModel> Create (CreateRoleViewModel model);
        Task Delete (string id);
        Task <EditRoleViewModel> Update (EditRoleViewModel model);
        Task <List<ApplicationUser>> UsersInRole (string roleName);
    }
}
