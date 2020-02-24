using MyStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Contracts.Products
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

    }
}
