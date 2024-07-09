using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Subsubcategories
{
    public class SubsubcategoriesViewModel : BaseViewModel <Subsubcategory>
    {
        public List<Subsubcategory> Subsubcategories { get; set; }
    }
}
