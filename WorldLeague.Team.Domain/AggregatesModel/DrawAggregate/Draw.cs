using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;

namespace WorldLeague.Team.Domain.AggregatesModel.DrawAggregate
{
    public class Draw : Entity, IAggregateRoot
    {
        public string DrawnBy { get; set; }
        public IReadOnlyCollection<DrawGroup> Groups { get; set; }

        public Draw(string DrawnBy)
        {

            this.DrawnBy = DrawnBy;
        }
    }
}
