using Developer.Store.Application.Carts.DeleteCart;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Handler for the RemoveProductFromCartCommand.
    /// </summary>
    public class RemoveProductFromCartHandler : IRequestHandler<RemoveProductFromCartCommand, RemoveProductFromCartResult>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveProductFromCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<RemoveProductFromCartResult> Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveProductFromCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _cartRepository.RemoveProductFromCartAsync(request.CartId, request.ProductId, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Cart with ID {request.CartId} not found");

            return new RemoveProductFromCartResult { Success = true };
        }
    }
}
