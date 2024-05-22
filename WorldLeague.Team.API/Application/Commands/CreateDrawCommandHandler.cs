using MediatR;
using WorldLeague.Core.SeedWork;
using WorldLeague.Team.Domain.AggregatesModel.DrawAggregate;
using WorldLeague.Team.Domain.AggregatesModel.TeamAggregate;
using TeamEntity = WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team;

namespace WorldLeague.Team.API.Application.Commands
{
    public class CreateDrawCommandHandler : IRequestHandler<CreateDrawCommand, bool>
    {
        private readonly IDrawRepository _repository;
        private readonly ITeamRepository _teamRepository;

        public CreateDrawCommandHandler(IDrawRepository repository, ITeamRepository teamRepository)
        {
            _repository = repository;
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(CreateDrawCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new Draw(
                request.DrawnBy)
                { 
                    Groups = request.Groups.Select(d => new DrawGroup(d.GroupName)
                    {
                        Teams = d.Teams.Select(t => _teamRepository.GetById(t.Id)!).ToList()
                    }).ToList()
                }
            );

            await _repository.UnitOfWork.SaveEntitiesAsync();

            return true;
        }
    }
}
