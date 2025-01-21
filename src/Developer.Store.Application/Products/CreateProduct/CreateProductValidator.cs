using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(command => command.Description)
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

            RuleFor(command => command.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(command => command.Category)
                .NotEmpty().WithMessage("Category cannot be empty.")
                .MaximumLength(50).WithMessage("Category cannot be longer than 50 characters.");

            RuleFor(command => command.Image)
                .MaximumLength(255).WithMessage("Image URL cannot be longer than 255 characters.");

            RuleFor(command => command.Rating)
                .NotNull().WithMessage("Rating cannot be null.")
                .ChildRules(rating =>
                {
                    rating.RuleFor(r => r.Rate)
                        .InclusiveBetween(0, 5).WithMessage("Rate must be between 0 and 5.");
                    rating.RuleFor(r => r.Count)
                        .GreaterThanOrEqualTo(0).WithMessage("Count must be a non-negative integer.");
                });
        }
    }
}
