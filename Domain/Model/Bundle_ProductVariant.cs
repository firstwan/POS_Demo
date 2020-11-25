using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Bundle_ProductVariant
    {
        public int BundleId { get; set; }
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }


        public virtual Bundle Bundle { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

    }
}
