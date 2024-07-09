using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Categories
{
    public class CategoriesViewModel : BaseViewModel <Category>
    {
        public List<Category> Categories { get; set; }
    }
}
