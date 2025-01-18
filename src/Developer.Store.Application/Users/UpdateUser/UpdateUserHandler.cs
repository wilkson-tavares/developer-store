using Developer.Store.Application.Users.UpdateUser;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Users.UpdateUser
{
    /// <summary>
    /// Handler for processing UpdateUserCommand requests
    /// </summary>
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of UpdateUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="validator">The validator for UpdateUserCommand</param>
        public UpdateUserHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handles the UpdateUserCommand request
        /// </summary>
        /// <param name="request">The UpdateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The result of the Update operation</returns>
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _userRepository.UpdateAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            return new UpdateUserResponse { Success = true };
        }
    }
}
