using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

//create an interface
public interface IGamesRepository
{
    void Create(Games game);
    void Delete(int id);
    Games? Get(int id);
    IEnumerable<Games> GetAllGames();
    void Update(Games updatedGame);
}
