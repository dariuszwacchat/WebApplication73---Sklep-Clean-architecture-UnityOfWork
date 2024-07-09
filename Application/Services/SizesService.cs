using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Sizes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SizesService : ISizesService
    {
        private readonly IUnityOfWork _unityOfWork;

        public SizesService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Size>> GetAll ()
        {
            return await _unityOfWork.SizesRepository.GetAll();
        }

        public async Task<Size> Get (string id)
        {
            return await _unityOfWork.SizesRepository.Get(id);
        }

        public async Task<CreateSizeViewModel> Create (CreateSizeViewModel model)
        {
            return await _unityOfWork.SizesRepository.Create(model);
        }


        public async Task<EditSizeViewModel> Update (EditSizeViewModel model)
        {
            return await _unityOfWork.SizesRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.SizesRepository.Delete(id);
        }

    }
}
