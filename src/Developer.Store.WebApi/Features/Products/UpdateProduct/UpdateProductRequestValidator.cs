using Developer.Store.WebApi.Features.Products.UpdateProduct;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// Validator for UpdateProductRequest
    /// </summary>
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for UpdateProductRequest
        /// </summary>
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
