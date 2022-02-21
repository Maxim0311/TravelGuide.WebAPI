using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Domain.Models
{
    public class RouteResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public float Rating { get; set; }
        public string CreatedDate { get; set; }
        public string Author { get; set; }
        public int PointsCount { get; set; }
    }
}
