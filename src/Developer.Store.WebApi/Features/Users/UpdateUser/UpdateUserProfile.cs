using AutoMapper;

namespace Developer.Store.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Profile for mapping UpdateUser feature requests to commands
/// </summary>
public class UpdateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateUser feature
    /// </summary>
    public UpdateUserProfile()
    {
        CreateMap<Guid, Application.Users.UpdateUser.UpdateUserCommand>()
            .ConstructUsing(id => new Application.Users.UpdateUser.UpdateUserCommand(id));
    }
}
