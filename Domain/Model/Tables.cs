using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Tables : BaseModel
    {
        public string TableNumber { get; set; }
        public bool isEmpty { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
