using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Demo.Domain.Model;

namespace POS_Demo.Domain.Repositories
{
    public class PaymentMethodsRepo : BaseRepository<PaymentMethods>
    {
        public PaymentMethodsRepo(AppDBContext DBcontext) : base(DBcontext)
        {
        }


        private void FilterPaymentMethodId(int PaymentMethodId) => _queryBuilder = _queryBuilder.Where(x => x.PaymentMethodId == PaymentMethodId);

        public async Task<IEnumerable<PaymentMethods>> GetAllPaymentMethods()
        {
            LinkedData();
            return await ReturnAllResult();
        }

        public async Task<PaymentMethods> GetPaymentMethods(int PaymentMethodId)
        {
            FilterPaymentMethodId(PaymentMethodId);

            LinkedData();
            return await ReturnSingleRerult();
        }


        public void LinkedData()
        {
        }
    }
}
