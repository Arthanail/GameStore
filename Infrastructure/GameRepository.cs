using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class GameRepository : IGameRepository
    {
        private readonly StoreContext _context;

        public GameRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(Guid id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre)
        {
            return await _context.Games.Where(x => x.GameGenre == genre).ToListAsync();
        }

        public async Task AddGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await Save();
        }
        
        public async Task UpdateGameAsync(Game game)
        {
            _context.Update(game);
            await Save();
        }
        
        public async Task DeleteGameAsync(Guid id)
        {
            var game = _context.Games.Find(id);
            _context.Games.Remove(game);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}