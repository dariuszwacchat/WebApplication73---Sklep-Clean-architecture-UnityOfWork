using Application.Services;
using Application.Services.Abs;
using Data;
using Data.Services;
using Domain.Models;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IUnityOfWork _unityOfWork;
        private readonly KoszykService _koszykService;
        private readonly IEmailSender _emailSender;

        public AccountController (IUserAccountService userAccountService, IUnityOfWork unityOfWork, KoszykService koszykService, IEmailSender emailSender)
        {
            _userAccountService = userAccountService;
            _unityOfWork = unityOfWork;
            _koszykService = koszykService;
            _emailSender = emailSender;
        }

        public IActionResult Index ()
        {
            return View();
        }

         


        [HttpGet]
        [Route("Update")]
        public async Task<IActionResult> Edit ()
        {
            var user = await _userAccountService.GetUserByName (User.Identity.Name);

            if (user == null)
                return View("NotFound");

            var client = user.Client;
            var userRoles = await _userAccountService.GetUserRoles (user.UserName);


            if (client == null || userRoles == null)
                return View("NotFound");


            return View(new UpdateAccountViewModel()
            {
                UserId = user.Id,
                Email = user.Email,
                Imie = client.Imie,
                Nazwisko = client.Nazwisko,
                Ulica = client.Ulica,
                NumerUlicy = client.NumerUlicy,
                Miejscowosc = client.Miejscowosc,
                Kraj = client.Kraj,
                KodPocztowy = client.KodPocztowy,
                Telefon = client.Telefon,
                RodzajOsoby = client.RodzajOsoby,
                Plec = client.Plec,
                DataUrodzenia = client.DataUrodzenia,
                SelectedRoles = userRoles,
                PhotosClient = client.PhotosClient,
                DataDodania = client.DataDodania,
                Result = ""
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Update")]
        public async Task<IActionResult> Edit (UpdateAccountViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserId))
                return View("NotFound");


            if (ModelState.IsValid)
            {
                if ((await _userAccountService.UpdateAccountSingle(model)).Success)
                    return RedirectToAction("Edit", "Account", new { area = "" });
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult Delete ()
            => View ();


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ()
        {  
            if (await _userAccountService.DeleteAccountByUserName(User.Identity.Name))
                return RedirectToAction("Index", "Account", new { area = "" });
            return View ("NotFound");
        }



        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout ()
        {
            /*Temp._client = null;
            Temp._order = null;*/
            //_koszykService.Clear (); 
            await _userAccountService.Logout ();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpGet]
        [Route("ChangePassword")]
        public IActionResult ChangePassword ()
        {
            return View(new ChangePasswordViewModel() { Result = "" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword (ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;
                if ((await _userAccountService.ChangePassword(model)).Success)
                    return RedirectToAction("Login", "Account", new { area = "" });
            }
            return View(model);
        }


        [HttpGet]
        [Route("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail ()
        {
            var user = await _userAccountService.GetUserByName (User.Identity.Name);
            return View(new ChangeEmailViewModel() { Result = "", ObecnyEmail = user.Email });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail (ChangeEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;
                if ((await _userAccountService.ChangeEmail(model)).Success)
                    return RedirectToAction("Login", "Account", new { area = "" });
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DeletePhotoClient (string clientId, string photoClientId)
        {
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(photoClientId))
                return View("NotFound");

            await _unityOfWork.PhotosClientRepository.Delete(photoClientId);

            return RedirectToAction("Edit", "Account", new { area = "" });
        }




        [AllowAnonymous]
        [HttpGet]
        [Route("Register")]
        public IActionResult Register ()
        {
            return View(new RegisterShortViewModel() { Result = "" });
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]
        public async Task<IActionResult> Register (RegisterShortViewModel model)
        { 
            if (ModelState.IsValid)
            {
                model.Password = "SDG%$@5423sdgagSDert";
                if ((await _userAccountService.RegisterShort (model)).Success)
                { 
                    _emailSender.Send(model.Email);
                    return RedirectToAction("ConfirmEmail", "Account", new { area = "" });
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ConfirmEmail")]
        public IActionResult ConfirmEmail ()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login ()
            => View(new LoginViewModel() { Result = "" });


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login (LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var login = await _userAccountService.Login(model);
                if (login.IsLoggedIn)
                {
                    // sprawdza czy user jest adminem jeśli tak to przekierowywuje go do panelu administratora
                    if (login.UserIsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                        return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            return View(model);
        }


         

    }
}
