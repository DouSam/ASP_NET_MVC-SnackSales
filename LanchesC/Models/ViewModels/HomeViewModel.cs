﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> PreferredSnacks { get; set; }
    }
}