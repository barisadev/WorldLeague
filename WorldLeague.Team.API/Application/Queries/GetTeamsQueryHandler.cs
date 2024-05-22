using MediatR;
using WorldLeague.Team.API.Application.Models.Team;
using WorldLeague.Team.Domain.AggregatesModel.TeamAggregate;

namespace WorldLeague.Team.API.Application.Queries
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IList<GetTeamDto>>
    {
        private readonly ITeamRepository _repository;

        public GetTeamsQueryHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetTeamDto>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Select(t => new GetTeamDto { Id = t.Id, Name = t.Name, Country = t.Country }).ToList();
        }
    }
}
