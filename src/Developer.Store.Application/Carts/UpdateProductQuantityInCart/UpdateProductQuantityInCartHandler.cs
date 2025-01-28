using Developer.Store.Application.Products.UpdateProduct;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Handler for the UpdateProductQuantityInCartCommand.
    /// </summary>
    public class UpdateProductQuantityInCartHandler : IRequestHandler<UpdateProductQuantityInCartCommand, UpdateProductQuantityInCartResult>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateProductQuantityInCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<UpdateProductQuantityInCartResult> Handle(UpdateProductQuantityInCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductQuantityInCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cartProduct = await _cartRepository.UpdateProductQuantityInCartAsync(request.CartId, request.ProductId, request.Quantity, cancellationToken);
            return new UpdateProductQuantityInCartResult { CartProduct = cartProduct };
        }
    }
}
