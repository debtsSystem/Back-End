﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface ICrud<T>
    {
        public List<T> GetAll();

        public bool Create(T item);
    }
}
