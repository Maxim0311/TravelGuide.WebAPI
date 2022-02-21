using System.Text.Json.Serialization;


namespace TravelGuide.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public virtual List<TouristRoute> Routes { get; set; }
    }
}
