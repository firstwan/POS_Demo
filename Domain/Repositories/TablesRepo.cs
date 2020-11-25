using POS_Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Demo.Domain.Repositories
{
    public class TablesRepo : BaseRepository<Tables>
    {
        public TablesRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }

        private void FilterTableNumber(string TableNumber) => _queryBuilder = _queryBuilder.Where(x => x.TableNumber.Equals(TableNumber, StringComparison.OrdinalIgnoreCase));


        public async Task<IEnumerable<Tables>> GetAllTables()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<Tables> GetTables(string TableNumber)
        {
            FilterTableNumber(TableNumber);

            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
        }
    }
}
