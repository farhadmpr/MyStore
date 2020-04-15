using Microsoft.EntityFrameworkCore;
using MyStore.Core.Contracts.Orders;
using MyStore.Core.Domain.Orders;
using MyStore.Infrastructures.Dal.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Infrastructures.Dal.Orders
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly MyStoreContext _ctx;

        public EfOrderRepository(MyStoreContext myStoreContext)
        {
            _ctx = myStoreContext;
        }

        public Order Find(int id)
        {
            return _ctx.Orders.Include(c => c.Lines).ThenInclude(c=>c.Product).FirstOrDefault(c => c.OrderId == id);
        }

        public void SaveOrder(Order order)
        {
            /*
             * با افزودن سفارش نمی خواهیم محصولات داخل آن دوباره در دیتابیس اضافه شوند
             * چون محصولات را داریم یعنی قبلا اضافه شده اند
             * فقط می خواهیم سفارش و خطوط سفارش اضافه شود
             */
            _ctx.AttachRange(order.Lines.Select(l => l.Product));

            if(order.OrderId == 0)
            {
                _ctx.Orders.Add(order);
            }
            _ctx.SaveChanges();
        }

        public void SetPaymentDone(string factorNumber)
        {
            var order = _ctx.Orders.Find(int.Parse(factorNumber));
            if (order != null)
            {
                order.PaymentDate = DateTime.Now;
                _ctx.SaveChanges();
            }
        }

        public void SetTransactionId(int orderId, string token)
        {
            var order = _ctx.Orders.Find(orderId);
            if(order != null)
            {
                order.PaymentId = token;
                _ctx.SaveChanges();
            }
        }
    }
}
