using AutoMapper;
using Developer.Store.Application.Products.CreateProduct;
using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Developer.Store.Application.Carts.AddProductToCart
{
    /// <summary>
    /// Handler for the AddProductToCartCommand.
    /// </summary>
    public class AddProductToCartHandler : IRequestHandler<AddProductToCartCommand, AddProductToCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public AddProductToCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<AddProductToCartResult> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductToCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = _mapper.Map<CartProduct>(request);
            var createdProduct = await _cartRepository.AddProductToCartAsync(cart.CartId, cart.ProductId, cart.Quantity, cancellationToken);
            var result = _mapper.Map<AddProductToCartResult>(createdProduct);
            return result;
        }
    }
}
