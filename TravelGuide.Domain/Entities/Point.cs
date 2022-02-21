using System.Text.Json.Serialization;

namespace TravelGuide.Domain.Entities
{
    public class Point
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [JsonIgnore]
        public int RouteId { get; set; }
        [JsonIgnore]
        public TouristRoute? Route { get; set; }
    }
}
