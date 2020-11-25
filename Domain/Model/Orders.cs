using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Orders : BaseModel
    {
        public string OrderId { get; set; }
        public string TableNumber { get; set; }
        public int OrderStatusId { get; set; }
        public int? PaymentMethodId { get; set; }
        public double TotalPrice { get; set; }
        public double? PaidAmount { get; set; }
        public float? Discount { get; set; }
        public float? Charges { get; set; }



        public virtual ICollection<Orders_ProductVariant> Orders_ProductVariants { get; set; }
        public virtual OrderStatuses OrderStatuses { get; set; }
        public virtual Tables Tables { get; set; }
        public virtual PaymentMethods PaymentMethods { get; set; }
    }
}
