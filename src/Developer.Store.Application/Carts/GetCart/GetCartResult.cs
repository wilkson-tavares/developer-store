using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCart
{
    /// <summary>
    /// Result for the GetCartQuery.
    /// </summary>
    public class GetCartResult
    {
        /// <summary>
        /// Gets or sets the retrieved cart.
        /// </summary>
        public ICart Cart { get; set; }
    }
}
