﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Domain.Payments
{
    public class VerifyPaymentResult
    {
        public int Status { get; set; }
        public string Amount{ get; set; }
        public string TransId { get; set; }
        public string FactorNumber { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
        public string CardNumber { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsCorrect => Status == 1;
    }
}
