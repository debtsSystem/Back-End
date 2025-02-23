using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class RegularCustomer
{
    public int CustomerId { get; set; }

    public string? Address { get; set; }

    public string? DefaultPhone { get; set; }

    public string? HomePhone { get; set; }

    public string? Fax { get; set; }

    public string? Mail { get; set; }

    public bool? Activy { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
