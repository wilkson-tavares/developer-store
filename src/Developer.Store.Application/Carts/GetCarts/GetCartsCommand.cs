using Developer.Store.Application.Carts.GetCart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCarts
{
    /// <summary>
    /// Command for getting a list of carts with pagination and ordering.
    /// </summary>
    public class GetCartsCommand : IRequest<GetCartsResult>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }

        public GetCartsCommand(int page = 1, int size = 10, string? order = null)
        {
            Page = page;
            Size = size;
            Order = order;
        }
    }
}
