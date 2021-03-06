using System.Threading.Tasks;
using API.Commands;
using API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetGamesAsync()
        {
            var games = await _mediator.Send(new GetGamesQuerie());
            return Ok(games);
        }
        
        [HttpGet("{id}", Name = "GetGameByIdAsync")]
        public async Task<IActionResult> GetGameByIdAsync(int id)
        {
            var game = await _mediator.Send(new GetGameByIdQuerie(id));
            return game != null ? Ok(game) : NotFound();
        }

        [HttpGet]
        [Route("genre/{genre}")]
        public async Task<IActionResult> GetGamesByGenreAsync(string genre)
        {
            var games = await _mediator.Send(new GetGameByGenreQuerie(genre));
            return games != null ? Ok(games) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync([FromBody] CreateGameCommand command)
        {
            var game = await _mediator.Send(command);
            return CreatedAtRoute(nameof(GetGameByIdAsync), new { Id = game.Id }, game);
        }
 
        [HttpPut]
        public async Task<IActionResult> UpdateGameAsync([FromBody] UpdateGameCommand command)
        {
            var game = await _mediator.Send(command);
            return game != null ? Ok(game) : NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAsync(int id)
        {
            var result = await _mediator.Send(new DeleteGameCommand(id));
            return result ? Ok() : NotFound();
        }
    }
}