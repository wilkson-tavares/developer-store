using AutoMapper;
using Developer.Store.Application.Carts.GetCart;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCartProducts
{
    /// <summary>
    /// Handler for the GetCartProductsCommand.
    /// </summary>
    public class GetCartProductsHandler : IRequestHandler<GetCartProductsCommand, GetCartProductsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartProductsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetCartProductsResult> Handle(GetCartProductsCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetCartProductsCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Cart = await _cartRepository.GetCartByIdAsync(request.CartId, cancellationToken);
            if (Cart == null)
                throw new KeyNotFoundException($"Cart with ID {request.CartId} not found");

            var cartProducts = await _cartRepository.GetCartProductsAsync(request.CartId, cancellationToken);
            if (cartProducts is null)
                throw new KeyNotFoundException($"Cart with ID {request.CartId} not found");

            return new GetCartProductsResult { CartProducts = cartProducts };
        }
    }
}
