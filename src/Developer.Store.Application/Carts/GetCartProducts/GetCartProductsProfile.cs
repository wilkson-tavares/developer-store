using AutoMapper;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCartProducts
{
    /// <summary>
    /// Profile for mapping GetCartProductsCommand to CartProduct and CartProduct to GetCartProductsResult.
    /// </summary>
    public class GetCartProductsProfile : Profile
    {
        public GetCartProductsProfile()
        {
            CreateMap<GetCartProductsCommand, CartProduct>();
            CreateMap<CartProduct, GetCartProductsResult>();
        }
    }
}
