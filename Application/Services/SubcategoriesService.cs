using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Categories;
using Domain.ViewModels.Subcategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly IUnityOfWork _unityOfWork;

        public SubcategoriesService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Subcategory>> GetAll ()
        {
            return await _unityOfWork.SubcategoriesRepository.GetAll();
        }

        public async Task<Subcategory> Get (string id)
        {
            return await _unityOfWork.SubcategoriesRepository.Get(id);
        }

        public async Task<CreateSubcategoryViewModel> Create (CreateSubcategoryViewModel model)
        {
            return await _unityOfWork.SubcategoriesRepository.Create(model);
        }


        public async Task<EditSubcategoryViewModel> Update (EditSubcategoryViewModel model)
        {
            return await _unityOfWork.SubcategoriesRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.SubcategoriesRepository.Delete(id);
        }

    }
}
