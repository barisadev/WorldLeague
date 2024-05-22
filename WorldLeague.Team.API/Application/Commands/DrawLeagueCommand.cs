using MediatR;
using WorldLeague.Team.API.Application.Models.Draw;

namespace WorldLeague.Team.API.Application.Commands
{
    public record DrawLeagueCommand(int GroupCount, string DrawnBy): IRequest<DrawDto>
    {
    }
}
