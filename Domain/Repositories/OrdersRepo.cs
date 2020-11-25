using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Demo.Domain.Model;

namespace POS_Demo.Domain.Repositories
{
    public class OrdersRepo : BaseRepository<Orders>
    {
        public OrdersRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }


        private void FilterOrderId(string OrderId) => _queryBuilder = _queryBuilder.Where(x => x.OrderId.Equals(OrderId, StringComparison.OrdinalIgnoreCase));


        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<Orders> GetOrders(string OrderId)
        {
            FilterOrderId(OrderId);

            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
        }
    }
}
