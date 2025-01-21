using Developer.Store.Application.Products.GetProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductsCategories
{
    public class GetProductsCategoriesCommand : IRequest<GetProductsCategoriesResult>
    {

        public GetProductsCategoriesCommand()
        {
        }
    }
}
