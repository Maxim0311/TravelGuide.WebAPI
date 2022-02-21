using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;

namespace TravelGuide.Domain.Services
{
    public interface IRouteService
    {
        Task<RouteListResponse<RouteResponse>> GetAllRoutes();
        Task<TouristRoute?> GetRouteById(int id);
        Task CreateRoute(RouteRequest routeRequest);
        Task<bool> DeleteRoute(int routeId);
        Task<bool> DeletePoint(int pointId);
        Task<bool> CreatePoint(PointRequest pointRequest);
    }
}
