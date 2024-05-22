using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;
using TeamEntity = WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team;

namespace WorldLeague.Team.Domain.AggregatesModel.DrawAggregate
{
    public class DrawGroup : Entity, IAggregateRoot
    {
        public int DrawId { get; set; }
        public string GroupName { get; set; }
        public IReadOnlyCollection<TeamEntity> Teams { get; set; }

        public DrawGroup(string GroupName)
        {
            this.GroupName = GroupName;
        }
    }
}
