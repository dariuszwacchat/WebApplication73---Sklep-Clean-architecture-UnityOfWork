using Application.Services;
using Data;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Orders;
using Domain.ViewModels.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication58.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager <ApplicationUser> _userManager;
        private readonly SignInManager <ApplicationUser> _singInManager;
        private readonly KoszykService _koszykService;
        private readonly TempOrderService _tempOrderService;

        public OrdersController (ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager, KoszykService koszykService, TempOrderService tempOrderService)
        {
            _context = context;
            _userManager = userManager;
            _singInManager = singInManager;
            _koszykService = koszykService;
            _tempOrderService = tempOrderService;
        }


        // Obiekty tymczasowe wykorzystywane do zbierania danych z formularzy podczas składania zamówienia, dane są pobierane z sesji
        public Client _client { get; set; }
        public Order _order { get; set; }

        public async Task<IActionResult> Index ()
        {
            if ((await GetAllOrdersUser ()) == null)
                return View ("NotFound");
            else
                return View (await GetAllOrdersUser ()); 
        }

          

        [HttpGet]
        public async Task<IActionResult> Details (string orderId)
        {
            var order = await _context.Orders
                .Include (i=> i.OrderItems)
                    .ThenInclude (t=> t.Product)
                        .ThenInclude (t=> t.PhotosProduct)
                .FirstOrDefaultAsync (f=> f.OrderId == orderId);

            if (order == null || order.OrderItems == null)
                return View ("NotFound");

            return View(order);
        }



        [HttpGet]
        public IActionResult OrderFormularz ()
        {
            // Jeżeli użytkownik jest zalogowany to wyświetla stronę z danymi
            if (_singInManager.IsSignedIn(User))
            {
                return RedirectToAction("WithRegister", "Orders");
            }

            return View(new OrderFormularzViewModel() { RodzajTransakcji = "", Result = "" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderFormularz (OrderFormularzViewModel model)
        { 
            /*
                 po wybraniu odpowiedniej opcji i kliknięciu przycisk "Dalej", użytkownik jest przekierowywany
                 na odpowiednią stronę
             */
            switch (model.RodzajTransakcji)
            {
                case "Logowanie":
                    return RedirectToAction("Login", "Account");

                case "Rejestracja":
                    return RedirectToAction("Register", "Account");

                case "BezRejestracji":
                    return RedirectToAction("WithoutRegister", "Orders");
            }
            model.Result = "Jedna z opcji musi być wybrana";
            return View(model);
        }
         

        [HttpGet]
        public IActionResult WithoutRegister ()
        {
            WithoutRegisterOrderViewModel wr = new WithoutRegisterOrderViewModel () { Result = "" }; 
            // dane są wczytywane wtedy gdy użytkownik wciśnie przycisk "Wstecz" na formularzu
            // pobiranie obiektu z sesji
            _client = _tempOrderService.GetClient();
            if (_client != null)
            {
                wr.Imie = _client.Imie;
                wr.Nazwisko = _client.Nazwisko;
                wr.Ulica = _client.Ulica;
                wr.NumerUlicy = _client.NumerUlicy;
                wr.KodPocztowy = _client.KodPocztowy;
                wr.Miejscowosc = _client.Miejscowosc;
                wr.Kraj = _client.Kraj;
                wr.Telefon = _client.Telefon;
                wr.Email = _client.Email;
                wr.RodzajOsoby = _client.RodzajOsoby;
                wr.Plec = _client.Plec;
            }
            return View(wr);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WithoutRegister (WithoutRegisterOrderViewModel model)
        {
            // statyczne zbieranie danych do modelu
            if (ModelState.IsValid)
            {
                _client = new Client()
                {
                    ClientId = Guid.NewGuid().ToString(),
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    Ulica = model.Ulica,
                    NumerUlicy = model.NumerUlicy,
                    Miejscowosc = model.Miejscowosc,
                    KodPocztowy = model.KodPocztowy,
                    Kraj = model.Kraj,
                    RodzajOsoby = model.RodzajOsoby,
                    Plec = model.Plec,
                    Telefon = model.Telefon,
                    Email = model.Email,
                    DataDodania = DateTime.Now
                };
                /*
                    dodanie obiektu do sesji, po to aby móc poteg od odczytać i wyświetlić w odpowiednich polach,
                    gdy użytkownik np kliknię "Wstecz" podczas wypełniania formularza zakupów
                */
                _tempOrderService.CreateClient (_client);

                return RedirectToAction("OrderPayments", "Orders");
            }

            return View(model);
        }





        [HttpGet]
        public IActionResult OrderPayments ()
        {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderPayments (PaymentsViewModel model)
        {
            // statyczne zbieranie danych do modelu
            if (ModelState.IsValid)
            {
                // pobiranie obiektu z sesji
                _client = _tempOrderService.GetClient ();
                if (_client != null)
                {
                    _order = new Order()
                    {
                        OrderId = Guid.NewGuid().ToString(),
                        SposobPlatnosci = model.SposobPlatnosci,
                        SposobWysylki = model.SposobWysylki,
                        ClientId = _client.ClientId,
                        DataZamowienia = DateTime.Now,
                    };
                    // dodanie obiektu do sesji
                    _tempOrderService.CreateOrder (_order);
                }

                return RedirectToAction("OrderConfirmation", "Orders", new { orderId = model.OrderId });
            }
            return View(model);
        }





        [HttpGet]
        public IActionResult OrderConfirmation ()
        {
            // pobranie obiektów z sesji
            _client = _tempOrderService.GetClient ();
            _order = _tempOrderService.GetOrder ();
            if (_client == null || _order == null)
                return View ("NotFound");

            return View(new OrderConfirmationViewModel()
            {
                Client = _client,
                Order = _order,
                KoszykItems = _koszykService.GetAll()
            });
        }



        [HttpGet]
        public async Task<IActionResult> Confirm ()
        {
            // Potwierdzenie zamówienia tworzy rekord w bazie składający się z trzech części: Client, Order oraz odpowiednia ilość OrderItem
            try
            { 
                // pobranie obiektów z sesji
                _client = _tempOrderService.GetClient();
                _order = _tempOrderService.GetOrder();
                if (_client == null || _order == null)
                    return View("NotFound");

                 
                    _context.Clients.Add(_client);

                    _order.Ilosc = _koszykService.GetAll().Sum(s => s.Ilosc);
                    _order.Suma = _koszykService.GetAll().Sum(s => s.Suma);
                    _order.StatusZamowienia = StatusZamowienia.Niezrealizowane; 
                    _context.Orders.Add(_order);


                    foreach (var koszykItem in _koszykService.GetAll())
                    {
                        OrderItem orderItem = new OrderItem ()
                        {
                            OrderItemId = Guid.NewGuid ().ToString (),
                            Ilosc = koszykItem.Ilosc,
                            Suma = koszykItem.Suma,
                            OrderId = _order.OrderId,
                            ProductId = koszykItem.ProductId
                        };
                        _context.OrderItems.Add(orderItem);
                    }
                    await _context.SaveChangesAsync();

                    // usunięcie wpisów w koszyku oraz wszystkich sesji
                    _koszykService.Clear ();
                    _tempOrderService.ClearAllSessions ();

                    /*
                                        // Uruchomienie okna płatności
                                        string currency = "USD";
                                        var orderId = await _payPalPayoutService.CreateOrder(Convert.ToDecimal(_order.Suma), currency);
                                        if (!string.IsNullOrEmpty(orderId))
                                        {
                                            _koszykService.Clear();
                                            _client = null;
                                            _order = null;

                                            return Redirect($"https://www.sandbox.paypal.com/checkoutnow?token={orderId}");
                                        }
                                        else
                                            ViewData["ErrorMessage"] = "Błąd podczas tworzenia zamówienia.";
                                         */

               
            }
            catch { }

            return View();
        }


















        [HttpGet]
        public async Task<IActionResult> WithRegister ()
        {
            var user = await _context.Users
                .Include (i=> i.Client)
                .FirstOrDefaultAsync (f=> f.UserName == User.Identity.Name);

            if (user.Client == null)
                return View("NotFound");

            return View(user);
        } 



        [HttpGet]
        public IActionResult OrderPaymentsWithRegister ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> OrderPaymentsWithRegister (PaymentsViewModel model)
        {
            // statyczne zbieranie danych do modelu
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .Include (i=> i.Client)
                    .FirstOrDefaultAsync (f=> f.UserName == User.Identity.Name);

                if (user.Client == null)
                    return View("NotFound");
 

                    _order = new Order()
                    {
                        OrderId = Guid.NewGuid().ToString(),
                        SposobPlatnosci = model.SposobPlatnosci,
                        SposobWysylki = model.SposobWysylki,
                        ClientId = user.ClientId,
                        DataZamowienia = DateTime.Now,
                    };
                    // dodanie obiektu do sesji
                    _tempOrderService.CreateOrder(_order);
              

                return RedirectToAction("OrderConfirmationWithRegister", "Orders", new { orderId = model.OrderId });
            }
            return View(model);
        }





        [HttpGet]
        public async Task <IActionResult> OrderConfirmationWithRegister ()
        {
            var user = await _context.Users
                    .Include (i=> i.Client)
                    .FirstOrDefaultAsync (f=> f.UserName == User.Identity.Name);

            // pobranie obiektu z sesji
            _order = _tempOrderService.GetOrder();

            if (user.Client == null || _order == null)
                return View("NotFound");

            return View(new OrderConfirmationViewModel()
            {
                Client = user.Client,
                Order = _order,
                KoszykItems = _koszykService.GetAll()
            });
        }



        [HttpGet]
        public async Task<IActionResult> ConfirmWithRegister ()
        {
            // Potwierdzenie zamówienia tworzy rekord w bazie składający się z trzech części: Client, Order oraz odpowiednia ilość OrderItem
            try
            {
                var user = await _context.Users
                    .Include (i=> i.Client)
                    .FirstOrDefaultAsync (f=> f.UserName == User.Identity.Name);

                // pobranie obiektu z sesji
                _order = _tempOrderService.GetOrder();

                if (user.Client == null || _order == null)
                    return View("NotFound");
                 

                _order.Ilosc = _koszykService.GetAll().Sum(s => s.Ilosc);
                _order.Suma = _koszykService.GetAll().Sum(s => s.Suma);
                _order.StatusZamowienia = StatusZamowienia.Niezrealizowane;
                _context.Orders.Add(_order);


                foreach (var koszykItem in _koszykService.GetAll())
                {
                    OrderItem orderItem = new OrderItem ()
                    {
                        OrderItemId = Guid.NewGuid ().ToString (),
                        Ilosc = koszykItem.Ilosc,
                        Suma = koszykItem.Suma,
                        OrderId = _order.OrderId,
                        ProductId = koszykItem.ProductId
                    };
                    _context.OrderItems.Add(orderItem);
                }
                await _context.SaveChangesAsync();

                // usunięcie wpisów w koszyku oraz wszystkich sesji
                _koszykService.Clear();
                _tempOrderService.ClearAllSessions(); 
            }
            catch { }

            return View();
        }
















        private async Task<RegisterOrderViewModel> RegisterOrder (RegisterOrderViewModel model)
        {
            if ((await _context.Users.FirstOrDefaultAsync(f => f.Email == model.Email)) == null)
            {
                ApplicationUser user = new ApplicationUser ()
                {
                    Id = Guid.NewGuid ().ToString (),
                    Email = model.Email,
                    UserName = model.Email,
                    NormalizedUserName = model.Email.ToUpper(),
                    NormalizedEmail = model.Email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid ().ToString (),
                    DataDodania = DateTime.Now
                };

                var result = await _userManager.CreateAsync (user, model.Password);
                if (result.Succeeded)
                {
                    // dodanie danych Client
                    Client client = new Client ()
                    {
                        ClientId = Guid.NewGuid ().ToString (),
                        Imie = model.Imie,
                        Nazwisko = model.Nazwisko,
                        Ulica = model.Ulica,
                        NumerUlicy = model.NumerUlicy,
                        Miejscowosc = model.Miejscowosc,
                        KodPocztowy = model.KodPocztowy,
                        Kraj = model.Kraj,
                        Telefon = model.Telefon,
                        RodzajOsoby = model.RodzajOsoby,
                        Plec = model.Plec,
                        DataUrodzenia = model.DataUrodzenia,
                        Email = user.Email,
                        DataDodania = DateTime.Now,
                    };
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();


                    user.ClientId = client.ClientId;
                    await _userManager.UpdateAsync(user);


                    // dodanie nowozarejestrowanego użytkownika do ról 

                    await _userManager.AddToRoleAsync(user, "User");
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));

                    // zalogowanie
                    //await _signInManager.SignInAsync(user, false);
                    model.Result = "Zarejestrowano, sprawdź pocztę aby dokończyć rejestrację";
                    model.Success = true;
                }
                else
                {
                    model.Result = "Nie zarejestrowano";
                }
            }
            else
            {
                model.Result = "Nazwa maila jest już zajęta.";
            }
            return model;
        }



        private async Task<WithoutRegisterOrderViewModel> WithoutRegisterOrder (WithoutRegisterOrderViewModel model)
        {
            if ((await _context.Users.FirstOrDefaultAsync(f => f.Email == model.Email)) == null)
            {

                // dodanie danych Client
                Client client = new Client ()
                {
                    ClientId = Guid.NewGuid ().ToString (),
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    Ulica = model.Ulica,
                    NumerUlicy = model.NumerUlicy,
                    Miejscowosc = model.Miejscowosc,
                    KodPocztowy = model.KodPocztowy,
                    Kraj = model.Kraj,
                    Telefon = model.Telefon,
                    RodzajOsoby = model.RodzajOsoby,
                    Plec = model.Plec,
                    DataUrodzenia = model.DataUrodzenia,
                    Email = model.Email,
                    DataDodania = DateTime.Now,
                };
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();


                model.Result = "Zarejestrowano, sprawdź pocztę aby dokończyć rejestrację";
                model.Success = true;
            }
            else
            {
                model.Result = "Nazwa maila jest już zajęta.";
            }
            return model;
        }


        private async Task<List<Order>> GetAllOrdersUser ()
        {
            var user = await _context.Users
                .Include (i=> i.Client)
                    .ThenInclude (t=> t.Orders)
                        .ThenInclude (t=> t.OrderItems)
                .FirstOrDefaultAsync (f=> f.UserName == User.Identity.Name);
             

            if (user != null)
            {
                if (user.Client != null)
                {
                    if (user.Client.Orders != null)
                    {
                        return user.Client.Orders;
                    }
                    else 
                        return null;
                }
                else
                    return null;
            }
            else
                return null; 
        }


    }
}
