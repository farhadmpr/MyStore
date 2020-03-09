using MyStore.Core.Contracts.Categories;
using MyStore.Core.Domain.Categories;
using MyStore.Infrastructures.Dal.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Infrastructures.Dal.Categories
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly MyStoreContext _ctx;

        public EfCategoryRepository(MyStoreContext mySotreContext)
        {
            _ctx = mySotreContext;
        }

        public List<Category> GetAll()
        {
            return _ctx.Categories.ToList();
        }
    }
}
