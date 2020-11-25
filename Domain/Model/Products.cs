using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Products : BaseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public bool Available { get; set; }


        public virtual IList<ProductVariant> ProductVariants { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
