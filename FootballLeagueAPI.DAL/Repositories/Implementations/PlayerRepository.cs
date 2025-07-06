using FootballLeague.DAL.Data;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DAL.Repositories.Implementations
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Player> GetWithInclude(int id)
            => await _context.Players
            .Where(x => !x.IsDeleted)
            .Include(x => x.Team)
            .Include(x => x.MatchGoals)
            .ThenInclude(x => x.Match)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Player>> GetAllWithInclude()
            => await _context.Players
            .Where(x => !x.IsDeleted)
            .Include(x => x.Team)
            .Include(x => x.MatchGoals)
            .ThenInclude(x => x.Match)
            .ToListAsync();
    }
}
