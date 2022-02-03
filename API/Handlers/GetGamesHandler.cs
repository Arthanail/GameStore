using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Dtos;
using API.Queries;
using AutoMapper;
using Data;
using MediatR;

namespace API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesQuerie, IEnumerable<ReadGameDto>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGamesHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadGameDto>> Handle(GetGamesQuerie request, 
            CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetGamesAsync();
            return _mapper.Map<IEnumerable<ReadGameDto>>(games);
        }
    }
}