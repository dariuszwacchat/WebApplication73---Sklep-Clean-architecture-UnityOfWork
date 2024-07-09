using Data.Repos.Abs;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdersRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll ()
        {
            return await _context.Orders
                .Include(i => i.OrderItems)
                    .ThenInclude (t=> t.Product)
                        .ThenInclude (t=> t.PhotosProduct)
                .Include(i => i.Client)
                .Include(i => i.OsobaRealizujaca)
                    .ThenInclude(t => t.Client)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllZamowieniaNiezrealizowane ()
        {
            return await _context.Orders
                .Include(i => i.OrderItems)
                    .ThenInclude(t => t.Product)
                        .ThenInclude(t => t.PhotosProduct)
                .Include(i => i.Client)
                .Include(i => i.OsobaRealizujaca)
                    .ThenInclude(t => t.Client)
                .Where (w=> w.StatusZamowienia == StatusZamowienia.Niezrealizowane)
                .ToListAsync();
        }

        public async Task<Order> Get (string id)
        {
            return await _context.Orders
                .Include(i => i.OrderItems)
                    .ThenInclude(t => t.Product)
                        .ThenInclude(t => t.PhotosProduct)
                .Include(i => i.Client)
                .Include(i => i.OsobaRealizujaca)
                    .ThenInclude(t => t.Client)
                .FirstOrDefaultAsync(f => f.OrderId == id);
        }


        public async Task<CreateOrderViewModel> Create (CreateOrderViewModel model)
        {
            if (model != null)
            {
                try
                {
                    Order order = new Order ()
                    {
                        OrderId = Guid.NewGuid ().ToString (),
                        Ilosc = model.Ilosc,
                        Suma = model.Suma,
                        SposobWysylki = model.SposobWysylki,
                        SposobPlatnosci = model.SposobPlatnosci,
                        StatusZamowienia = StatusZamowienia.Niezrealizowane,
                        Confirmed = true,
                        ClientId = model.ClientId,
                        OsobaRealizujacaId = model.OsobaRealizujacaId,
                        DataZamowienia = DateTime.Now
                    };
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    model.Success = true;
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Model is null.";
            }
            return model;
        }



        public async Task<EditOrderViewModel> Update (EditOrderViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var order = await _context.Orders.FirstOrDefaultAsync (f=> f.OrderId == model.OrderId);
                    if (order != null)
                    { 
                        order.StatusZamowienia = model.StatusZamowienia;
                        order.OsobaRealizujacaId = model.OsobaRealizujacaId;
                        order.DataRealizacji = DateTime.Now;

                        _context.Entry(order).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "Order is null.";
                    }
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Model is null.";
            }
            return model;
        }



        public async Task<bool> Delete (string id)
        {
            bool deleteResult = false;
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync (f=>f.OrderId == id);
                if (order != null)
                {
                    // delete order items 
                    var orderItems = await _context.OrderItems.Where (w=> w.OrderId == order.OrderId).ToListAsync();
                    foreach (var orderItem in orderItems) 
                        _context.OrderItems.Remove(orderItem);  

                    // delete order 
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                    deleteResult = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return deleteResult;
        }

    }
}
