using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Team.Domain.AggregatesModel.DrawAggregate;

namespace WorldLeague.Team.Infrastructure.EntityConfigurations
{
    public class DrawGroupEntityConfigurations : IEntityTypeConfiguration<DrawGroup>
    {
        public void Configure(EntityTypeBuilder<DrawGroup> builder)
        {
            builder.ToTable("DrawGroups");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Teams)
                    .WithMany(x => x.Groups)
                    .UsingEntity<DrawGroupTeam>(
                        x => x.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamId),
                        x => x.HasOne(x => x.DrawGroup).WithMany().HasForeignKey(x => x.GroupId)
                    );

        }
    }
}
