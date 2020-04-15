using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Domain.Payments
{
    public class RequestPaymentResult
    {
        public int Status { get; set; }
        public string Token { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsCorrect => Status == 1;
    }
}
