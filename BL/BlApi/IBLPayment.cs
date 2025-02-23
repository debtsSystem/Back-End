using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;
using Dal.Do;

namespace BL.BlApi
{
    public interface IBLPayment
    {
        public List<BLPayment> ReadAll();

        public bool Create(BLPayment bLPayment);

    }
}
