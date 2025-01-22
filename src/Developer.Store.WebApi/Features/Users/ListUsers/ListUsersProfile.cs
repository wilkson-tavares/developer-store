using AutoMapper;
using Developer.Store.Domain.Entities;

namespace Developer.Store.WebApi.Features.Users.ListUsers
{
    /// <summary>
    /// AutoMapper profile for mapping Product to ListUsersResult.
    /// </summary>
    public class ListUsersProfile : Profile
    {
        public ListUsersProfile()
        {
            CreateMap<User, ListUsersResult>();
        }
    }
}
