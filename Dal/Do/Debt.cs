using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Debt
{
    public int DebtsId { get; set; }

    public int? CustomerId { get; set; }

    public int? SumOfDebts { get; set; }

    public int? SaleId { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsPaid { get; set; }

    public string? Notes { get; set; }

    public int? PaymentType { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual PaymentType? PaymentTypeNavigation { get; set; }

    public virtual Sale? Sale { get; set; }
}
