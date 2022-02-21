using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Domain.Models
{
    public class RouteListResponse<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}
