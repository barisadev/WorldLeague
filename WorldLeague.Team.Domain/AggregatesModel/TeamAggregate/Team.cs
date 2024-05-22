using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;
using WorldLeague.Team.Domain.AggregatesModel.DrawAggregate;

namespace WorldLeague.Team.Domain.AggregatesModel.TeamAggregate
{
    public class Team: Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Country { get; private set; }

        public IReadOnlyCollection<DrawGroup> Groups { get; private set; }

        public Team(string Name, string Country)
        {
            this.Name = Name;
            this.Country = Country;
        }
    }
}
