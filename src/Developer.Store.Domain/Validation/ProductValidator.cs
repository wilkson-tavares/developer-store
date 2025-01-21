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
            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Product title cannot be empty.")
                .MaximumLength(100).WithMessage("Product title cannot be longer than 100 characters.");

            RuleFor(product => product.Description)
                .MaximumLength(500).WithMessage("Product description cannot be longer than 500 characters.");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");

            RuleFor(product => product.Category)
                .NotEmpty().WithMessage("Product category cannot be empty.");

            RuleFor(product => product.Rating)
                .NotNull().WithMessage("Product rating cannot be null.")
                .Must(rating => rating.Rate >= 0 && rating.Rate <= 5)
                .WithMessage("Product rating rate must be between 0 and 5.")
                .Must(rating => rating.Count >= 0)
                .WithMessage("Product rating count must be a non-negative integer.");
        }
    }
}
