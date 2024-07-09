using Domain.Models.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Clients
{
    public class CreateEditClientViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Imie { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Nazwisko { get; set; }


        [Required(ErrorMessage = "*")]
        public byte [] Photo { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(\d{9}|\d{3}\s\d{3}\s\d{3})$", ErrorMessage = "*")]
        public string Telefon { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Ulica { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string NumerUlicy { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Miejscowosc { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Kraj { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string KodPocztowy { get; set; }


        [Required(ErrorMessage = "*")] 
        public DateTime DataUrodzenia { get; set; }


        [Required(ErrorMessage = "*")]
        public Plec Plec { get; set; }


        [Required(ErrorMessage = "*")]
        public bool Newsletter { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        public RodzajOsoby RodzajOsoby { get; set; }


        public bool HasAccount { get; set; }

        public List <IFormFile> Files { get; set; }

        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
