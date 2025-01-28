using AutoMapper;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCarts
{
    /// <summary>
    /// Profile for mapping GetCartsCommand to Cart and Cart to GetCartsResult.
    /// </summary>
    public class GetCartsProfile : Profile
    {
        public GetCartsProfile()
        {
            CreateMap<GetCartsCommand, Cart>();
            CreateMap<Cart, GetCartsResult>();
        }
    }
}
