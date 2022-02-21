

namespace TravelGuide.Domain.Entities
{
    public class TouristRoute
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Country { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Point> Points { get; set; }
    }
}
