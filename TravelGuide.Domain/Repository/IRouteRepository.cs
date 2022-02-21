using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;

namespace TravelGuide.Domain.Repository
{
    public interface IRouteRepository
    {
        Task<RouteListResponse<RouteResponse>> GetAll();
        Task<TouristRoute?> Get(int id);
        Task Add(TouristRoute route);
        Task Delete(int id);
        Task Update(TouristRoute route);
    }
}
