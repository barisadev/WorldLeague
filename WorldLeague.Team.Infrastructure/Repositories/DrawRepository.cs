using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;
using WorldLeague.Team.Domain.AggregatesModel.DrawAggregate;
using WorldLeague.Team.Infrastructure.Context;

namespace WorldLeague.Team.Infrastructure.Repositories
{
    public class DrawRepository : IDrawRepository
    {

        private readonly TeamContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public DrawRepository(TeamContext context)
        {
            _context = context;
        }

        public Draw Add(Draw draw)
        {
            return _context.Draws.Add(draw).Entity;
        }
    }
}
