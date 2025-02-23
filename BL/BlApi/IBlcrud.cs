using System;
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

    }
}
