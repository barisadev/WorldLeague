using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorldLeague.Team.API.Application.Commands;
using WorldLeague.Team.API.Application.Models.Draw;

namespace WorldLeague.Team.API.Apis
{
    public static class TeamApi
    {
        public static RouteGroupBuilder MapTeamApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("draw", Draw)
                .WithName("DrawLeague")
                .WithOpenApi();
            return builder;
        }

        public static async Task<Results<Ok<DrawDto>, BadRequest<string>>> Draw([FromBody] DrawLeagueCommand command, [FromServices] IMediator mediator)
        {
            if(command.GroupCount != 4 && command.GroupCount != 8)
            {
                return TypedResults.BadRequest("The group count can only be 4 or 8");
            }
            var commandResult = await mediator.Send(command);
            return TypedResults.Ok(commandResult);
        }
    }
}
