using Developer.Store.Application.Products.GetProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductByCategory
{
    /// <summary>
    /// Validator for GetProductCommand
    /// </summary>
    public class GetProductByCategoryValidator : AbstractValidator<GetProductByCategoryCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetProductCommand
        /// </summary>
        public GetProductByCategoryValidator()
        {
            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Product Category is required");
        }
    }
}
