using MyStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Contracts.Products
{
    public interface IProductRepository
    {
        int TotalCount();
        List<Product> GetProducts(int pageSize = 4, int pageNumber = 1);

    }
}
