using AutoMapper;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;
using TravelGuide.Domain.Repository;
using TravelGuide.Domain.Services;
using TravelGuide.Persistence.EFCore;

namespace TravelGuide.Application.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IPointRepository _pointRepository;
        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, 
            IPointRepository pointRepository, 
            IMapper mapper, 
            AppDbContext context)
        {
            _routeRepository = routeRepository;
            _pointRepository = pointRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreatePoint(PointRequest pointRequest)
        {
            var point = _mapper.Map<PointRequest, Point>(pointRequest);

            var route = await _routeRepository.Get(point.RouteId);

            if (route == null)
            {
                return false;
            }

            await _pointRepository.Add(point);
            return true;
        }

        public async Task CreateRoute(RouteRequest routeRequest)
        {
            var route = _mapper.Map<TouristRoute>(routeRequest);

            route.CreatedDate = DateTime.Now;

            await _routeRepository.Add(route);
        }

        public async Task<bool> DeletePoint(int pointId)
        {
            var point = await _pointRepository.Get(pointId);

            if (point == null) return false;

            await _pointRepository.Delete(pointId);
            return true;
        }

        public async Task<bool> DeleteRoute(int routeId)
        {
            var route = await _routeRepository.Get(routeId);

            if (route == null) return false;

            await _routeRepository.Delete(routeId);
            return true;
        }

        public async Task<RouteListResponse<RouteResponse>> GetAllRoutes()
        {
            return await _routeRepository.GetAll();
        }

        public async Task<TouristRoute?> GetRouteById(int id)
        {
            return await _routeRepository.Get(id);
        }
    }
}
