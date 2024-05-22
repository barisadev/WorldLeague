using WorldLeague.Team.API.Application.Models.Team;

namespace WorldLeague.Team.API.Application.Models.Draw
{
    public class DrawDto
    {
        public DrawGroupDto[] Groups { get; set; }

        public DrawDto(DrawGroupDto[] Groups)
        {
            this.Groups = Groups;
        }
    }

    public class DrawGroupDto
    {
        public string GroupName { get; set; }
        public List<GetTeamDto> Teams { get; set; }

        public DrawGroupDto(string Name)
        {
            this.GroupName = Name;
            this.Teams = [];
        }
    }
}
