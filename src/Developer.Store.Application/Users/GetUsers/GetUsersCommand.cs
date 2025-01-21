using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Users.GetUsers
{
    public class GetUsersCommand : IRequest<GetUsersResult>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }

        public GetUsersCommand(int page = 1, int size = 10, string? order = null)
        {
            Page = page;
            Size = size;
            Order = order;
        }
    }
}
