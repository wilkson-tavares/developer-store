using Developer.Store.Application.Products.GetProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProducts
{
    public class GetProductsCategoriesCommand : IRequest<GetProductsCategoriesResult>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }

        public GetProductsCategoriesCommand(int page = 1, int size = 10, string? order = null)
        {
            Page = page;
            Size = size;
            Order = order;
        }
    }
}
