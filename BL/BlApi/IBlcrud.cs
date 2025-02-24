﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bo;

namespace BL.BlApi
{
    public interface IBlcrud<T>
    {
        public List<T> ReadAll();

        public bool Create(T item);

        public bool Delete(int code);

        public bool Update(T item);

        //public <T> Read(Predicate<T> filter);

    }
}
