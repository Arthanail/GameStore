using System.Threading;
using System.Threading.Tasks;
using API.Commands;
using API.Dtos;
using AutoMapper;
using Data;
using Domain.Entities;
using MediatR;

namespace API.Handlers
{
    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, ReadGameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public UpdateGameHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<ReadGameDto> Handle(UpdateGameCommand request, 
            CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(request);
            await _gameRepository.UpdateGameAsync(game);
            return _mapper.Map<ReadGameDto>(game);
        }
    }
}