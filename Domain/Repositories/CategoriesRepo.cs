using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Demo.Domain.Model;

namespace POS_Demo.Domain.Repositories
{
    public class CategoriesRepo : BaseRepository<Categories>
    {
        public CategoriesRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }

        private void FilterCategoryId(int CategoryId) => _queryBuilder = _queryBuilder.Where(x => x.CategoryId == CategoryId);



        public async Task<IEnumerable<Categories>> GetAllCategories() 
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<Categories> GetCategories(int CategoryId)
        {
            FilterCategoryId(CategoryId);

            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
            _queryBuilder = _queryBuilder
                            .Include(x => x.Products)
                                .ThenInclude(x => x.ProductVariants);
        }
    }
}
