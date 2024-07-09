using Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    // Sesje 

     
    /// <summary>
    /// Klasa tworzy idntywidualny klucz sesji dla użytkownika zalogowanego lub anonimowego
    /// </summary>
    public class GetUserNameSession
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserNameSession (IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Pobranie nazwy zalogowanego użytkownika w celach stworzenia indywidualnej sesji dla niego
        /// </summary>
        /// <returns></returns>
        public string GetUserId ()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }







    public class KoszykService : GetUserNameSession
    {
        private const string SessionKeyPrefix = "UserCart_"; 
        public KoszykService (IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }


        public List<KoszykItem> GetAll ()
        {
            string userId = GetUserId();
            List<KoszykItem> deserializeProducts = new List<KoszykItem>();
            try
            {
                string sessionKey = GetSessionKey (userId);
                string shoppingCart = _httpContextAccessor.HttpContext.Session.GetString (sessionKey);
                if (!string.IsNullOrEmpty(shoppingCart))
                    deserializeProducts = JsonConvert.DeserializeObject<List<KoszykItem>>(shoppingCart);
            }
            catch { }

            return deserializeProducts ?? new List<KoszykItem>();
        }

        public void Create (Product product)
        {
            string userId = GetUserId();
            try
            {
                List<KoszykItem> koszykItems = GetAll();

                // Sprawdź, czy produkt już istnieje w koszyku
                var existingItem = koszykItems.FirstOrDefault(item => item.ProductId == product.ProductId);

                if (existingItem != null)
                {
                    // Jeśli produkt już istnieje, zaktualizuj ilość
                    existingItem.Ilosc++;
                    existingItem.Suma += existingItem.Suma;
                }
                else
                {
                    // Jeśli produkt nie istnieje, utwórz nowy element koszyka
                    KoszykItem koszykItem = new KoszykItem()
                    {
                        KoszykItemId = Guid.NewGuid().ToString(),
                        Ilosc = 1,
                        Suma = product.Price,
                        ProductId = product.ProductId,
                        Product = product
                    };

                    koszykItems.Add(koszykItem);
                }

                // Zapisz aktualny koszyk w sesji
                string sessionKey = GetSessionKey (userId);
                string serializeProduct = JsonConvert.SerializeObject(koszykItems);
                _httpContextAccessor.HttpContext.Session.SetString(sessionKey, serializeProduct);
                  
            }
            catch { }
        }


        public void Update (string koszykItemId, int ilosc)
        {
            string userId = GetUserId();
            try
            {
                List<KoszykItem> koszykItems = GetAll(); 
                
                if (ilosc >= 1)
                {
                    // Usuń element o określonym identyfikatorze z koszyka
                    var koszykItem = koszykItems.FirstOrDefault(item => item.KoszykItemId == koszykItemId);
                    if (koszykItem != null)
                    {
                        koszykItem.Ilosc = ilosc;
                        koszykItem.Suma = koszykItem.Product.Price * ilosc;


                        int index = koszykItems.IndexOf (koszykItem);
                        koszykItems[index] = koszykItem;


                        // Zapisz aktualny koszyk w sesji
                        string sessionKey = GetSessionKey (userId);
                        string serializeProduct = JsonConvert.SerializeObject(koszykItems);
                        _httpContextAccessor.HttpContext.Session.SetString(sessionKey, serializeProduct);
                    }
                } 
            }
            catch { }
        }


        public void Delete (string koszykItemId)
        {
            string userId = GetUserId();
            try
            {
                List<KoszykItem> koszykItems = GetAll();

                // Usuń element o określonym identyfikatorze z koszyka
                var koszykItem = koszykItems.FirstOrDefault(item => item.KoszykItemId == koszykItemId);
                if (koszykItem != null)
                {
                    koszykItems.Remove(koszykItem);

                    // Zapisz aktualny koszyk w sesji
                    string sessionKey = GetSessionKey (userId);
                    string serializeProduct = JsonConvert.SerializeObject(koszykItems);
                    _httpContextAccessor.HttpContext.Session.SetString(sessionKey, serializeProduct);
                }
            }
            catch { }
        }


        public void Clear ()
        {
            string userId = GetUserId();
            try
            {
                List<KoszykItem> koszykItems = GetAll();
                koszykItems.Clear();

                // Zapisz aktualny koszyk w sesji
                string sessionKey = GetSessionKey (userId);
                string serializeProduct = JsonConvert.SerializeObject(koszykItems);
                _httpContextAccessor.HttpContext.Session.SetString(sessionKey, serializeProduct);
            }
            catch { }
        }
         


        private string GetSessionKey (string userId)
        {
            return string.IsNullOrEmpty(userId) ? "GuestCart" : SessionKeyPrefix + userId;
        }

    }

     






    public class TempOrderService : GetUserNameSession
    { 
        private const string ClientSession = "ClientSession";
        private const string OrderSession = "OrderSession";

        public TempOrderService (IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }


        /// <summary>
        /// Serializacja obiektu oraz zapisanie go w sesji
        /// </summary>
        public void CreateClient (Client client)
        {
            if (client != null)
            {
                try
                {
                    // Pobierz nazwę zalogowanego użytkownika i pobierz nazwę sesji
                    var userId = GetUserId ();
                    string sessionKeyClient = GetSessionKeyClient (userId);
                    // serializacja obiektu do stringa
                    string serializeClient = JsonConvert.SerializeObject(client);
                    // zapisanie stringa obiektu w sesji
                    _httpContextAccessor.HttpContext.Session.SetString(sessionKeyClient, serializeClient);
                }
                catch { }
            }
        }


        /// <summary>
        /// Pobranie obiektu z zesji
        /// </summary>
        public Client GetClient ()
        {
            // Pobierz nazwę zalogowanego użytkownika i pobierz nazwę sesji
            var userId = GetUserId ();
            string sessionKeyClient = GetSessionKeyClient (userId);
            // pobranie obiektu na podstawie nazwy sesji
            string sessionClient = _httpContextAccessor.HttpContext.Session.GetString (sessionKeyClient);
            if (!string.IsNullOrEmpty(sessionClient))
            {
                return JsonConvert.DeserializeObject<Client>(sessionClient);
            }
            else
                return null;
        }


        /// <summary>
        /// Serializacja obiektu oraz zapisanie go w sesji
        /// </summary>
        public void CreateOrder (Order order)
        {
            if (order != null)
            {
                try
                {
                    // Pobierz nazwę zalogowanego użytkownika i pobierz nazwę sesji
                    var userId = GetUserId ();
                    string sessionKeyOrder = GetSessionKeyOrder (userId);
                    // serializacja obiektu do stringa
                    string serializeOrder = JsonConvert.SerializeObject(order);
                    // zapisanie stringa obiektu w sesji
                    _httpContextAccessor.HttpContext.Session.SetString(sessionKeyOrder, serializeOrder);
                }
                catch { }
            }
        }

        /// <summary>
        /// Pobranie obiektu z zesji
        /// </summary>
        public Order GetOrder ()
        {
            // Pobierz nazwę zalogowanego użytkownika i pobierz nazwę sesji
            var userId = GetUserId ();
            string sessionKeyOrder = GetSessionKeyOrder (userId);
            // pobranie obiektu na podstawie nazwy sesji
            string sessionOrder = _httpContextAccessor.HttpContext.Session.GetString (sessionKeyOrder);
            if (!string.IsNullOrEmpty(sessionOrder))
            {
                return JsonConvert.DeserializeObject<Order>(sessionOrder);
            }
            else
                return null;
        }



        public void ClearAllSessions ()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
         


        /// <summary>
        /// Stworzenie nazwy klucza dla użytkownika anonimowanego lub zalogowanego dla obiektu Client
        /// </summary>
        private string GetSessionKeyClient (string userId)
        {
            return string.IsNullOrEmpty(userId) ? "GuestSessionClient" : ClientSession + userId;
        }

        /// <summary>
        /// Stworzenie nazwy klucza dla użytkownika anonimowanego lub zalogowanego dla obiektu Order
        /// </summary>
        private string GetSessionKeyOrder (string userId)
        {
            return string.IsNullOrEmpty(userId) ? "GuestSessionOrder" : OrderSession + userId;
        }
    }


}