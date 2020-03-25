using MyStore.Core.Domain.Carts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStore.Core.Domain.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage ="please enter a name")]
        public string Name { get; set; }

        public string Line1{ get; set; }
        public string Line2{ get; set; }
        public string City { get; set; }
        public bool GiftWrap { get; set; }


        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Shipped { get; set; }


    }
}
