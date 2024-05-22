using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Core.SeedWork;
using WorldLeague.Team.Domain.AggregatesModel.DrawAggregate;
using WorldLeague.Team.Infrastructure.EntityConfigurations;
using TeamEntity = WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team;

namespace WorldLeague.Team.Infrastructure.Context
{
    public class TeamContext : DbContext, IUnitOfWork
    {
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<DrawGroup> DrawGroups { get; set; }

        public TeamContext(DbContextOptions<TeamContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("league");
            modelBuilder.ApplyConfiguration(new TeamEntityConfigurations());
            modelBuilder.ApplyConfiguration(new DrawGroupEntityConfigurations());
            modelBuilder.ApplyConfiguration(new DrawEntityConfigurations());

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
