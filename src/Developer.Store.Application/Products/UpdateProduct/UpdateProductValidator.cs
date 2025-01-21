using Developer.Store.Application.Products.UpdateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.UpdateProduct
{
    /// <summary>
    /// Validator for UpdateProductCommand
    /// </summary>
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for UpdateProductCommand
        /// </summary>
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
