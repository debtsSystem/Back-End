using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Do;

namespace BL.Bo
{
    public class BLDebts
    {
        public int DebtsId { get; set; }

        public int? CustomerId { get; set; }

        public int? SumOfDebts { get; set; }

        public int? SaleId { get; set; }

        public DateTime? Date { get; set; }

        public bool? IsPaid { get; set; }

        public string? Notes { get; set; }

        public int? PaymentType { get; set; }

        //public virtual Customer? Customer { get; set; }

        //public virtual PaymentType? PaymentTypeNavigation { get; set; }

        //public virtual Sale? Sale { get; set; }
    }
}
