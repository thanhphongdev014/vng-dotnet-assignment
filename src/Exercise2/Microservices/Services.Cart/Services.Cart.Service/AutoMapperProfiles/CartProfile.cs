using AutoMapper;
using Services.Cart.EntityFrameworkCore.Models;
using Services.Cart.Service.DTOs;

namespace Services.Product.Service.AutoMapperProfiles;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CartModel, CartDto>();
    }
}
