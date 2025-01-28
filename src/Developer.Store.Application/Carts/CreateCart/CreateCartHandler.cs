using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.CreateCart
{
    /// <summary>
    /// Handler for the CreateCartCommand.
    /// </summary>
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartRepository _cartRepository;

        public CreateCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CreateCartResult> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart { UserId = request.UserId };
            var createdCart = await _cartRepository.CreateCartAsync(cart);
            return new CreateCartResult { Cart = createdCart };
        }
    }
}
