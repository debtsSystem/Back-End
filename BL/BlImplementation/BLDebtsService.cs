using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BlApi;
using BL.Bo;
using Dal;
using Dal.Do;

namespace BL.BlImplementation
{
    public class BLDebtsService : IBLDebts
    {

        DalManager Dal;
        public BLDebtsService(DalManager manager)
        {
            this.Dal = manager;
        }

        public List<BLDebts> ReadAll() =>
           CastListToBl(Dal.Debts.GetAll());


        public BLDebts CastingToBl(Debt daldebt)
        {
            BLDebts p = new BLDebts()
            {
                DebtsId = daldebt.DebtsId,
                CustomerId = daldebt.CustomerId,
                SumOfDebts = daldebt.SumOfDebts,
                SaleId = daldebt.SaleId,
                Date = daldebt.Date,
                IsPaid = daldebt.IsPaid,
                Notes = daldebt.Notes,
                PaymentType = daldebt.PaymentType
            };
            return p;
        }

        public List<BLDebts> CastListToBl(List<Debt> list)
        {
            List<BLDebts> lst = new List<BLDebts>();
            list.ForEach(x => lst.Add(CastingToBl(x)));
            return lst;
        }

        public Debt CastingToDal(BLDebts daldebt)
        {
            Debt D = new Debt()
            {
                DebtsId = daldebt.DebtsId,
                CustomerId = daldebt.CustomerId,
                SumOfDebts = daldebt.SumOfDebts,
                SaleId = daldebt.SaleId,
                Date = daldebt.Date,
                IsPaid = daldebt.IsPaid,
                Notes = daldebt.Notes,
                PaymentType = daldebt.PaymentType
            };
            return D;
        }

        public bool Create(BLDebts daldebt)
        {
            return Dal.Debts.Create(CastingToDal(daldebt));
        }

        public bool Delete(int DebtsId)
        {
            return Dal.Debts.Delete(Dal.Debts.GetAll().Find(x => x.DebtsId == DebtsId));
        }

        public bool Update(BLDebts daldebt)
        {
            return Dal.Debts.Update(CastingToDal(daldebt));
        }

        public BLDebts Read(int filter)
        {
            Debt temp = Dal.Debts.GetAll().Find(x => x.DebtsId == filter);
            if (temp == null)
                return null;
            return CastingToBl(temp);
        }

    }
}
