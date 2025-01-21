using Developer.Store.Application.Users.Common;
using Developer.Store.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        /// <summary>
        /// The unique identifier of the user to update
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of UpdateUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to update</param>
        public UpdateUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
