﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletAssingment.Models
{
    public class IndexViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SelectListItem> OutDestination { get; set; }

        public IEnumerable<SelectListItem> InDestination { get; set; }
    }
}
