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
    }
}
