﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Onebrb.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public ProductCategory Category { get; set; }

        public int OwnerId { get; set; }
        public Profile Owner { get; set; }
    }
}
