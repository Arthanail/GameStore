using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(Game game);
    }
}