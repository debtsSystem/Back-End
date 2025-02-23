using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.DalApi;
using Dal.Do;

namespace Dal.DalImplementation
{
    public class CustomerService:ICustomer
    {
        private dbcontext db;
        public CustomerService(dbcontext db)
        {
            this.db = db;
        }

        public bool Create(Customer item)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

    }
}
