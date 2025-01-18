using Developer.Store.Application.Users.CreateUser;
using Developer.Store.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Developer.Store.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
    }
}