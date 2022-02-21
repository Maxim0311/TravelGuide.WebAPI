using AutoMapper;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Mappings
{
    public class RouteMapping : Profile
    {
        public RouteMapping()
        {
            CreateMap<RouteRequest, TouristRoute>();
        }
    }
}
