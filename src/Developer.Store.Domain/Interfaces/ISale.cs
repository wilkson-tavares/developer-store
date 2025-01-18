using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Interfaces
{
    public interface ISale
    {
        int SaleNumber { get; }
        DateTime Date { get; }
        decimal TotalAmount { get; }
        List<IProduct> Products { get; }
        bool Cancelled { get; }
    }
}
