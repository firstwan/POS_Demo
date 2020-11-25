using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Demo.Domain
{
    public class BaseModel
    {
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
