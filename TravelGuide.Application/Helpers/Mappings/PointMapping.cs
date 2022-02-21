using AutoMapper;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Mappings
{
    public class PointMapping : Profile
    {
        public PointMapping()
        {
            CreateMap<PointRequest, Point>();
        }
    }
}
