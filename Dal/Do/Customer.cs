using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Customer
{
    public Customer()
    {
        Debts = new HashSet<Debt>();
    }

    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public virtual ICollection<Debt> Debts { get; set; }

    public virtual RegularCustomer? RegularCustomer { get; set; }
}
