using Domain.Models;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Application.Services.Abs
{
    public interface IUserAccountService
    {
        Task<List<ApplicationUser>> GetAll ();
        Task<ApplicationUser> GetUserById (string userId);
        Task<ApplicationUser> GetUserByEmail (string userEmail);
        Task<ApplicationUser> GetUserByName (string userName); 
        Task<ApplicationUser> GetUserByClientId (string clientId);
        Task <LoginViewModel> Login (LoginViewModel model);
        Task Logout ();
        Task<RegisterViewModel> Register (RegisterViewModel model);
        Task<RegisterShortViewModel> RegisterShort (RegisterShortViewModel model);
        Task <ChangeEmailViewModel> ChangeEmail (ChangeEmailViewModel model);
        Task<ChangePasswordViewModel> ChangePassword (ChangePasswordViewModel model);
        Task <SendConfirmationViewModel> SendConfirmationEmail (SendConfirmationViewModel model);
        Task <ConfirmEmailViewModel> ConfirmEmail (ConfirmEmailViewModel model); 
        Task<UpdateAccountViewModel> UpdateAccount (UpdateAccountViewModel model);
        Task<UpdateAccountViewModel> UpdateAccountSingle (UpdateAccountViewModel model);

        Task<CreateUserViewModel> CreateUserAccount (CreateUserViewModel model);
        Task<EditUserViewModel> UpdateUserAccount (EditUserViewModel model);

        Task<bool> DeleteAccount (string userId);
        Task<bool> DeleteAccountByUserName (string userName);
        Task<bool> RemoveFromRole (string userName, string roleName);
        Task<bool> AddToRole (string userName, string roleName);
        Task<bool> AddClaim (string userName, string roleName);
        Task<List<string>> GetUserRoles (string userName);
        Task<List<ApplicationUser>> GetUsersInRole (string roleName);
        Task<bool> LoggedUserIsAdmin (string email);
    }
}
