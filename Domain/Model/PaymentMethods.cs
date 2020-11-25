using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class PaymentMethods : BaseModel
    {
        public int PaymentMethodId { get; set; }
        public string MethodName { get; set; }


        public virtual ICollection<Orders> Orders { get; set; }
    }
}
