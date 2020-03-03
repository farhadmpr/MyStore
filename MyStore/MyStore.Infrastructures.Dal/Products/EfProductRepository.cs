using Microsoft.EntityFrameworkCore;
using MyStore.Core.Contracts.Products;
using MyStore.Core.Domain.Products;
using MyStore.Infrastructures.Dal.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Infrastructures.Dal.Products
{
    public class EfProductRepository : IProductRepository
    {
        private readonly MyStoreContext _ctx;

        public EfProductRepository(MyStoreContext mySotreContext)
        {
            _ctx = mySotreContext;
        }
        public List<Product> GetProducts(int pageSize = 4, int pageNumber = 1)
        {
            return _ctx.Products.Include(c=>c.Category).Skip(pageSize * (pageNumber-1)).Take(pageSize).ToList();
        }

        public int TotalCount()
        {
            return _ctx.Products.Count();
        }
    }
}
