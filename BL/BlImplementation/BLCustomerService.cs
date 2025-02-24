using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;
using Dal.Do;
using Dal;
using BL.BlApi;
using Dal.DalApi;

namespace BL.BlImplementation
{
    public class BLCustomerService : IBlCustomer
    {
        DalManager Dal;
        public BLCustomerService(DalManager manager)
        {
            this.Dal = manager;
        }


        public List<BLCustomer> ReadAll() =>
            CastListToBl(Dal.Customer.GetAll());


        public BLCustomer CastingToBl(Customer dalcustomer)
        {
            BLCustomer p = new BLCustomer()
            {
                CustomerId = dalcustomer.CustomerId,
                CustomerName = dalcustomer.CustomerName
            };
            return p;
        }

        public List<BLCustomer> CastListToBl(List<Customer> list)
        {
            List<BLCustomer> lst = new List<BLCustomer>();
            list.ForEach(x => lst.Add(CastingToBl(x)));
            return lst;
        }

        public Customer CastingToDal(BLCustomer blcustomer)
        {
            Customer C = new Customer()
            {
                CustomerId = blcustomer.CustomerId,
                CustomerName = blcustomer.CustomerName
            };
            return C;
        }

        public bool Create(BLCustomer blcustomer)
        {
            return Dal.Customer.Create(CastingToDal(blcustomer));
        }

        public bool Delete(int customerId)
        {
            return Dal.Customer.Delete(Dal.Customer.GetAll().Find(x => x.CustomerId == customerId));
        }

        public bool Update(BLCustomer blcustomer)
        {
            return Dal.Customer.Update(CastingToDal(blcustomer));
        }

        public BLCustomer Read(int filter)
        {
            Customer temp = Dal.Customer.GetAll().Find(x => x.CustomerId == filter);
            if (temp == null)
                return null;
            return CastingToBl(temp);
        }
    
}
}
