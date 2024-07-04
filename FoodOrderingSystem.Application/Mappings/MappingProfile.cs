using AutoMapper;
using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();

        CreateMap<User, UserDto>().ReverseMap();
    }
}
