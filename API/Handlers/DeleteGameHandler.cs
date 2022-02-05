using System.Threading;
using System.Threading.Tasks;
using API.Commands;
using AutoMapper;
using Data;
using Domain.Entities;
using MediatR;

namespace API.Handlers
{
    public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public DeleteGameHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        
        public async Task<bool> Handle(DeleteGameCommand request, 
            CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(request);
            await _gameRepository.DeleteGameAsync(game);
            return true;
        }
    }
}