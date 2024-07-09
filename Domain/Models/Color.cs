﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Color
    {
        [Key]
        public string ColorId { get; set; }
        public string Name { get; set; } 

    }
}
