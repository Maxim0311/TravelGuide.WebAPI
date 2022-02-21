using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Domain.Repository;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Services;
using TravelGuide.Domain.Models;
using TravelGuide.WebApi.Helpers;

namespace TravelGuide.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _repository;
        private readonly IPointRepository _pointRepository;
        private readonly IRouteService _routeService;

        public RouteController(IRouteRepository repository, 
            IPointRepository pointRepository, 
            IRouteService routeService)
        {
            _repository = repository;
            _pointRepository = pointRepository;
            _routeService = routeService;
        }

        [Authorize]
        [HttpGet("GetAllRoutes")]
        public async Task<ActionResult> GetAllRoutes()
        {
            var routes = await _repository.GetAll();

            return Ok(routes);
        }

        [Authorize]
        [HttpGet("GetRouteById/{id}")]
        public async Task<ActionResult> GetRouteById(int id)
        {
            var route = await _routeService.GetRouteById(id);

            if (route == null)
            {
                return NotFound(new { message = "Данный маршрут не найден" });
            }

            return Ok(route);
        }

        [Authorize]
        [HttpPost("CreateRoute")]
        public async Task<ActionResult> CreateRoute([FromBody] RouteRequest routeRequest)
        {
            try
            {
                await _routeService.CreateRoute(routeRequest);
                return Ok(new { message = "Маршрут успешно создан" });
            } catch (Exception ex)
            {
                return BadRequest(new { message = "Прозошла ошибка" });
            }
        }

        [Authorize]
        [HttpDelete("DeleteRoute/{id}")]
        public async Task<ActionResult> DeleteRoute(int id)
        {
            if (await _routeService.DeleteRoute(id))
            {
                return Ok(new { message = "Маршрут успешно удалён" });
            };

            return BadRequest(new { message = "Произошла ошибка при удалении" });
        }

        [Authorize]
        [HttpDelete("DeletePoint/{id}")]
        public async Task<ActionResult> DeletePoint(int id)
        {
            if (await _routeService.DeletePoint(id))
            {
                return Ok(new { message = "Точка успешно удалена" });
            }
            
            return NotFound(new { message = "Данная точка не найдена" });
        }

        [Authorize]
        [HttpPost("CreatePoint")]
        public async Task<ActionResult> CreatePoint([FromBody] PointRequest pointRequest)
        {
            if (await _routeService.CreatePoint(pointRequest))
            {
                return Ok(new { message = "Точка успешно создана" });
            }
            return NotFound(new { message = $"Маршрут с id ${pointRequest.RouteId} не найден" });
        }
    }
}
