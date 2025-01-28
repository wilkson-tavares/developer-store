using Developer.Store.WebApi.Features.Products.CreateProduct;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Validator for CreateProductRequest that defines validation rules for Product creation.
    /// </summary>
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
        /// </summary>
        public CreateCartRequestValidator()
        {
            RuleFor(product => product.UserId)
                .NotEmpty().WithMessage("Title cannot be empty.");
        }
    }
}
