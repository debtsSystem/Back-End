using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;

namespace BL.BlApi
{
    public interface IBLSale : IBlcrud<BLSale>
    {
        BLSale Read(int filter);

    }
}
