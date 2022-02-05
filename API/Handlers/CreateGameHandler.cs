using System;
using System.Threading;
using System.Threading.Tasks;
using API.Commands;
using API.Dtos;
using API.Services;
using AutoMapper;
using Data;
using Domain.Entities;
using MediatR;
namespace API.Handlers
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, ReadGameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMessageBusClient _messageBusClient;
        private readonly IMapper _mapper;

        public CreateGameHandler(IGameRepository gameRepository, 
            IMessageBusClient messageBusClient, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _messageBusClient = messageBusClient;
            _mapper = mapper;
        }

        public async Task<ReadGameDto> Handle(CreateGameCommand request, 
            CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(request);
            await _gameRepository.AddGameAsync(game);
            var readGameDto = _mapper.Map<ReadGameDto>(game);
            try
            {
                var publishedGameDto = _mapper.Map<PublishedGameDto>(readGameDto);
                _messageBusClient.PublishedNewGame(publishedGameDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not send async: {e.Message}");
            }
            return readGameDto;
        }
    }
}