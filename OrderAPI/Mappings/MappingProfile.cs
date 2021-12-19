using AutoMapper;
using OrderAPI.Domain.Models;
using OrderAPI.DTOs;

namespace OrderApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>();
            CreateMap<ItemsRequest, Items>();
            CreateMap<Items, ItemsResponse>();
        }
    }
}
