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

namespace Developer.Store.Application.Carts.GetCart
{
    /// <summary>
    /// Handler for the GetCartCommand.
    /// </summary>
    public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetCartResult> Handle(GetCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByIdAsync(request.Id);
            return new GetCartResult { Cart = cart };

            var validator = new GetCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Cart = await _cartRepository.GetCartByIdAsync(request.Id, cancellationToken);
            if (Cart == null)
                throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

            return _mapper.Map<GetCartResult>(Cart);
        }
    }
}
