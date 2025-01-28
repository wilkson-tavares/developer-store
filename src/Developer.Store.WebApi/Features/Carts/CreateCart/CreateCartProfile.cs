using AutoMapper;
using Developer.Store.Application.Carts.CreateCart;
using Developer.Store.Application.Products.CreateProduct;
using Developer.Store.WebApi.Features.Products.CreateProduct;

namespace Developer.Store.WebApi.Features.Carts.CreateCart
{
    public class CreateCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduct feature
        /// </summary>
        public CreateCartProfile()
        {
            CreateMap<CreateCartRequest, CreateCartCommand>();
            CreateMap<CreateCartRequest, CreateCartResponse>();
        }
    }
}
