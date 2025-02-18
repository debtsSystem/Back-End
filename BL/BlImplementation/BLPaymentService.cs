using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BlApi;
using BL.Bo;
using Dal;

namespace BL.BlImplementation
{
    public class BLPaymentService:IBLPayment
    {
        public BLPaymentService(DalManager manager)
        {
            
        }
        public List<BLPayment> ReadAll()
        {
            return new List<BLPayment>();
        }
    }
}
