using Developer.Store.Common.Validation;
using Developer.Store.Domain.Common;
using Developer.Store.Domain.Interfaces;
using Developer.Store.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Entities
{
    public class CartProduct : BaseEntity, ICartProduct
    {
        /// <summary>
        /// Gets or sets the cart ID.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public CartProduct(Product product, Cart cart, int quantity)
        {
            Product = product;
            Cart = cart;
            Quantity = quantity;
        }

        /// <summary>
        /// Performs validation of the cart product entity using the CartProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CartProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
