using MyStore.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Contracts.Orders
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
        Order Find(int id);
        void SetTransactionId(int orderId, string token);
        void SetPaymentDone(string factorNumber);
    }
}
