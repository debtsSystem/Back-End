using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.DalApi;
using Dal.Do;

namespace Dal.DalImplementation
{
    public class PaymentService : IPayment
    {
        private dbcontext db;
        public PaymentService(dbcontext db)
        {
            this.db = db;
        }
        public List<PaymentType> GetAll()
        {
            return db.PaymentTypes.ToList();
        }
    }
}
