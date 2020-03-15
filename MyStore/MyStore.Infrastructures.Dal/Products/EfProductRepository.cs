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

        public Product Find(int productId)
        {
            return _ctx.Products.Find(productId);
        }

        public List<Product> GetProducts(string category, int pageSize = 4, int pageNumber = 1)
        {
            return _ctx.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category)
                .Include(c => c.Category).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        public int TotalCount(string category)
        {
            return _ctx.Products.Count(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category);
        }
    }
}
