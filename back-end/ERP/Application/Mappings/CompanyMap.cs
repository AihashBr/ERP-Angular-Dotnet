using Application.DTOs.Company;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CompanyMap : Profile
{
    public CompanyMap()
    {
        CreateMap<Company, CompanyCreateDTO>().ReverseMap();
        CreateMap<Company, CompanyViewDTO>().ReverseMap();
    }
}