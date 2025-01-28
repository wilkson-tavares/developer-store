using AutoMapper;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.AddProductToCart
{
    /// <summary>
    /// Profile for mapping AddProductToCartCommand to CartProduct and CartProduct to AddProductToCartResult.
    /// </summary>
    public class AddProductToCartProfile : Profile
    {
        public AddProductToCartProfile()
        {
            CreateMap<AddProductToCartCommand, CartProduct>();
            CreateMap<CartProduct, AddProductToCartResult>();
        }
    }
}
