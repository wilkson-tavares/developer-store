using AutoMapper;
using Developer.Store.Application.Products.GetProduct;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProduct
{
    /// <summary>
    /// Profile for mapping between Product entity and GetProductResult
    /// </summary>
    public class GetProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct operation
        /// </summary>
        public GetProductProfile()
        {
            CreateMap<Product, GetProductResult>();
        }
    }
}
