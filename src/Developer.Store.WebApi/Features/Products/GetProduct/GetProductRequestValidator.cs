using Developer.Store.WebApi.Features.Products.GetProduct;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Validator for GetProductRequest
    /// </summary>
    public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetProductRequest
        /// </summary>
        public GetProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
