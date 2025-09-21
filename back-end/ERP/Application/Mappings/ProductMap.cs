using Application.DTOs.Product;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class ProductMap : Profile
{
    public ProductMap()
    {
        CreateMap<Product, ProductCreateDTO>().ReverseMap();
        CreateMap<Product, ProductViewDTO>().ReverseMap();
    }
}
