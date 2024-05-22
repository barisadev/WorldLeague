using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;

namespace WorldLeague.Team.Domain.AggregatesModel.DrawAggregate
{
    public interface IDrawRepository : IRepository<Draw>
    {
        Draw Add(Draw draw);
    }
}
