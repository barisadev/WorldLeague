using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;
using WorldLeague.Team.Domain.AggregatesModel.TeamAggregate;
using WorldLeague.Team.Infrastructure.Context;
using TeamEntity = WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team;

namespace WorldLeague.Team.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TeamRepository(TeamContext context)
        {
            _context = context;
        }


        public TeamEntity? GetById(int Id)
        {
            return _context.Teams.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<TeamEntity> GetAll()
        {
            return _context.Teams.AsQueryable();
        }
    }
}
