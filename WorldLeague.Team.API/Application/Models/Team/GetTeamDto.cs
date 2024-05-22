using System.Text.Json.Serialization;

namespace WorldLeague.Team.API.Application.Models.Team
{
    public class GetTeamDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Country { get; set; }
    }
}
