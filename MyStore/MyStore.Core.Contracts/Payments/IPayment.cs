using MyStore.Core.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Contracts.Payments
{
    public interface IPayment
    {
        RequestPaymentResult Pay(string amount, string mobile, string factorNumber, string description);
        VerifyPaymentResult Verify(string transId);
    }
}
