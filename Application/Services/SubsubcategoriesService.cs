using Application.Services.Abs;
using Data;
using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Subsubcategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubsubcategoriesService : ISubsubcategoriesService
    {
        private readonly IUnityOfWork _unityOfWork;

        public SubsubcategoriesService (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Subsubcategory>> GetAll ()
        {
            return await _unityOfWork.SubsubcategoriesRepository.GetAll();
        }

        public async Task<Subsubcategory> Get (string id)
        {
            return await _unityOfWork.SubsubcategoriesRepository.Get(id);
        }

        public async Task<CreateSubsubcategoryViewModel> Create (CreateSubsubcategoryViewModel model)
        {
            return await _unityOfWork.SubsubcategoriesRepository.Create(model);
        }


        public async Task<EditSubsubcategoryViewModel> Update (EditSubsubcategoryViewModel model)
        {
            return await _unityOfWork.SubsubcategoriesRepository.Update(model);
        }


        public async Task<bool> Delete (string id)
        {
            return await _unityOfWork.SubsubcategoriesRepository.Delete(id);
        }



    }
}
