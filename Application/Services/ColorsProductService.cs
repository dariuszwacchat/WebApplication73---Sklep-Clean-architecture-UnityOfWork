using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.ColorsProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ColorsProductService : IColorsProductService
    {
        private readonly IUnityOfWork _unityOfWork;

        public ColorsProductService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<ColorProduct>> GetAll ()
        {
            return await _unityOfWork.ColorsProductRepository.GetAll();
        }

        public async Task<ColorProduct> Get (string id)
        {
            return await _unityOfWork.ColorsProductRepository.Get(id);
        }

        public async Task<CreateColorProductViewModel> Create (CreateColorProductViewModel model)
        {
            return await _unityOfWork.ColorsProductRepository.Create(model);
        }


        public async Task<EditColorProductViewModel> Update (EditColorProductViewModel model)
        {
            return await _unityOfWork.ColorsProductRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.ColorsProductRepository.Delete(id);
        }


    }
}
