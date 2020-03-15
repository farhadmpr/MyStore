using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Contracts.Products;
using MyStore.Core.Domain.Carts;
using MyStore.Core.Domain.Products;
using MyStore.EndPoints.WebUI.Infrastructures;
using MyStore.EndPoints.WebUI.Models.Carts;

namespace MyStore.EndPoints.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart _cart;

        public CartController(IProductRepository repo, Cart cart)
        {
            repository = repo;
            _cart = cart;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = repository.Find(productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }


    }
}