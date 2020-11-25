using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Demo.Domain.Model;

namespace POS_Demo.Domain.Repositories
{
    public class ProductsRepo : BaseRepository<Products>
    {
        public ProductsRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }

        private void FilterProductId(int ProductId) => _queryBuilder = _queryBuilder.Where(x => x.ProductId == ProductId);


        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<Products> GetProducts(int ProductId)
        {
            FilterProductId(ProductId);

            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
        }
    }
}
