using Domain.Models;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Products
{
    public class CreateEditProductViewModel
    {
        public string ProductId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Description { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Wartość pola musi być liczbą całkowitą lub zmiennoprzecinkową.")]
        public double Price { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^-?\d+$", ErrorMessage = "Wartość pola musi być liczbą całkowitą.")]
        public string Quantity { get; set; }


        //[Required(ErrorMessage = "*")]
        public Dostepnosc Dostepnosc { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Wartość pola musi być liczbą całkowitą lub zmiennoprzecinkową.")]
        public double Znizka { get; set; }


        //[Required(ErrorMessage = "*")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Wartość pola musi być liczbą całkowitą lub zmiennoprzecinkową.")]
        public string Rozmiar { get; set; }


        //[Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Kolor { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string MarkaId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string CategoryId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string SubcategoryId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string SubsubcategoryId { get; set; }


        public List<PhotoProduct> PhotosProduct { get; set; }
        public List<IFormFile> Files { get; set; }


        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
