﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Marki
{
    public class CreateEditMarkaViewModel
    {
        [Required (ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }



        public bool Success { get; set; }
        public string Result { get; set; }
    }
}