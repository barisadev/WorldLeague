﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldLeague.Team.Infrastructure.Context;

#nullable disable

namespace WorldLeague.Team.API.Migrations
{
    [DbContext(typeof(TeamContext))]
    partial class TeamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("league")
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DrawnBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Draws", "league");
                });

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.DrawGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrawId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrawId");

                    b.ToTable("DrawGroups", "league");
                });

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.DrawGroupTeam", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("DrawGroupTeam", "league");
                });

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams", "league");
                });

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.DrawGroup", b =>
                {
                    b.HasOne("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.Draw", null)
                        .WithMany("Groups")
                        .HasForeignKey("DrawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.DrawGroupTeam", b =>
                {
                    b.HasOne("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.DrawGroup", "DrawGroup")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorldLeague.Team.Domain.AggregatesModel.TeamAggregate.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrawGroup");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WorldLeague.Team.Domain.AggregatesModel.DrawAggregate.Draw", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
