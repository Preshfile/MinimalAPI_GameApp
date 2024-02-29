using GameStore.Api.Dtos;

namespace GameStore.Api.Entities;

public static class EntityExtensions 
{
    //creating an extension method for converting a game entity into a DTO
    public static GameDto AsDto(this Games game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleasedDate,
            game.ImageUrl
        );
    }
}