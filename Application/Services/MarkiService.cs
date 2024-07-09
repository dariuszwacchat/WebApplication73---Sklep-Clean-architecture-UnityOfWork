using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Marki;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MarkiService : IMarkiService
    {
        private readonly IUnityOfWork _unityOfWork;

        public MarkiService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Marka>> GetAll ()
        {
            return await _unityOfWork.MarkiRepository.GetAll();
        }

        public async Task<Marka> Get (string id)
        {
            return await _unityOfWork.MarkiRepository.Get(id);
        }

        public async Task<CreateMarkaViewModel> Create (CreateMarkaViewModel model)
        {
            return await _unityOfWork.MarkiRepository.Create(model);
        }


        public async Task<EditMarkaViewModel> Update (EditMarkaViewModel model)
        {
            return await _unityOfWork.MarkiRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.MarkiRepository.Delete(id);
        }

    }
}
