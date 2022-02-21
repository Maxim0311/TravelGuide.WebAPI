using Microsoft.EntityFrameworkCore;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;
using TravelGuide.Domain.Repository;

namespace TravelGuide.Persistence.EFCore.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext _context;

        public RouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TouristRoute route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();
        }

        public async Task<RouteListResponse<RouteResponse>> GetAll()
        {
            var routes = await _context.Routes
                .Include(r => r.Points)
                .Include(r => r.User)
                .ToListAsync();

            var responseList = routes.Select(r => new RouteResponse
            {
                Id = r.Id,
                Title = r.Title,
                Country = r.Country,
                CreatedDate = r.CreatedDate.ToShortDateString(),
                Rating = r.Rating,
                Author = $"{r.User.LastName} {r.User.FirstName}",
                PointsCount = r.Points.Count
            }).ToList();

            var response = new RouteListResponse<RouteResponse>()
            {
                Items = responseList,
                Count = routes.Count
            };
            
            return response;
        }

        public async Task<TouristRoute?> Get(int id)
        {
            return await _context.Routes.Include(r => r.Points).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Update(TouristRoute route)
        {
            var updateRoute = await _context.Routes.FindAsync(route.Id);
            
            updateRoute.Title = route.Title;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var route = await _context.Routes
                .Include(r => r.Points)
                .FirstOrDefaultAsync(r => r.Id == id);

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
        }
    }
}
