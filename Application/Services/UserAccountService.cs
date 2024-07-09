using Application.Services.Abs;
using Data;
using Domain.Models;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager <ApplicationUser> _userManager;
        private readonly SignInManager <ApplicationUser> _signInManager;

        public UserAccountService (ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<List<ApplicationUser>> GetAll ()
        {
            return await _context.Users
                .Include(i => i.Client)
                .OrderBy(o => o.DataDodania)
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById (string userId)
        {
            return await _context.Users
                .Include(i => i.Client)
                    .ThenInclude(t => t.PhotosClient)
                .FirstOrDefaultAsync(f => f.Id == userId);
        }

        public async Task<ApplicationUser> GetUserByEmail (string userEmail)
        {
            return await _context.Users
                .Include(i => i.Client)
                .FirstOrDefaultAsync(f => f.Email == userEmail);
        }

        public async Task<ApplicationUser> GetUserByName (string userName)
        {
            return await _context.Users
                .Include(i => i.Client)
                    .ThenInclude (t=> t.PhotosClient)
                .FirstOrDefaultAsync(f => f.UserName == userName);
        }

        public async Task<ApplicationUser> GetUserByClientId (string clientId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(f => f.ClientId == clientId);
        }


        public async Task<LoginViewModel> Login (LoginViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Email))
            {
                ApplicationUser user = await _context.Users.FirstOrDefaultAsync (f=> f.Email == model.Email);
                if (user != null)
                {
                    var result =  await _signInManager.PasswordSignInAsync (user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        model.UserIsAdmin = await _userManager.IsInRoleAsync(user, "Administrator");
                        model.Result = string.Concat (await _userManager.GetRolesAsync (user));
                        model.IsLoggedIn = true;
                    }
                    else
                    {
                        model.Result = "Nie udało się zalogować.";
                        model.IsLoggedIn = false;
                    }
                }
                else
                {
                    model.Result = "Użytkownik nie istnieje.";
                    model.IsLoggedIn = false;
                }
            }
            return model;
        }

        public async Task Logout ()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterViewModel> Register (RegisterViewModel model)
        {
            if ((await _context.Users.FirstOrDefaultAsync(f => f.Email == model.Email)) == null)
            {
                ApplicationUser user = new ApplicationUser ()
                {
                    Id = Guid.NewGuid ().ToString (),
                    Email = model.Email,
                    UserName = model.Email,
                    IloscZalogowan = 0,
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


                    // dodanie zdjęcia
                    await CreateNewPhoto(model.Files, client.ClientId);


                    user.ClientId = client.ClientId;
                    await _userManager.UpdateAsync(user);


                    // dodanie nowozarejestrowanego użytkownika do ról 
                    // jeżeli żadna rola nie jest wybrana podczas tworzenia nowego użytkownika, wtedy dodawana jest standardowa rola
                    if (model.SelectedRoles.Count == 0)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                    }
                    foreach (var selectedRole in model.SelectedRoles)
                    {
                        await _userManager.AddToRoleAsync(user, selectedRole);
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                    }

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


        public async Task<RegisterShortViewModel> RegisterShort (RegisterShortViewModel model)
        {
            if ((await _context.Users.FirstOrDefaultAsync(f => f.Email == model.Email)) == null)
            {
                ApplicationUser user = new ApplicationUser ()
                {
                    Id = Guid.NewGuid ().ToString (),
                    Email = model.Email,
                    UserName = model.Email,
                    IloscZalogowan = 0,
                    NormalizedUserName = model.Email.ToUpper(),
                    NormalizedEmail = model.Email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid ().ToString (),
                    DataDodania = DateTime.Now
                };

                var result = await _userManager.CreateAsync (user, model.Password);
                if (result.Succeeded)
                { 
                    // stworzenie klienta
                    Client client = new Client ()
                    {
                        ClientId = Guid.NewGuid ().ToString (),
                        Email = user.Email,
                        DataDodania = DateTime.Now
                    };
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();
                     
                    // aktualizacja user, przypisanie do niego klienta
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



        public async Task<ChangeEmailViewModel> ChangeEmail (ChangeEmailViewModel model)
        {
            // Sprawdza czy pola nie są puste
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.NewEmail))
            {
                // wyszukuja użytkownika na podstawie emaila
                if ((await _context.Users.FirstOrDefaultAsync(f => f.Email == model.NewEmail)) == null)
                {
                    ApplicationUser user = await _userManager.FindByNameAsync (model.UserName);
                    if (user != null)
                    {
                        string token = await _userManager.GenerateChangeEmailTokenAsync (user, model.NewEmail);
                        var result = await _userManager.ChangeEmailAsync (user, model.NewEmail, token);
                        if (result.Succeeded)
                        {
                            model.Result = "Email zmieniony poprawnie. Zaloguj się ponownie aby zatwierdzić zmiany.";

                            // zaktualizowanie nazwy użytkownika 
                            user.UserName = model.NewEmail;
                            await _userManager.UpdateAsync(user);
                            await _signInManager.SignOutAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "Coś poszło nie tak.";
                        }
                    }
                }
                else
                {
                    model.Result = "Użytkownik o takim adresie email już istnieje.";
                }
            }
            else
            {
                model.Result = "Some fileds is null.";
            }
            return model;
        }



        public async Task<ChangePasswordViewModel> ChangePassword (ChangePasswordViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserName))
            {
                ApplicationUser user = await _userManager.FindByNameAsync (model.UserName);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync (user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        model.Result = "Hasło zmienione poprawnie.";
                        model.Success = true;

                        // wylogowanie
                        await _signInManager.SignOutAsync();
                    }
                    else
                    {
                        model.Result = "Błędne hasło.";
                    }
                }
                else
                {
                    model.Result = "Wskazany użytkownik nie istnieje.";
                }
            }
            else
            {
                model.Result = "UserName is null.";
            }
            return model;
        }



        // W tej akcji wysyłasz e-mail z linkiem potwierdzającym, zawierającym token.
        public async Task<SendConfirmationViewModel> SendConfirmationEmail (SendConfirmationViewModel model)
        {
            var user = await _userManager.FindByIdAsync (model.Email);
            if (user != null)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync (user);
                string encodedToken = WebEncoders.Base64UrlEncode (Encoding.UTF8.GetBytes (token));

                /*var callbackUrl = Url.Action("ConfirmEmail", "Account",
        new { userId = user.Id, code = encodedToken }, protocol: HttpContext.Request.Scheme);*/

                // Tutaj wyślij e-mail z linkiem potwierdzającym, zawierającym callbackUrl

                model.UserId = user.Id;
                model.Code = encodedToken;
            }
            return model;
        }


        public async Task<ConfirmEmailViewModel> ConfirmEmail (ConfirmEmailViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserId) || !string.IsNullOrEmpty(model.Email))
                model.Result = false;

            var user = await _userManager.FindByIdAsync (model.UserId);
            if (user != null)
            {
                string code = Encoding.UTF8.GetString (WebEncoders.Base64UrlDecode (model.Code));
                var result = await _userManager.ConfirmEmailAsync (user, code);
                if (result.Succeeded)
                {
                    model.Code = code;
                    model.Result = true;
                }
            }
            return model;
        }


        public async Task<UpdateAccountViewModel> UpdateAccount (UpdateAccountViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserId))
            {
                ApplicationUser user = await _context.Users
                    .Include (i=> i.Client)
                        .ThenInclude (t=> t.PhotosClient)
                    .FirstOrDefaultAsync (f=> f.Id == model.UserId);
                if (user != null)
                {
                    user.Email = model.Email; 

                    var result = await _userManager.UpdateAsync (user);
                    if (result.Succeeded)
                    {

                        // Aktualizacja danych Client
                        var client = await _context.Clients
                            .Include (i=> i.PhotosClient)
                            .FirstOrDefaultAsync (f=> f.ClientId == user.ClientId);
                    if (client != null)
                    {
                        client.Email = model.Email;
                        client.Imie = model.Imie;
                        client.Nazwisko = model.Nazwisko;
                        client.Ulica = model.Ulica;
                        client.NumerUlicy = model.NumerUlicy;
                        client.Miejscowosc = model.Miejscowosc;
                        client.KodPocztowy = model.KodPocztowy;
                        client.Kraj = model.Kraj;
                        client.Telefon = model.Telefon;
                        client.DataUrodzenia = model.DataUrodzenia;
                        client.Plec = model.Plec;
                        client.RodzajOsoby = model.RodzajOsoby;

                        _context.Entry(client).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        // dodanie zdjęcia
                        await CreateNewPhoto(model.Files, client.ClientId);
                         }



                        // Usunięcie ze wszystkich rół
                        foreach (var role in await _context.Roles.ToListAsync())
                            await _userManager.RemoveFromRoleAsync(user, role.Name);


                        // Przypisanie nowych ról
                        foreach (var selectedRole in model.SelectedRoles)
                        {
                            await _userManager.AddToRoleAsync(user, selectedRole);
                            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                        }

                        model.Result = "Dane zostały zaktualizowane poprawnie.";
                        model.Success = true;
                    }
                }
            }
            else
            {
                model.Result = "UserId is null.";
            }

            return model;
        } 

        public async Task<UpdateAccountViewModel> UpdateAccountSingle (UpdateAccountViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserId))
            {
                ApplicationUser user = await _context.Users
                    .Include (i=> i.Client)
                        .ThenInclude (t=> t.PhotosClient)
                    .FirstOrDefaultAsync (f=> f.Id == model.UserId);
                if (user != null)
                {
                    user.Email = model.Email;
                    var result = await _userManager.UpdateAsync (user);
                    if (result.Succeeded)
                    {

                        // Aktualizacja danych Client
                        var client = await _context.Clients
                            .Include (i=> i.PhotosClient)
                            .FirstOrDefaultAsync (f=> f.ClientId == user.ClientId);
                        if (client != null)
                        {
                            client.Email = user.Email;
                            client.Imie = model.Imie;
                            client.Nazwisko = model.Nazwisko;
                            client.Ulica = model.Ulica;
                            client.NumerUlicy = model.NumerUlicy;
                            client.Miejscowosc = model.Miejscowosc;
                            client.KodPocztowy = model.KodPocztowy;
                            client.Kraj = model.Kraj;
                            client.Telefon = model.Telefon;
                            client.DataUrodzenia = model.DataUrodzenia;
                            client.Plec = model.Plec;
                            client.RodzajOsoby = model.RodzajOsoby;

                            _context.Entry(client).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            // dodanie zdjęcia
                            await CreateNewPhoto(model.Files, client.ClientId);
                        }

                         
                        if (user.Email != "admin@admin.pl")
                        {
                            // Usunięcie ze wszystkich rół
                            foreach (var role in await _context.Roles.ToListAsync())
                                await _userManager.RemoveFromRoleAsync(user, role.Name);


                            // Przypisanie nowych ról
                            foreach (var selectedRole in model.SelectedRoles)
                            {
                                await _userManager.AddToRoleAsync(user, selectedRole);
                                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                            }
                        }


                        model.Result = "Dane zostały zaktualizowane poprawnie.";
                        model.Success = true;
                    }
                }
            }
            else
            {
                model.Result = "UserId is null.";
            }

            return model;
        }




        public async Task<CreateUserViewModel> CreateUserAccount (CreateUserViewModel model)
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
                    ConcurrencyStamp = Guid.NewGuid ().ToString ()
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


                    // dodanie zdjęcia
                    await CreateNewPhoto(model.Files, client.ClientId);


                    user.ClientId = client.ClientId;
                    await _userManager.UpdateAsync(user);


                    // dodanie nowozarejestrowanego użytkownika do ról 

                    // jeżeli żadna rola nie jest wybrana podczas tworzenia nowego użytkownika, wtedy dodawana jest standardowa rola
                    if (model.SelectedRoles.Count == 0)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                    }
                    else
                    {
                        foreach (var selectedRole in model.SelectedRoles)
                        {
                            await _userManager.AddToRoleAsync(user, selectedRole);
                            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                        }
                    }

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

        public async Task<EditUserViewModel> UpdateUserAccount (EditUserViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserId))
            {
                ApplicationUser user = await _context.Users
                    .Include (i=> i.Client)
                        .ThenInclude (t=> t.PhotosClient)
                    .FirstOrDefaultAsync (f=> f.Id == model.UserId);
                if (user != null)
                {
                    //user.Email = model.Email; 
                    var result = await _userManager.UpdateAsync (user);
                    if (result.Succeeded)
                    {

                        // Aktualizacja danych Client
                        var client = await _context.Clients
                            .Include (i=> i.PhotosClient)
                            .FirstOrDefaultAsync (f=> f.ClientId == user.ClientId);
                        if (client != null)
                        {
                            client.Email = user.Email;
                            client.Imie = model.Imie;
                            client.Nazwisko = model.Nazwisko;
                            client.Ulica = model.Ulica;
                            client.NumerUlicy = model.NumerUlicy;
                            client.Miejscowosc = model.Miejscowosc;
                            client.KodPocztowy = model.KodPocztowy;
                            client.Kraj = model.Kraj;
                            client.Telefon = model.Telefon;
                            client.DataUrodzenia = model.DataUrodzenia;
                            client.Plec = model.Plec;
                            client.RodzajOsoby = model.RodzajOsoby;

                            _context.Entry(client).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            // dodanie zdjęcia
                            await CreateNewPhoto(model.Files, client.ClientId);
                        }



                        // Usunięcie ze wszystkich rół
                        foreach (var role in await _context.Roles.ToListAsync())
                            await _userManager.RemoveFromRoleAsync(user, role.Name);


                        // jeżeli żadna rola nie jest wybrana podczas aktualizacji użytkownika, wtedy dodawana jest standardowa rola
                        if (model.SelectedRoles.Count == 0)
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                        }
                        else
                        {
                            foreach (var selectedRole in model.SelectedRoles)
                            {
                                await _userManager.AddToRoleAsync(user, selectedRole);
                                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                            }
                        }

                        model.Result = "Dane zostały zaktualizowane poprawnie.";
                        model.Success = true;
                    }
                }
            }
            else
            {
                model.Result = "UserId is null.";
            }

            return model;
        }



        public async Task<bool> DeleteAccount (string userId)
        {
            bool deleteResult = false;
            if (!string.IsNullOrEmpty(userId))
            {
                ApplicationUser user = await _userManager.FindByIdAsync (userId);
                if (user != null)
                { 

                    var client = await _context.Clients.FirstOrDefaultAsync (f=> f.ClientId == user.ClientId);
                    if (client != null)
                    {
                        // usunięcie zdjęć
                        var photosClient = await _context.PhotosClient.Where (w=> w.ClientId == client.ClientId).ToListAsync ();
                        foreach (var photoClient in photosClient)
                            _context.PhotosClient.Remove (photoClient);

                        // usunięcie Clienta
                        if (client != null)
                            _context.Clients.Remove(client);
                    }

                    var result =  await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        // Wylogowanie użytkownika
                        //await _signInManager.SignOutAsync();
                        deleteResult = true;
                    }
                }
            }
            return deleteResult;
        }

        public async Task<bool> DeleteAccountByUserName (string userName)
        {
            bool deleteResult = false;

            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    ApplicationUser user = await GetUserByName (userName);
                    if (user != null)
                    {
                        var client = await _context.Clients.FirstOrDefaultAsync (f=> f.ClientId == user.ClientId);
                        if (client != null)
                        {
                            // usunięcie zdjęć
                            var photosClient = await _context.PhotosClient.Where (w=> w.ClientId == client.ClientId).ToListAsync ();
                            foreach (var photoClient in photosClient)
                                _context.PhotosClient.Remove(photoClient);

                            // usunięcie Clienta
                            _context.Clients.Remove(client);
                            await _context.SaveChangesAsync();
                        }


                        IdentityResult result =  await _userManager.DeleteAsync(user);
                        if (result.Succeeded)
                        {
                            // Wylogowanie użytkownika
                            await _signInManager.SignOutAsync();
                            deleteResult = true;
                        }
                    }
                }
            }
            catch { }

            return deleteResult;
        }



        public async Task<bool> DeleteAccountWithoutLogout (string userId)
        {
            bool deleteResult = false;
            ApplicationUser user = await _userManager.FindByIdAsync (userId);
            if (user != null)
            {
                IdentityResult result =  await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    deleteResult = true;
                }
            }
            return deleteResult;
        }


        /// <summary>
        /// Usuwa użytkownika z roli
        /// </summary>
        public async Task<bool> RemoveFromRole (string userName, string roleName)
        {
            bool deleteResult = false;
            ApplicationUser user = await _userManager.FindByNameAsync (userName);
            if (user != null)
            {
                IdentityResult result =  await _userManager.RemoveFromRoleAsync (user, roleName);
                if (result.Succeeded)
                {
                    deleteResult = true;
                }
            }
            return deleteResult;
        }

        /// <summary>
        /// Dodaje użytkownika do roli
        /// </summary>
        public async Task<bool> AddToRole (string userName, string roleName)
        {
            bool result = false;
            ApplicationUser user = await _userManager.FindByNameAsync (userName);
            if (user != null)
            {
                IdentityResult res =  await _userManager.AddToRoleAsync (user, roleName);
                if (res.Succeeded)
                {
                    result = true;
                }
            }
            return result;
        }

        /*public async Task<bool> AddToRole (string userName, string roleName)
        {
            bool result = false;
            ApplicationUser user = await _context.Users.FirstOrDefaultAsync (f=> f.UserName == userName);
            if (user != null)
            {
                var role = await _context.Roles.FirstOrDefaultAsync (f=> f.Name == roleName);
                if (role != null)
                {
                    ApplicationUserRole applicationUserRole = new ApplicationUserRole ()
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    };
                    _context.UserRoles.Add(applicationUserRole);
                    await _context.SaveChangesAsync();
                }
            }
            return result;
        }*/

        /*public async Task<bool> RemoveFromRole (string userName, string roleName)
        {
            bool result = false;
            ApplicationUser user = await _context.Users.FirstOrDefaultAsync (f=> f.UserName == userName);
            ApplicationRole role = await _context.Roles.FirstOrDefaultAsync (f=> f.Name == roleName);
            if (user != null && role != null)
            {
                var applicationUserRole = await _context.UserRoles.FirstOrDefaultAsync (f=> f.UserId == user.Id && f.RoleId == role.Id);
                _context.UserRoles.Remove (applicationUserRole);
                await _context.SaveChangesAsync ();
            }
            return result;
        }*/


        public async Task<bool> AddClaim (string userName, string roleName)
        {
            bool result = false;
            ApplicationUser user = await _userManager.FindByNameAsync (userName);
            if (user != null)
            {
                IdentityResult res =  await _userManager.AddClaimAsync (user, new Claim (ClaimTypes.Role, roleName));
                if (res.Succeeded)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Pobiera wszystkie role danego użytkownika
        /// </summary>
        public async Task<List<string>> GetUserRoles (string userName)
        {
            List <string> userRoles = new List<string> ();
            ApplicationUser user = await _userManager.FindByNameAsync (userName);
            if (user != null)
            {
                userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            }
            return userRoles;
        }



        /// <summary>
        /// Pobiera wszystkich użytkowników będących w danej roli
        /// </summary>
        public async Task<List<ApplicationUser>> GetUsersInRole (string roleName)
        {
            return (await _userManager.GetUsersInRoleAsync(roleName)).ToList();
        }


        /// <summary>
        /// Sprawdza czy zalogowany user jest administratorem, jeśli tak to przekierowuje go do panelu administratora
        /// </summary>
        public async Task<bool> LoggedUserIsAdmin (string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync (f=> f.Email == email);
            if (user != null)
            {
                return await _userManager.IsInRoleAsync(user, "Administrator");
            }
            else
                return false;
        }



        private async Task CreateNewPhoto (List<IFormFile> files, string clientId)
        {
            try
            {
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            byte [] photoData;
                            using (var stream = new MemoryStream())
                            {
                                file.CopyTo(stream);
                                photoData = stream.ToArray();

                                PhotoClient photoClient = new PhotoClient ()
                                {
                                    PhotoClientId = Guid.NewGuid ().ToString (),
                                    PhotoData = photoData,
                                    ClientId = clientId
                                };
                                _context.PhotosClient.Add(photoClient);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            catch { }
        }

    }
}
