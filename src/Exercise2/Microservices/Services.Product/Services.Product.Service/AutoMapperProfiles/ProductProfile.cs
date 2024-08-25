using AutoMapper;
using Services.Product.EntityFrameworkCore.Models;
using Services.Product.Service.DTOs;

namespace Services.Product.Service.AutoMapperProfiles;

public class ProductAutoMapperProfile : Profile
{
    public ProductAutoMapperProfile()
    {
        CreateMap<ProductModel, ProductDto>();
        CreateMap<ProductDto, CreateProductDto>();
        CreateMap<ProductDto, UpdateProductDto>();
    }
}
