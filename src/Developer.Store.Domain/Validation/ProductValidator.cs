using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer.Store.Domain.Entities;
using FluentValidation;

namespace Developer.Store.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductId)
                .GreaterThan(0)
                .WithMessage("Product ID must be greater than 0.");

            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Product name must not be empty.");

            RuleFor(product => product.Quantity)
                .GreaterThan(0)
                .WithMessage("Product quantity must be greater than 0.");

            RuleFor(product => product.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Product unit price must be greater than 0.");

            RuleFor(product => product.Discount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product discount must be greater than or equal to 0.");
        }
    }
}
