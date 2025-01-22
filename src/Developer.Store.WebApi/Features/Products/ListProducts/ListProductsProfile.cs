using AutoMapper;
using Developer.Store.Domain.Entities;
using Developer.Store.WebApi.Features.Products.Common;

namespace Developer.Store.WebApi.Features.Products.ListProducts
{
    /// <summary>
    /// AutoMapper profile for mapping Product to ListProductsResult.
    /// </summary>
    public class ListUsersProfile : Profile
    {
        public ListUsersProfile()
        {
            CreateMap<Product, ListProductsResult>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new Rating { Rate = src.Rating.Rate, Count = src.Rating.Count }));
        }
    }
}
