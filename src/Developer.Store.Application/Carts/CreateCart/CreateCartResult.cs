using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.CreateCart
{
    /// <summary>
    /// Result for the CreateCartCommand.
    /// </summary>
    public class CreateCartResult
    {
        /// <summary>
        /// Gets or sets the created cart.
        /// </summary>
        public ICart Cart { get; set; }
    }
}
