using System.Threading;
using System.Threading.Tasks;
using API.Dtos;
using API.Queries;
using AutoMapper;
using Data;
using MediatR;

namespace API.Handlers
{
    public class GetGameByIdHandler : IRequestHandler<GetGameByIdQuerie, ReadGameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGameByIdHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<ReadGameDto> Handle(GetGameByIdQuerie request, 
            CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetGameByIdAsync(request.Id);
            return _mapper.Map<ReadGameDto>(game);
        }
    }
}