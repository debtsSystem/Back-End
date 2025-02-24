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
            try
            {
                db.Customers.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public bool Delete(Customer item)
        {
            try
            {
                db.Customers.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public List<Customer> Read(Predicate<Customer> filter)
        {
            return db.Customers.ToList().FindAll(x => filter(x));
        }

        public bool Update(Customer item)
        {
            try
            {
                int index = db.Customers.ToList().FindIndex(x => x.CustomerId == item.CustomerId);
                if (index == -1)
                    throw new Exception("Catering does not exist in DB");
                Customer c = db.Customers.ToList()[index];
                c.CustomerId = item.CustomerId;
                c.CustomerName  = item.CustomerName;
                db.Customers.ToList()[index] = c;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
