using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Subcategory
    {
        [Key]
        public string SubcategoryId { get; set; } 
        public string Name { get; set; }
        public string FullName { get; set; } 

        public int IloscOdwiedzin { get; set; }
        public int Kolejnosc { get; set; }
        public SelectedCategory SubcategoryCategory { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }



#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public List <Subsubcategory>? Subsubcategories { get; set; }

    }
}
