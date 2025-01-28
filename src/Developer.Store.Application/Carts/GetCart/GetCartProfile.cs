using AutoMapper;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCart
{
    /// <summary>
    /// Profile for mapping GetCartQuery to Cart and Cart to GetCartResult.
    /// </summary>
    public class GetCartProfile : Profile
    {
        public GetCartProfile()
        {
            CreateMap<GetCartCommand, Cart>();
            CreateMap<Cart, GetCartResult>();
        }
    }
}
