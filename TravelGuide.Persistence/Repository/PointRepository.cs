using Microsoft.EntityFrameworkCore;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Repository;

namespace TravelGuide.Persistence.EFCore.Repository
{
    public class PointRepository : IPointRepository
    {
        private readonly AppDbContext _context;

        public PointRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Point point)
        {
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
        }

        public async Task<Point?> Get(int id)
        {
            return await _context.Points.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Point>> GetByRouteId(int routeId)
        {
            return await _context.Points.Where(p => p.RouteId == routeId).ToListAsync();
        }

        public async Task Update(Point point)
        {
            var updatePoint = await _context.Points.FindAsync(point.Id);

            updatePoint.Title = point.Title;
            updatePoint.Latitude = point.Latitude;
            updatePoint.Longitude = point.Longitude;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var point = await _context.Points.FindAsync(id);
            _context.Points.Remove(point);
            await _context.SaveChangesAsync();
        }
    }
}
