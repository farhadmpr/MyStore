﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Domain.Orders;

namespace MyStore.EndPoints.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout()
        {
            return View(new Order());
        }
    }
}