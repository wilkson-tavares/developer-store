using AutoMapper;
using Developer.Store.Application.Carts.GetCartProducts;
using Developer.Store.Application.Products.GetProduct;

namespace Developer.Store.WebApi.Features.Carts.ListCartProducts
{
    /// <summary>
    /// Profile for mapping ListCartProducts feature requests to commands
    /// </summary>
    public class ListCartProductsProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct feature
        /// </summary>
        public ListCartProductsProfile()
        {
            CreateMap<ListCartProductsResponse, GetCartProductsCommand>();
        }
    }
}
