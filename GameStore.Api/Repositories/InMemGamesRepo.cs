using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepo : IGamesRepository //class implementing the interface
{
    private readonly List<Games> games = new()
    {
        new Games(){
            Id = 1,
            Name = "Golo",
            Genre = "Combat",
            Price = 200.20M,
            ReleasedDate = new DateTime(2000/2/6),
            ImageUrl = "https://placeholder.co/100"
        },
        new Games(){
            Id = 2,
            Name = "Danie",
            Genre = "Educational",
            Price = 150.80M,
            ReleasedDate = new DateTime(1998/6/10),
            ImageUrl = "https://placeholder.co/100"
        },
        new Games(){
            Id = 3,
            Name = "Danie",
            Genre = "Educational",
            Price = 150.80M,
            ReleasedDate = new DateTime(1998/6/10),
            ImageUrl = "https://placeholder.co/100"
        }
    };

    public IEnumerable<Games> GetAllGames()
    {
        return games;
    }

    public Games? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Games game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Games updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}