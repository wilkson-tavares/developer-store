using AutoMapper;
using Developer.Store.Application.Products.Common;
using Developer.Store.Application.Products.GetProducts;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductsCategories
{
    public class GetProductsCategoriesProfile : Profile
    {
        public GetProductsCategoriesProfile()
        {
            CreateMap<Product, GetProductsCategoriesResult>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        }
    }
}
