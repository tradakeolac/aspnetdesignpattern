﻿using Agathas.Storefront.Core.Domain;
using Agathas.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Model.Categories
{
    public class Category : EntityBase<int>, IProductAttribute
    {
        public string Name { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
