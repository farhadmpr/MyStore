using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Domain.Payments
{
    public class RequestPaymentResult
    {
        public int Status { get; set; }
        public string Token { get; set; }

    }
}
