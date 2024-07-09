using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientsRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAll ()
        {
            return await _context.Clients
                .Include(i => i.PhotosClient)
                .OrderByDescending (o=> o.DataDodania)
                .ToListAsync();
        }

        public async Task<Client> Get (string id)
        {
            return await _context.Clients
                .Include (i=> i.PhotosClient)
                .FirstOrDefaultAsync(f => f.ClientId == id);
        }
         

        public async Task<CreateClientViewModel> Create (CreateClientViewModel model)
        {
            if (model != null)
            {
                try
                {
                    Client client = new Client ()
                    {
                        ClientId = Guid.NewGuid ().ToString (),
                        Imie = model.Imie,
                        Nazwisko = model.Nazwisko,
                        Ulica = model.Ulica,
                        Miejscowosc = model.Miejscowosc,
                        KodPocztowy = model.KodPocztowy,
                        Kraj = model.Kraj,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        RodzajOsoby = model.RodzajOsoby,
                        Newsletter = model.Newsletter,
                        HasAccount = false,
                        DataDodania = DateTime.Now
                    };
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();

                    // dodanie zdjęcia
                    await CreateNewPhoto (model.Files, client.ClientId);


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

        public async Task<EditClientViewModel> Update (EditClientViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var client = await _context.Clients
                        .Include (i=> i.PhotosClient)
                        .FirstOrDefaultAsync (f=> f.ClientId == model.ClientId);

                    if (client != null)
                    {
                        client.Imie = model.Imie;
                        client.Nazwisko = model.Nazwisko;
                        client.Ulica = model.Ulica;
                        client.Miejscowosc = model.Miejscowosc;
                        client.KodPocztowy = model.KodPocztowy;
                        client.Kraj = model.Kraj;
                        client.Telefon = model.Telefon;
                        client.Email = model.Email;
                        client.RodzajOsoby = model.RodzajOsoby;
                        client.Newsletter = model.Newsletter;

                        _context.Entry(client).State = EntityState.Modified;
                        await _context.SaveChangesAsync();


                        // dodanie zdjęcia
                        await CreateNewPhoto(model.Files, client.ClientId);


                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "Client is null.";
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
                var client = await _context.Clients.FirstOrDefaultAsync (f=>f.ClientId == id);
                if (client != null)
                {

                    // delete photoClient
                    var photosClient = await _context.PhotosClient.Where (w=> w.ClientId == client.ClientId).ToListAsync();
                    foreach (var photoClient in photosClient)
                        _context.PhotosClient.Remove(photoClient);


                    // delete orders
                    var orders = await _context.Orders.Where (w=> w.ClientId == client.ClientId).ToListAsync();
                    foreach (var order in orders) 
                        _context.Orders.Remove(order);


                    // delete client
                    _context.Clients.Remove(client);
                    await _context.SaveChangesAsync();


                    /*var user = await _context.Users.FirstOrDefaultAsync (w=> w.ClientId == client.ClientId);
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();*/


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
