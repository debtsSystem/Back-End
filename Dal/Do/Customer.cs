using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();

    public virtual RegularCustomer? RegularCustomer { get; set; }
}
