using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameByIdAsync(Guid gameId);
        Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(Guid gameId);
        Task Save();

    }
}