using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;
using Dal.Do;
using Dal;
using BL.BlApi;

namespace BL.BlImplementation
{
    public class BLSaleService : IBLSale
    {
        DalManager Dal;
        public BLSaleService(DalManager manager)
        {
            this.Dal = manager;
        }


        public List<BLSale> ReadAll() =>
            CastListToBl(Dal.Sale.GetAll());


        public BLSale CastingToBl(Sale dalSale)
        {
            BLSale p = new BLSale()
            {
                SaleId = dalSale.SaleId,
                SaleName = dalSale.SaleName,
                EventTime = dalSale.EventTime,
            };
            return p;
        }

        public List<BLSale> CastListToBl(List<Sale> list)
        {
            List<BLSale> lst = new List<BLSale>();
            list.ForEach(x => lst.Add(CastingToBl(x)));
            return lst;
        }

        public Sale CastingToDal(BLSale blsale)
        {
            Sale S = new Sale()
            {
                SaleId = blsale.SaleId,
                SaleName = blsale.SaleName,
                EventTime = blsale.EventTime,
            };
            return S;
        }

        public bool Create(BLSale bLSale)
        {
            return Dal.Sale.Create(CastingToDal(bLSale));
        }

        public bool Delete(int codeSale)
        {
            return Dal.Sale.Delete(Dal.Sale.GetAll().Find(x => x.SaleId == codeSale));
        }

        public bool Update(BLSale bLSale)
        {
            return Dal.Sale.Update(CastingToDal(bLSale));
        }

        public BLSale Read(int filter)
        {
            Sale temp = Dal.Sale.GetAll().Find(x => x.SaleId == filter);
            if (temp == null)
                return null;
            return CastingToBl(temp);
        }
    }
}
