using System;
using System.Collections.Generic;

namespace entityFramework.Data.DBFirst;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
