using MyStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Core.Domain.Carts
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
