using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;

namespace BL.BlApi
{
    public interface IBlCustomer : IBlcrud<BLCustomer>
    {
        BLCustomer Read(int filter);
    }
}
