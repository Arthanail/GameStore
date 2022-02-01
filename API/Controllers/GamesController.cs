using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Queries;
using API.Services;
using AutoMapper;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameQueries _gameQueries;
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IMessageBusClient _messageBusClient;

        public GamesController(IGameQueries gameQueries, IMapper mapper, 
            IGameRepository gameRepository, IMessageBusClient messageBusClient)
        {
            _gameQueries = gameQueries;
            _mapper = mapper;
            _gameRepository = gameRepository;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadGameDto>>> GetGamesAsync()
        {
            var games = await _gameQueries.GetGames();
            return Ok(games);
        }
        
        [HttpGet("{id}", Name = "GetGameByIdAsync")]
        public async Task<ActionResult<ReadGameDto>> GetGameByIdAsync(int id)
        {
            var game = await _gameQueries.GetGameById(id);
            return Ok(game);
        }

        [HttpGet]
        [Route("genre/{genre}")]
        public async Task<ActionResult<IEnumerable<ReadGameDto>>> GetGamesByGenreAsync(string genre)
        {
            var games = await _gameQueries.GetGamesByGenre(genre);
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult<CreateGameDto>> AddGameAsync(CreateGameDto createGameDto)
        {
            var game = _mapper.Map<Game>(createGameDto);
            await _gameRepository.AddGameAsync(game);

            var readGameDto = _mapper.Map<ReadGameDto>(game);
            try
            {
                var publishedGameDto = _mapper.Map<PublishedGameDto>(readGameDto);
                publishedGameDto.Event = "Game_Published";
                _messageBusClient.PublishedNewGame(publishedGameDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not send async: {e.Message}");
            }
            return CreatedAtRoute(nameof(GetGameByIdAsync), new { Id = readGameDto.Id }, readGameDto);
        }
 
        [HttpPut]
        public async Task<ActionResult<UpdateGameDto>> UpdateGameAsync(UpdateGameDto updateGameDto)
        {
            var game = _mapper.Map<Game>(updateGameDto);
            await _gameRepository.UpdateGameAsync(game);

            var readGameDto = _mapper.Map<ReadGameDto>(game);
            return CreatedAtRoute(nameof(GetGameByIdAsync), new { Id = readGameDto.Id }, readGameDto);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteGameDto>> DeleteGameAsync(int id)
        {
            await _gameRepository.DeleteGameAsync(id);
            return Ok();
        }
    }
}