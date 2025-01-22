using AutoMapper;

namespace Developer.Store.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// Profile for mapping UpdateProduct feature requests to commands
    /// </summary>
    public class UpdateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateProduct feature
        /// </summary>
        public UpdateProductProfile()
        {
            CreateMap<Guid, Application.Products.UpdateProduct.UpdateProductCommand>()
                .ConstructUsing(id => new Application.Products.UpdateProduct.UpdateProductCommand(id));
        }
    }
}
