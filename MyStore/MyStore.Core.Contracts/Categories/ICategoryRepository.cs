using MyStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Contracts.Categories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
