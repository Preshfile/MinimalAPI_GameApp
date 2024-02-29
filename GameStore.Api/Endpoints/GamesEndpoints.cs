using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
            .WithParameterValidation();

        //GET endpoint - retrieve all games
        group.MapGet("/", (IGamesRepository repository) =>
            Results.Ok(repository.GetAllGames().Select(game => game.AsDto()))); //transform to DTO object

        //getting a game by its Id 
        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Games? game = repository.Get(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        })
            .WithName(GetGameEndpointName);

        //Create a game 
        group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Games game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleasedDate = gameDto.ReleasedDate,
                ImageUrl = gameDto.ImageUrl
            };

            repository.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        //update a game
        group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Games? existingGame = repository.Get(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.ReleasedDate = updatedGameDto.ReleasedDate;
            existingGame.Price = updatedGameDto.Price;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.ImageUrl = updatedGameDto.ImageUrl;

            repository.Update(existingGame);
            return Results.NoContent();
        });

        //Delete a game
        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            Games? game = repository.Get(id);

            if (game is not null)
            {
                repository.Delete(id);
            }
            return Results.NoContent();
        });

        return group;
    }
}