using Developer.Store.Domain.Enums;

namespace Developer.Store.WebApi.Features.Users.ListUsers
{
    /// <summary>
    /// Represents the result of a GetUsersQuery request.
    /// </summary>
    public class ListUsersResult
    {
        /// <summary>
        /// The unique identifier of the user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user's full name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's phone number
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// The user's role in the system
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// The current status of the user
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
