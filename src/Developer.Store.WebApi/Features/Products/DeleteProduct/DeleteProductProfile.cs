using AutoMapper;
using Developer.Store.Application.Products.DeleteProduct;

namespace Developer.Store.WebApi.Features.Products.DeleteProduct
{
    /// <summary>
    /// AutoMapper profile for mapping DeleteProductRequest to DeleteProductCommand.
    /// </summary>
    public class DeleteProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the DeleteProductProfile class.
        /// </summary>
        public DeleteProductProfile()
        {
            CreateMap<Guid, DeleteProductCommand>()
                .ConstructUsing(id => new DeleteProductCommand(id));
        }
    }
}
