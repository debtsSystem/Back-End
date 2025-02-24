﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;
using Dal.Do;

namespace BL.BlApi
{
    public interface IBLPayment : IBlcrud<BLPayment>
    {
        BLPayment Read(int filter);
    }
}
