﻿using Agathas.Storefront.Core.Domain;
using Agathas.Storefront.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Model.Products
{
    public class ProductTitle : EntityBase<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ProductColor Color { get; set; }
        public IEnumerable<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
