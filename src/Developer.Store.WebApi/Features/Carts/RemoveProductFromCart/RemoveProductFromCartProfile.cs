using AutoMapper;
using Developer.Store.Application.Carts.DeleteCart;
using Developer.Store.Application.Carts.RemoveProductFromCart;

namespace Developer.Store.WebApi.Features.Carts.RemoveCartFromCart
{
    /// <summary>
    /// AutoMapper profile for mapping DeleteCartRequest to DeleteCartCommand.
    /// </summary>
    public class RemoveCartFromCartProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the RemoveCartFromCartProfile class.
        /// </summary>
        public RemoveCartFromCartProfile()
        {
            CreateMap<Guid, RemoveProductFromCartCommand>();
        }
    }
}
