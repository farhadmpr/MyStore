using Microsoft.Extensions.Configuration;
using MyStore.Core.Contracts.Payments;
using MyStore.Core.Domain.Payments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MyStore.Services.ApplicationServices.Payments
{
    public class PayIrPayment : IPayment
    {
        private readonly IConfiguration configuration;

        public PayIrPayment(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public RequestPaymentResult Pay(string amount, string mobile, string factorNumber, string description)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> postValues = new Dictionary<string, string>();
            
            postValues.Add("api", configuration["PayIr:ApiKey"]);
            postValues.Add("amount", amount);
            postValues.Add("redirect", configuration["PayIr:RedirectUrl"]);
            postValues.Add("mobile", mobile);
            postValues.Add("factorNumber", factorNumber);
            postValues.Add("description", description);

            var content = new FormUrlEncodedContent(postValues);
            var response = client.PostAsync(configuration["PayIr:RequestUrl"], content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RequestPaymentResult>(responseString);
        }

        public VerifyPaymentResult Verify(string transId)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> postValues = new Dictionary<string, string>();
            postValues.Add("api", configuration["PayIr:ApiKey"]);
            postValues.Add("token", transId);

            try
            {
                var content = new FormUrlEncodedContent(postValues);
                var response = client.PostAsync(configuration["PayIr:PaymentVerify"], content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<VerifyPaymentResult>(responseString);
            }
            catch (Exception)
            {
                return new VerifyPaymentResult();
            }
        }
    }
}
