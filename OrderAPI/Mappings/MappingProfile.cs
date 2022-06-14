using AutoMapper;
using OrderAPI.Domain.Entities;
using OrderAPI.Models;

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
