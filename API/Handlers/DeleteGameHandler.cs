using System.Threading;
using System.Threading.Tasks;
using API.Commands;
using AutoMapper;
using Data;
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
            await _gameRepository.DeleteGameAsync(request.Id);
            return true;
        }
    }
}