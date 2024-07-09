using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Orders
{
    public class WithoutRegisterOrderViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Imie { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Nazwisko { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Ulica { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^-?\d+$", ErrorMessage = "Wartość pola musi być liczbą całkowitą.")]
        public string NumerUlicy { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Miejscowosc { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Kraj { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Nieprawidłowy format kodu pocztowego")]
        public string KodPocztowy { get; set; }



        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}$|^\d{9}$", ErrorMessage = "Nieprawidłowy format kodu telefonu")]
        public string Telefon { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public DateTime DataUrodzenia { get; set; }
         
         
        public RodzajOsoby RodzajOsoby { get; set; }
        public Plec Plec { get; set; }


        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
