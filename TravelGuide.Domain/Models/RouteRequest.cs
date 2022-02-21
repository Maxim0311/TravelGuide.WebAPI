
namespace TravelGuide.Domain.Models
{
    public class RouteRequest
    {
        public string Title { get; set; } = "";
        public string Country { get; set; } = "";
        public float Rating { get; set; }
        public int UserId { get; set; }
        public List<PointRequest> Points { get; set; }
    }
}
