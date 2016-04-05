using ASPPatterns.Chap3.Layered.Model;
using ASPPatterns.Chap3.Layered.Repository;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPPatterns.Chap3.Layered.WebUI
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ProductRegistry>();
            });
        }
    }

    public class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            this.For<IProductRepository>().Use<ProductRepository>();
        }
    }
}