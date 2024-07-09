using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IUnityOfWork _unityOfWork;

        public ProductsService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Product>> GetAll ()
        {
            return await _unityOfWork.ProductsRepository.GetAll();
        }

        public async Task<Product> Get (string id)
        {
            return await _unityOfWork.ProductsRepository.Get(id);
        }

        public async Task<CreateProductViewModel> Create (CreateProductViewModel model)
        {
            return await _unityOfWork.ProductsRepository.Create(model);
        }


        public async Task<EditProductViewModel> Update (EditProductViewModel model)
        {
            return await _unityOfWork.ProductsRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.ProductsRepository.Delete(id);
        }

    }
}
