using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Do;

namespace BL.Bo
{
    public class BLCustomer
    {
        public int CustomerId { get; init ; }

        public string? CustomerName { get; set; }

        //public List<Debt> Debts { get; set; } = new List<Debt>();

        //public virtual RegularCustomer? RegularCustomer { get; set; }
    }
}
