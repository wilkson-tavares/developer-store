using Developer.Store.Common.Security;
using Developer.Store.Common.Validation;
using Developer.Store.Domain.Common;
using Developer.Store.Domain.Enums;
using Developer.Store.Domain.Interfaces;
using Developer.Store.Domain.Validation;
using Developer.Store.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Entities
{
    /// <summary>
    /// Represents a shopping cart in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Cart : BaseEntity, ICart
    {
        /// <summary>
        /// Gets or sets the user ID associated with the cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the last update to the cart's information.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the collection of CartProduct.
        /// </summary>
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        /// <summary>
        /// Initializes a new instance of the Cart class.
        /// </summary>
        public Cart()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the cart entity using the CartValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CartValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
