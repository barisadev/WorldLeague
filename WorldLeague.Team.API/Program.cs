using Microsoft.EntityFrameworkCore;
using WorldLeague.Team.API.Apis;
using WorldLeague.Team.Domain.AggregatesModel.DrawAggregate;
using WorldLeague.Team.Domain.AggregatesModel.TeamAggregate;
using WorldLeague.Team.Infrastructure.Context;
using WorldLeague.Team.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TeamContext>(
    options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("WordLeagueDB"), b => b.MigrationsAssembly("WorldLeague.Team.API"))
);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
});

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IDrawRepository, DrawRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("/api/team")
    .MapTeamApi();

app.Run();

