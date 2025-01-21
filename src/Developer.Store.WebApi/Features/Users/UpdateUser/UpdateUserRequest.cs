namespace Developer.Store.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class UpdateUserRequest
{
    /// <summary>
    /// The unique identifier of the user to Update
    /// </summary>
    public Guid Id { get; set; }
}
