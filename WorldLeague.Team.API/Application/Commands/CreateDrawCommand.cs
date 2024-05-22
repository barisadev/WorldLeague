using MediatR;
using WorldLeague.Team.API.Application.Models.Draw;

namespace WorldLeague.Team.API.Application.Commands
{
    public record CreateDrawCommand(string DrawnBy, DrawGroupDto[] Groups): IRequest<bool>
    {
    }
}
