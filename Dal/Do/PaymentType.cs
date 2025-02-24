using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class PaymentType
{
    public int PaymentCode { get; set; }

    public string? TypeOfpayment { get; set; }

    //public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();
}
