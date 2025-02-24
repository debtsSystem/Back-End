using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.DalApi;
using Dal.Do;

namespace Dal.DalImplementation
{
    public class SaleService : ISale
    {
        private dbcontext db;
        public SaleService(dbcontext db)
        {
            this.db = db;
        }

        public List<Sale> GetAll()
        {
            return db.Sales.ToList();
        }

        public bool Create(Sale item)
        {
            try
            {
                db.Sales.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public bool Delete(Sale item)
        {
            try
            {
                db.Sales.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public bool Update(Sale item)
        {
            try
            {
                int index = db.Sales.ToList().FindIndex(x => x.SaleId == item.SaleId);
                if (index == -1)
                    throw new Exception("Sale does not exist in DB");
                Sale s = db.Sales.ToList()[index];
                s.SaleName = item.SaleName;
                s.EventTime = item.EventTime;
                db.Sales.ToList()[index] = s;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Sale> Read(Predicate<Sale> filter)
        {
            return db.Sales.ToList().FindAll(x => filter(x));
        }

    }
}
