using MediatR;
using WorldLeague.Team.API.Application.Models.Team;

namespace WorldLeague.Team.API.Application.Queries
{
    public class GetTeamsQuery: IRequest<IList<GetTeamDto>>
    {
    }
}
