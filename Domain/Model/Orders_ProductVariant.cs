using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Orders_ProductVariant
    {
        public string OrderId { get; set; }
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public float Discount { get; set; }
        public string Remark { get; set; }


        public virtual Orders Orders { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
