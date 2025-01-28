using Developer.Store.Application.Carts.DeleteCart;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.DeleteCart
{
    /// <summary>
    /// Handler for the DeleteCartCommand.
    /// </summary>
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        /// <summary>
        /// Handles the DeleteCartCommand request
        /// </summary>
        /// <param name="request">The DeleteCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The result of the delete operation</returns>
        public async Task<DeleteCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _cartRepository.DeleteCartAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

            return new DeleteCartResponse { Success = true };
        }
    }
}
