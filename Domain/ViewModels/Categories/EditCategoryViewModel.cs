﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Categories
{
    public class EditCategoryViewModel : CreateEditCategoryViewModel
    {
        public string CategoryId { get; set; }
    }
}