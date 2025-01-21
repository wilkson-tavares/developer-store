using AutoMapper;
using Developer.Store.Application.Products.Common;
using Developer.Store.Application.Products.GetProducts;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProducts
{
    public class GetProductsCategoriesProfile : Profile
    {
        public GetProductsCategoriesProfile()
        {
            CreateMap<Product, GetProductsCategoriesResult>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<Domain.ValueObjects.Rating, Rating>();
        }
    }
}
