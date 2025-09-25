using Application.DTOs.CustomerAsset;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CustomerAssetMap : Profile
{
    public CustomerAssetMap()
    {
        CreateMap<CustomerAsset, CustomerAssetCreateDTO>().ReverseMap();

        CreateMap<CustomerAsset, CustomerAssetViewDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Name : null))
            .ReverseMap();
    }
}
