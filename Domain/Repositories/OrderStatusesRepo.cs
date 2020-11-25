using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Demo.Domain.Model;

namespace POS_Demo.Domain.Repositories
{
    public class OrderStatusestatusesRepo : BaseRepository<OrderStatuses>
    {
        public OrderStatusestatusesRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }

        public async Task<IEnumerable<OrderStatuses>> GetAllOrderStatuses()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<OrderStatuses> GetOrderStatuses()
        {
            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
        }
    }
}
