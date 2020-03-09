using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Contracts.Categories;
using MyStore.EndPoints.WebUI.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.EndPoints.WebUI.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public NavigationMenuViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new NavigationMenuViewModel
            {
                Categories = _categoryRepository.GetAll(),                
            };

            if (RouteData?.Values.ContainsKey("category") == true)
            {
                model.CurrentCategory = RouteData?.Values["category"].ToString();
            }

            return View(model);
        }

    }
}
