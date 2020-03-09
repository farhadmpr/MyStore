using MyStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.EndPoints.WebUI.Models.Categories
{
    public class NavigationMenuViewModel
    {
        public List<Category> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}
