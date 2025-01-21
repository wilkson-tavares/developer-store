using AutoMapper;
using Developer.Store.Application.Products.GetProduct;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductByCategory
{
    /// <summary>
    /// Profile for mapping between Product entity and GetProductResult
    /// </summary>
    public class GetProductByCategoryProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct operation
        /// </summary>
        public GetProductByCategoryProfile()
        {
            CreateMap<Product, GetProductByCategoryResult>();
        }
    }
}
