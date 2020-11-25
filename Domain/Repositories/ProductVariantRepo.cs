using POS_Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Demo.Domain.Repositories
{
    public class ProductVariantRepo : BaseRepository<ProductVariant>
    {
        public ProductVariantRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }

        public async Task<IEnumerable<ProductVariant>> GetAllProductVariant()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<ProductVariant> GetProductVariant()
        {
            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
        }
    }
}
