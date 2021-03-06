﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Contracts.Orders;
using MyStore.Core.Domain.Carts;
using MyStore.Core.Domain.Orders;

namespace MyStore.EndPoints.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "sorry, your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _orderRepository.SaveOrder(order);
                //TempData["OrderId"] = order.OrderId;
                //TempData["Price"] = order.Lines.Sum(c => c.Product.Price * c.Quantity);
                return RedirectToAction(nameof(Completed), new { Id = order.OrderId });
            }
            else
            {
                return View(order);
            }
        }

        public IActionResult Completed(int id)
        {
            var order = _orderRepository.Find(id);

            if(order == null)
            {
                return NotFound();
            }

            return View(order);
        }


    }
}