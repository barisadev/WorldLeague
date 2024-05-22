using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;

namespace WorldLeague.Team.Domain.AggregatesModel.TeamAggregate
{
    public interface ITeamRepository: IRepository<Team>
    {
        Team? GetById(int Id);
        IQueryable<Team> GetAll();
    }
}
