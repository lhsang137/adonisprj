﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.ViewModels.Request
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }

        public decimal? Price { get; set; }

    }
}
