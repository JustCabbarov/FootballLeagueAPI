using FootballLeague.DAL.Data;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DAL.Repositories.Implementations
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        private readonly AppDbContext _context;

        public MatchRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Match> GetWithInclude(int id)
            => await _context.Matches
            .Where(x => !x.IsDeleted)
            .Include(x => x.HostTeam)
            .Include(x => x.GuestTeam)
            .Include(x => x.MatchGoals)
            .ThenInclude(x => x.Player)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Match>> GetAllWithInclude()
            => await _context.Matches
            .Where(x => !x.IsDeleted)
            .Include(x => x.HostTeam)
            .Include(x => x.GuestTeam)
            .Include(x => x.MatchGoals)
            .ThenInclude(x => x.Player)
            .ToListAsync();

        public Task<List<Match>> GetMatchesByTeamId(int teamId)
        {
           var matches = _context.Matches
                .Where(x => !x.IsDeleted && (x.HostTeamId == teamId || x.GuestTeamId == teamId))
                .Include(x => x.HostTeam)
                .Include(x => x.GuestTeam)
                .Include(x => x.MatchGoals)
                .ThenInclude(x => x.Player)
                .ToListAsync();
            return matches;
        }
    }
}
