using Application.Services;
using Application.Services.Abs;
using Data;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly IUserAccountService _userAccountService;

        public OrdersController (IOrdersService ordersService, IUserAccountService userAccountService)
        {
            _ordersService = ordersService;
            _userAccountService = userAccountService;
        }


        [HttpGet]
        public async Task<IActionResult> Index (OrdersViewModel model)
        {
            NI.Navigation = Navigation.OrdersIndex;
            var orders = await _ordersService.GetAllZamowieniaNiezrealizowane (); 

            return View(new OrdersViewModel()
            { 
                Orders = orders,
                Paginator = Paginator<Order>.CreateAsync(orders, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, OrdersViewModel model)
        {
            var orders = await _ordersService.GetAll ();
             
            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                orders = orders.Where(w => w.Client.Nazwisko.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Zrealizowane":
                    orders = orders.Where(w=> w.StatusZamowienia == StatusZamowienia.Zrealizowane).ToList();
                    break;

                case "Niezrealizowane":
                    orders = orders.Where(w => w.StatusZamowienia == StatusZamowienia.Niezrealizowane).ToList();
                    break;

                case "Wszystkie":
                    break;
            }
             
            model.Orders = orders;
            model.Paginator = Paginator<Order>.CreateAsync(orders, model.PageIndex, model.PageSize); 
            return View(model);
        }
         


        [HttpGet]
        public async Task<IActionResult> Edit (string orderId)
        {
            NI.Navigation = Navigation.OrdersEdit;

            if (string.IsNullOrEmpty (orderId))
                return View("NotFound");

            var order = await _ordersService.Get (orderId);

            if (order == null)
                return View("NotFound");

            return View(new EditOrderViewModel()
            {
                OrderId = order.OrderId,
                ClientId = order.ClientId,
                Client = order.Client,
                Confirmed = order.Confirmed,
                DataZamowienia = order.DataZamowienia,
                DataRealizacji = order.DataRealizacji,
                Ilosc = order.Ilosc,
                OrderItems = order.OrderItems,
                OsobaRealizujacaId = order.OsobaRealizujacaId,
                SposobPlatnosci = order.SposobPlatnosci,
                SposobWysylki = order.SposobWysylki,
                Suma = order.Suma,
                //StatusZamowienia = order.StatusZamowienia,
                StatusZamowienia = StatusZamowienia.Zrealizowane,
                Result = ""
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditOrderViewModel model)
        {  
            if (string.IsNullOrEmpty (model.OrderId))
                return View("NotFound");

            model.OsobaRealizujacaId = (await _userAccountService.GetUserByName(User.Identity.Name)).Id;
            if (ModelState.IsValid)
            {
                if ((await _ordersService.Update (model)).Success)
                    return RedirectToAction("Index", "Orders");
            } 
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> OrderDetails (string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                return View("NotFound");

            var order = await _ordersService.Get (orderId);

            if (order == null)
                return View("NotFound");

            return View(order);
        }

           

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var order = await _ordersService.Get (id);

            if (order == null)
                return View("NotFound");

            return View(order);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _ordersService.Delete (id);

            return RedirectToAction("Index", "Orders");
        }



    }
}
