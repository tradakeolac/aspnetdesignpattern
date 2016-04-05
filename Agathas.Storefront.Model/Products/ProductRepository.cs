﻿using Agathas.Storefront.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Model.Products
{
    public interface ProductRepository : IReadOnlyRepository<Product,int>
    {
    }
}
