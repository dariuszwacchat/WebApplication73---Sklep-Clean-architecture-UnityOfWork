using Application.Services;
using Application.Services.Abs;
using Data;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AccountController : Controller
    {
        private readonly IUserAccountService _accountService;
        private readonly IUnityOfWork _unityOfWork;
        private readonly KoszykService _koszykService;

        public AccountController (IUserAccountService accountService, IUnityOfWork unityOfWork, KoszykService koszykService)
        {
            _accountService = accountService;
            _unityOfWork = unityOfWork;
            _koszykService = koszykService;
        }


        [HttpGet]
        public async Task<IActionResult> Edit ()
        {
            NI.Navigation = Navigation.AccountEdit;
            var user = await _accountService.GetUserByName (User.Identity.Name);

            if (user == null)
                return View("NotFound");

            var client = user.Client;
            var userRoles = await _accountService.GetUserRoles (user.UserName);


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
        public async Task<IActionResult> Edit (UpdateAccountViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserId))
                return View("NotFound");


            if (ModelState.IsValid)
            {
                if ((await _accountService.UpdateAccountSingle(model)).Success)
                    return RedirectToAction("Edit", "Account");
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            return View();
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _accountService.DeleteAccountByUserName (User.Identity.Name);

            return RedirectToAction("Index", "Account");
        }

          

        [HttpGet]
        public async Task<IActionResult> Logout ()
        {
            _koszykService.Clear ();
            await _accountService.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpGet]
        public IActionResult ChangePassword ()
        {
            NI.Navigation = Navigation.AccountChangePassword;
            return View(new ChangePasswordViewModel() { Result = "" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword (ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;
                if ((await _accountService.ChangePassword(model)).Success)
                    return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
         

        [HttpGet]
        public IActionResult ChangeEmail ()
        {
            NI.Navigation = Navigation.AccountChangeEmail;
            return View(new ChangeEmailViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeEmail (ChangeEmailViewModel model)
        {
            NI.Navigation = Navigation.AccountChangeEmail;
            if (ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;
                if ((await _accountService.ChangeEmail(model)).Success)
                    return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DeletePhotoClient (string clientId, string photoClientId)
        {
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(photoClientId))
                return View("NotFound");
             
            await _unityOfWork.PhotosClientRepository.Delete(photoClientId);

            return RedirectToAction("Edit", "Account");
        }



         
         

    }
}
