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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IUserAccountService _accountService;
        private readonly IUnityOfWork _unityOfWork;

        public UsersController (IUserAccountService accountService, IUnityOfWork unityOfWork)
        {
            _accountService = accountService;
            _unityOfWork = unityOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index (UsersViewModel model)
        {
            NI.Navigation = Navigation.UsersIndex;
            var users = await _accountService.GetAll ();

            return View(new UsersViewModel()
            {
                Users = users,
                Paginator = Paginator<ApplicationUser>.CreateAsync(users, model.PageIndex, model.PageSize),
                PageIndex = model.PageIndex,
                PageSize = model.PageSize,
                Start = model.Start,
                End = model.End,
                q = model.q,
                SortowanieOption = model.SortowanieOption
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index (string s, UsersViewModel model)
        {
            var users = await _accountService.GetAll ();

            try
            {
                // Wyszukiwanie
                if (!string.IsNullOrEmpty(model.q))
                    users = users.Where(w => w.Client.Nazwisko.Contains(model.q, StringComparison.OrdinalIgnoreCase) ||
                                             w.Email.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


                // Sortowanie 
                switch (model.SortowanieOption)
                {
                    case "Użytkownicy":
                        users = await _accountService.GetUsersInRole("User");
                        break;

                    case "Administratorzy":
                        users = await _accountService.GetUsersInRole("Administrator");
                        break;

                    case "Zarząd":
                        users = await _accountService.GetUsersInRole("Zarząd");
                        break;

                    case "Marketing":
                        users = await _accountService.GetUsersInRole("Marketing");
                        break;

                    case "Wszyscy":
                        break;
                }
            }
            catch { }

            model.Users = users;
            model.Paginator = Paginator<ApplicationUser>.CreateAsync(users, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create ()
        {
            NI.Navigation = Navigation.UsersCreate;
            return View(new CreateUserViewModel() { SelectedRoles = new List<string>() { }, Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateUserViewModel model)
        {
            NI.Navigation = Navigation.UsersEdit;
            if (ModelState.IsValid)
            {
                model.Password = "SDG%$@5423sdgagSDert";
                if ((await _accountService.CreateUserAccount(model)).Success)
                    return RedirectToAction("Index", "Users");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit (string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return View("NotFound");

            var user = await _accountService.GetUserById (userId);
            var client = user.Client;
            var userRoles = await _accountService.GetUserRoles (user.UserName);

            if (user == null || client == null || client.PhotosClient == null)
                return View("NotFound");


            return View(new EditUserViewModel ()
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
        public async Task<IActionResult> Edit (EditUserViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserId))
                return View("NotFound");

            if (ModelState.IsValid)
            {
                if ((await _accountService.UpdateUserAccount (model)).Success)
                    return RedirectToAction("Index", "Users");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var user = await _accountService.GetUserById (id);

            if (user == null)
                return View("NotFound");

            return View(user);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _accountService.DeleteAccount(id);

            return RedirectToAction("Index", "Users");
        }


        [HttpGet]
        public async Task<IActionResult> DeletePhotoClient (string clientId, string photoClientId)
        {
            if (string.IsNullOrEmpty (clientId) || string.IsNullOrEmpty(photoClientId))
                return View("NotFound");
             
            var user = await _accountService.GetUserByClientId (clientId);
            await _unityOfWork.PhotosClientRepository.Delete (photoClientId);

            return RedirectToAction("Edit", "Users", new { userId = user.Id });
        }


    }
}
