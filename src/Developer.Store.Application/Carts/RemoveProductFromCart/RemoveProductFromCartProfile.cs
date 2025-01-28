using AutoMapper;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Profile for mapping RemoveProductFromCartCommand to CartProduct and CartProduct to RemoveProductFromCartResult.
    /// </summary>
    public class RemoveProductFromCartProfile : Profile
    {
        public RemoveProductFromCartProfile()
        {
            CreateMap<RemoveProductFromCartCommand, CartProduct>();
            CreateMap<CartProduct, RemoveProductFromCartResult>();
        }
    }
}
