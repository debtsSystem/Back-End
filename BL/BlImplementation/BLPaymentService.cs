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
    public class BLPaymentService : IBLPayment
    {

        DalManager Dal;
        public BLPaymentService(DalManager manager)
        {
            this.Dal = manager;
        }


        public List<BLPayment> ReadAll() =>
            CastListToBl(Dal.Payment.GetAll());


        public BLPayment CastingToBl(PaymentType dalPayment)
        {
            BLPayment p = new BLPayment()
            {
                PaymentId = dalPayment.PaymentCode,
                TypeOfPayment = dalPayment.TypeOfpayment
            };
            return p;
        }

        public List<BLPayment> CastListToBl(List<PaymentType> list)
        {
            List<BLPayment> lst = new List<BLPayment>();
            list.ForEach(x => lst.Add(CastingToBl(x)));
            return lst;
        }

        public PaymentType CastingToDal(BLPayment blpayment)
        {
            PaymentType P = new PaymentType()
            {
                PaymentCode = blpayment.PaymentId,
                TypeOfpayment = blpayment.TypeOfPayment
            };
            return P;
        }

        public bool Create(BLPayment bLPayment)
        {
            return Dal.Payment.Create(CastingToDal(bLPayment));
        }

        public bool Delete(int codePayment)
        {
          return  Dal.Payment.Delete(Dal.Payment.GetAll().Find(x => x.PaymentCode == codePayment));
        }

        public bool Update(BLPayment bLPayment)
        {
            return Dal.Payment.Update(CastingToDal(bLPayment));
        }

        public BLPayment Read(int filter)
        {
            PaymentType temp = Dal.Payment.GetAll().Find(x => x.PaymentCode == filter);
            if (temp == null)
                return null;
            return CastingToBl(temp);
        }
    }
}

