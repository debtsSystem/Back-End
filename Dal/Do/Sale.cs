using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? EventTime { get; set; }

    public string? SaleName { get; set; }

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();
}
