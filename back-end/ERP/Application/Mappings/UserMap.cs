using Application.DTOs.UserDTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class UserMap : Profile
{
    public UserMap()
    {
        CreateMap<User, UserCreateDTO>().ReverseMap();
        CreateMap<User, UserViewDTO>().ReverseMap();
    }
}
