using Developer.Store.Domain.Enums;
using Developer.Store.Domain.Validation;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for Product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

        RuleFor(product => product.Description)
            .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Category cannot be empty.")
            .MaximumLength(50).WithMessage("Category cannot be longer than 50 characters.");

        RuleFor(product => product.Image)
            .MaximumLength(255).WithMessage("Image URL cannot be longer than 255 characters.");

        RuleFor(product => product.Rating)
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