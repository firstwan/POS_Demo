using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS_Demo.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace POS_Demo.Domain.Repositories
{
    public class BundleRepo : BaseRepository<Bundle>
    {
        public BundleRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }

        private void FilterBundleId(int BundleId) => _queryBuilder = _queryBuilder.Where(x => x.BundleId == BundleId);


        public async Task<IEnumerable<Bundle>> GetAllBundle()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<Bundle> GetBundle(int BundleId)
        {
            FilterBundleId(BundleId);

            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
            _queryBuilder = _queryBuilder.Include(x => x.Bundle_ProductVariants)
                                        .ThenInclude(x => x.ProductVariant);
        }
    }
}
