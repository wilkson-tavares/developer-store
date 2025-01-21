using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer.Store.Common.Validation;
using Developer.Store.Domain.Common;
using Developer.Store.Domain.Interfaces;
using Developer.Store.Domain.Validation;
using Developer.Store.Domain.ValueObjects;

namespace Developer.Store.Domain.Entities
{
    public class Product : BaseEntity, IProduct
    {
        /// <summary>
        /// Gets the product's title.
        /// Must not be null or empty.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's price.
        /// Must be a positive value.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product's category.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's rating.
        /// </summary>
        public Rating Rating { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the product entity using the ProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
