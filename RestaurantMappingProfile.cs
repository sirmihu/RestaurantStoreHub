﻿using AutoMapper;
using RestaurantStoreHub.Entities;
using RestaurantStoreHub.Models;

namespace RestaurantStoreHub
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, 
                    c => c.MapFrom(dto => new Address() 
                        { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));
        }
    }
}
