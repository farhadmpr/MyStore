 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Contracts.Products;
using MyStore.EndPoints.WebUI.Models.Products;

namespace MyStore.EndPoints.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult List(string category, int pageNumber = 1)
        {
            var model = new ProductListViewModel
            {
                Products = _productRepository.GetProducts(category, 2, pageNumber),
                PagingInfo = new Models.Commons.PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPages = 2,
                    TotalItems = _productRepository.TotalCount(category),
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}