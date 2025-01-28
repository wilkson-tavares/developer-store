using AutoMapper;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Profile for mapping UpdateProductQuantityInCartCommand to CartProduct and CartProduct to UpdateProductQuantityInCartResult.
    /// </summary>
    public class UpdateProductQuantityInCartProfile : Profile
    {
        public UpdateProductQuantityInCartProfile()
        {
            CreateMap<UpdateProductQuantityInCartCommand, CartProduct>();
            CreateMap<CartProduct, UpdateProductQuantityInCartResult>();
        }
    }
}
