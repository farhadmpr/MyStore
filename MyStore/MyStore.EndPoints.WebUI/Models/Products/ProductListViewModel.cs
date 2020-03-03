using MyStore.Core.Domain.Products;
using MyStore.EndPoints.WebUI.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.EndPoints.WebUI.Models.Products
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }


    }
}
