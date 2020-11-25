using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Bundle : BaseModel
    {
        public int BundleId { get; set; }
        public string BundleName { get; set; }
        public double OriginalPrice { get; set; }
        public double BundlePrice { get; set; }
        public bool Available { get; set; }



        public virtual ICollection<Bundle_ProductVariant> Bundle_ProductVariants { get; set; }
    }
}
