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

        public bool Create(PaymentType item)
        {
            try
            {
                db.PaymentTypes.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public bool Delete(PaymentType item)
        {
            try
            {
                db.PaymentTypes.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public bool Update(PaymentType item)
        {
            try
            {
                int index = db.PaymentTypes.ToList().FindIndex(x => x.PaymentCode == item.PaymentCode);
                if (index == -1)
                    throw new Exception("Catering does not exist in DB");
                PaymentType c = db.PaymentTypes.ToList()[index];
                c.PaymentCode = item.PaymentCode;
                c.TypeOfpayment = item.TypeOfpayment;
                db.PaymentTypes.ToList()[index] = c;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<PaymentType> Read(Predicate<PaymentType> filter)
        {
          return db.PaymentTypes.ToList().FindAll(x => filter(x));
        }
    }
}
