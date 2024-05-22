using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamEntity = WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team;

namespace WorldLeague.Team.Domain.AggregatesModel.DrawAggregate
{
    public class DrawGroupTeam
    {
        public int GroupId { get; set; }
        public int TeamId { get; set; }

        public DrawGroup DrawGroup { get; private set; }
        public TeamEntity Team { get; private set; }
    }
}
