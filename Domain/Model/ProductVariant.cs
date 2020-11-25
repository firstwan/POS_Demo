using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class ProductVariant : BaseModel
    {
        public int ProductVariantId { get; set; }
        public int ProductId { get; set; }
        public string VariantName { get; set; }
        public double ProductPrice { get; set; }
        public bool Available { get; set; }



        public virtual ICollection<Bundle_ProductVariant> Bundle_ProductVariants { get; set; }
        public virtual ICollection<Orders_ProductVariant> Orders_ProductVariants { get; set; }
        public virtual Products Products { get; set; }
    }
}
