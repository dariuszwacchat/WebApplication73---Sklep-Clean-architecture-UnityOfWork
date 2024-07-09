using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Subcategories
{
    public class SubcategoriesViewModel : BaseViewModel <Subcategory>
    {
        public List<Subcategory> Subcategories { get; set; }
    }
}
