using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.DalApi;
using Dal.Do;

namespace Dal.DalImplementation
{
    public class DebtsService : IDebts
    {
        private dbcontext db;
        public DebtsService(dbcontext db)
        {
            this.db = db;
        }

        public bool Create(Debt item)
        {
            try
            {
                db.Debts.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public bool Delete(Debt item)
        {
            try
            {
                db.Debts.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public List<Debt> GetAll()
        {
            return db.Debts.ToList();
        }

        public List<Debt> Read(Predicate<Debt> filter)
        {
            return db.Debts.ToList().FindAll(x => filter(x));
        }

        public bool Update(Debt item)
        {
            try
            {
                int index = db.Debts.ToList().FindIndex(x => x.DebtsId == item.DebtsId);
                if (index == -1)
                    throw new Exception("Debts does not exist in DB");
                Debt d = db.Debts.ToList()[index];
                d.DebtsId = item.DebtsId;
                d.CustomerId = item.CustomerId;
                d.IsPaid = item.IsPaid;
                d.Notes = item.Notes;
                d.Date = item.Date;
                d.SumOfDebts = item.SumOfDebts;
                d.SaleId = item.SaleId;
                d.PaymentType = item.PaymentType;
                db.Debts.ToList()[index] = d;
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
