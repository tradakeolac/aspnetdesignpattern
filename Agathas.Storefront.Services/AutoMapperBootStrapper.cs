using Agathas.Storefront.Core.Helpers;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            // Product Title and Product
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductTitle, ProductSummaryView>();
                cfg.CreateMap<ProductTitle, ProductView>();
                cfg.CreateMap<Product, ProductSummaryView>();
                cfg.CreateMap<Product, ProductSizeOption>();
                // Category
                cfg.CreateMap<Category, CategoryView>();
                // IProductAttribute
                cfg.CreateMap<IProductAttribute, Refinement>();
                // Global Money Formatter
                //Mapper.
            });
        }
    }
}
