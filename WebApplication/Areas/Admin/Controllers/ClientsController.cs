using Application.Services;
using Application.Services.Abs;
using Data;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;

        public ClientsController (IClientsService clientsService)
        {
            _clientsService = clientsService;
        }


        [HttpGet]
        public async Task<IActionResult> Index (ClientsViewModel model)
        {
            NI.Navigation = Navigation.ClientsIndex;
            var clients = await _clientsService.GetAll ();

            return View(new ClientsViewModel()
            {
                Clients = clients,
                Paginator = Paginator<Client>.CreateAsync(clients, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, ClientsViewModel model)
        {
            var clients = await _clientsService.GetAll ();

            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                clients = clients.Where(w => w.Nazwisko.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwisko A-Z":
                    clients = clients.OrderBy(o => o.Nazwisko).ToList();
                    break;

                case "Nazwisko Z-A":
                    clients = clients.OrderByDescending(o => o.Nazwisko).ToList();
                    break;

                case "Data dodania rosnąco":
                    clients = clients.OrderBy(o => o.DataDodania).ToList();
                    break;

                case "Data dodania malejąco":
                    clients = clients.OrderByDescending(o => o.DataDodania).ToList();
                    break;
            }

            model.Clients = clients;
            model.Paginator = Paginator<Client>.CreateAsync(clients, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            NI.Navigation = Navigation.ClientsCreate;
            return View(new CreateClientViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _clientsService.Create(model)).Success)
                    return RedirectToAction("Index", "Clients");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit (string clientId)
        {
            NI.Navigation = Navigation.ClientsEdit;

            if (string.IsNullOrEmpty(clientId))
                return View("NotFound");

            var client = await _clientsService.Get (clientId);

            if (client == null || client.PhotosClient == null)
                return View("NotFound");

            return View(new EditClientViewModel()
            {
                ClientId = client.ClientId,
                Imie = client.Imie,
                Nazwisko = client.Nazwisko,
                Ulica = client.Ulica,
                NumerUlicy = client.NumerUlicy,
                Miejscowosc = client.Miejscowosc,
                KodPocztowy = client.KodPocztowy,
                Kraj = client.Kraj,
                Telefon = client.Telefon,
                Email = client.Email,
                RodzajOsoby = client.RodzajOsoby,
                Plec = client.Plec,
                DataUrodzenia = client.DataUrodzenia,  
                PhotosClient = client.PhotosClient,
                Result = ""
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _clientsService.Update (model)).Success)
                    return RedirectToAction("Index", "Clients");
            }

            return View(model);
        }



        /*[HttpGet]
        public async Task<IActionResult> Details (string clientId)
        {
            var client = await _clientsService.Get (clientId);

            if (client == null)
                return View("NotFound")();

            return View(client);
        }*/



        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            var client = await _clientsService.Get (id);

            if (client == null)
                return View("NotFound");

            return View(client);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            await _clientsService.Delete (id);

            return RedirectToAction("Index", "Clients");
        }

         

    }
}
