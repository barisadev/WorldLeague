using MediatR;
using System.Text.RegularExpressions;
using WorldLeague.Team.API.Application.Models.Draw;
using WorldLeague.Team.API.Application.Queries;

namespace WorldLeague.Team.API.Application.Commands
{
    public class DrawLeagueCommandHandler : IRequestHandler<DrawLeagueCommand, DrawDto>
    {
        private readonly IMediator _mediator;

        public DrawLeagueCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<DrawDto> Handle(DrawLeagueCommand request, CancellationToken cancellationToken)
        {
            var queryResult = await _mediator.Send(new GetTeamsQuery());

            var teams = queryResult.ToList();

            var rng = new Random();

            teams = teams.OrderBy(_ => rng.Next()).ToList();

            int teamPerGroup = teams.Count / request.GroupCount;
            var groups = Enumerable.Range(0, request.GroupCount).Select(i => new DrawGroupDto(((char)('A' + i)).ToString())).ToArray();


            for (var i = 0; i < teamPerGroup; i++)
            {
                var usedCountries = new Dictionary<string, int>();
                for (var j = 0; j < groups.Length; j++)
                {
                    var group = groups[j];
                    var existingCountries = group.Teams.Select(t => t.Country).Distinct();
                    var team = teams.FirstOrDefault(t => !existingCountries.Contains(t.Country));
                    group.Teams.Add(team);
                    if(usedCountries.ContainsKey(team.Country)) usedCountries[team.Country]++; else usedCountries[team.Country] = 1;
                    teams.Remove(team);

                }
            }

            await _mediator.Send(new CreateDrawCommand(request.DrawnBy, groups));

            var response = new DrawDto(groups);
            return response;
        }
    }
}
