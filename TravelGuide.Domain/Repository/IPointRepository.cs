using TravelGuide.Domain.Entities;

namespace TravelGuide.Domain.Repository
{
    public interface IPointRepository
    {
        Task<IEnumerable<Point>> GetByRouteId(int routeId);
        Task<Point?> Get(int id);
        Task Add(Point point);
        Task Update(Point point);
        Task Delete(int id);
    }
}
