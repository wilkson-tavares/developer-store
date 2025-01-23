using Developer.Store.Common.Validation;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Interfaces
{
    public interface ICartProduct
    {
        Product Product { get; }
        int Quantity { get; }

        ValidationResultDetail Validate();
    }
}
