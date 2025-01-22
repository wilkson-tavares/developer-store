using FluentValidation;

namespace Developer.Store.WebApi.Features.Products.DeleteProduct
{
    /// <summary>
    /// Validator for DeleteProductRequest that defines validation rules for Product deletion.
    /// </summary>
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteProductRequestValidator with defined validation rules.
        /// </summary>
        public DeleteProductRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Product ID cannot be empty.");
        }
    }
}
