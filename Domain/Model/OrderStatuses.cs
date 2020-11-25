using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class OrderStatuses : BaseModel
    {
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; }



        public virtual ICollection<Orders> Orders { get; set; }
    }
}
