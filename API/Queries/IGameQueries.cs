using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Queries
{
    public interface IGameQueries
    {
        Task<IEnumerable<ReadGameDto>> GetGames();
        Task<ReadGameDto> GetGameById(int id);
        Task<IEnumerable<ReadGameDto>> GetGamesByGenre(string genre);
    }
}