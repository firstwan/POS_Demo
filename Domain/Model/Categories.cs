using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain.Model
{
    public class Categories : BaseModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public virtual ICollection<Products> Products { get; set; }
    }
}
