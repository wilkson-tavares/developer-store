using AutoMapper;
using Developer.Store.Application.Users.Common;
using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Users.GetUsers
{
    public class GetUsersProfile : Profile
    {
        public GetUsersProfile()
        {
            CreateMap<User, GetUsersResult>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<Domain.ValueObjects.Name, Name>();
            CreateMap<Domain.ValueObjects.Address, Address>();
            CreateMap<Domain.ValueObjects.Geolocation, Geolocation>();
        }
    }
}
