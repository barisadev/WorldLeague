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
    public class DrawEntityConfigurations : IEntityTypeConfiguration<Draw>
    {
        public void Configure(EntityTypeBuilder<Draw> builder)
        {
            builder.ToTable("Draws");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Groups)
                    .WithOne().HasForeignKey(x => x.DrawId);

        }
    }
}
