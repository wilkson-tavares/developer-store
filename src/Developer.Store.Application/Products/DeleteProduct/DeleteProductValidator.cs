using Developer.Store.Application.Products.DeleteProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.DeleteProduct
{
    /// <summary>
    /// Validator for DeleteProductCommand
    /// </summary>
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteProductCommand
        /// </summary>
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
