using MyStore.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Contracts.Orders
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
    }
}
