
namespace TravelGuide.Domain.Models
{
    public class PointRequest
    {
        public string Title { get; set; } = "";
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int RouteId { get; set; }
    }
}
