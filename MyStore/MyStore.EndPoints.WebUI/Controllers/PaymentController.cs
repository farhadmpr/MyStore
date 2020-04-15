using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyStore.Core.Contracts.Orders;
using MyStore.Core.Contracts.Payments;
using MyStore.Core.Domain.Payments;

namespace MyStore.EndPoints.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IPayment payment;
        private readonly IConfiguration configuration;

        public PaymentController(IOrderRepository orderRepository, IPayment payment, IConfiguration configuration)
        {
            this.orderRepository = orderRepository;
            this.payment = payment;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult RequestPayment(int orderId)
        {
            var order = orderRepository.Find(orderId);
            var result = payment.Pay(
                order.Lines.Sum(c=>c.Product.Price).ToString(),
                "09140001234",
                order.OrderId.ToString(),
                $"Desctiption {order.OrderId}"
                );
            if (result.IsCorrect)
            {
                orderRepository.SetTransactionId(orderId, result.Token);
                return Redirect($"{configuration["PayIr:PaymentUrl"]}{result.Token}");
            }
            return View(result);
        }

        public IActionResult Verify(RequestPaymentResult result)
        {
            if (result.IsCorrect)
            {
                var verifyResult = payment.Verify(result.Token.ToString());
                if (verifyResult.IsCorrect)
                {
                    orderRepository.SetPaymentDone(verifyResult.FactorNumber);
                    return View("PaymentComplete", verifyResult);
                }
            }
            return View(result);
        }
    }
}