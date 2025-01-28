using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Interfaces
{
    public interface ICart
    {
        /// <summary>
        /// Gets or sets the user ID associated with the cart.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets or sets the date and time of the last update to the cart's information.
        /// </summary>
        DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the collection of CartProduct.
        /// </summary>
        ICollection<CartProduct> CartProducts { get; set; }

    }
}
