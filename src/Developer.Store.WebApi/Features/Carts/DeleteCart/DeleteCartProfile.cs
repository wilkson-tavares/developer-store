using AutoMapper;
using Developer.Store.Application.Carts.DeleteCart;

namespace Developer.Store.WebApi.Features.Carts.DeleteCart
{
    /// <summary>
    /// AutoMapper profile for mapping DeleteCartRequest to DeleteCartCommand.
    /// </summary>
    public class DeleteCartProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the DeleteCartProfile class.
        /// </summary>
        public DeleteCartProfile()
        {
            CreateMap<Guid, DeleteCartCommand>()
                .ConstructUsing(id => new DeleteCartCommand(id));
        }
    }
}
