﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Do;


namespace Dal.DalApi
{
    public interface IPayment:ICrud<PaymentType>
    {
        public List<PaymentType> GetAll();

        public bool Create(PaymentType item);
    }
}
