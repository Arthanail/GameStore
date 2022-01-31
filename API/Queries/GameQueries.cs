using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Data;

namespace API.Queries
{
    public class GameQueries : IGameQueries
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameQueries(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReadGameDto>> GetGames()
        {
            var games = await _gameRepository.GetGamesAsync();
            return _mapper.Map<IEnumerable<ReadGameDto>>(games);
        }

        public async Task<ReadGameDto> GetGameById(int id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            return _mapper.Map<ReadGameDto>(game);
        }

        public async Task<IEnumerable<ReadGameDto>> GetGamesByGenre(string genre)
        {
            var games = await _gameRepository.GetGamesByGenreAsync(genre);
            return _mapper.Map<IEnumerable<ReadGameDto>>(games);
        }
    }
}