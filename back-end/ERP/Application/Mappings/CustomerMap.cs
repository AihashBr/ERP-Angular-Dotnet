using Application.DTOs.Customer;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CustomerMap : Profile
{
    public CustomerMap()
    {
        CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
        CreateMap<Customer, CustomerViewDTO>()
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.Name : null))
            .ReverseMap();
    }
}
