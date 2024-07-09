using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IUnityOfWork _unityOfWork;

        public ClientsService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Client>> GetAll ()
        {
            return await _unityOfWork.ClientsRepository.GetAll();
        }

        public async Task<Client> Get (string id)
        {
            return await _unityOfWork.ClientsRepository.Get(id);
        }

        public async Task<CreateClientViewModel> Create (CreateClientViewModel model)
        {
            return await _unityOfWork.ClientsRepository.Create(model);
        }


        public async Task<EditClientViewModel> Update (EditClientViewModel model)
        {
            return await _unityOfWork.ClientsRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.ClientsRepository.Delete(id);
        }

    }
}
