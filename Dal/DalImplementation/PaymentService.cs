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
        private Dbcontext db;
        public PaymentService(Dbcontext db)
        {
            this.db = db;
        }
        public List<Payment> GetAll()
        {
            return db.Payment;
        }
    }
}
