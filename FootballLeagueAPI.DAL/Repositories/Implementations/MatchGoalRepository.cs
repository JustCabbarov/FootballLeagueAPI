using FootballLeague.DAL.Data;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DAL.Repositories.Implementations
{
    public class MatchGoalRepository : GenericRepository<MatchGoal>, IMatchGoalRepository
    {
        private readonly AppDbContext _context;
        public MatchGoalRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MatchGoal>> GetWithInclude(int playerId)
        {
            return await _context.MatchGoals
                .Where(x => !x.IsDeleted && x.PlayerId == playerId)
                .Include(x => x.Match)
                .Include(x => x.Player)
                .ToListAsync();
        }

        public async Task<List<MatchGoal>> GetAllWithInclude()
            => await _context.MatchGoals
            .Where(x => !x.IsDeleted)
            .Include(x => x.Match)
            .Include(x => x.Player)
            .ToListAsync();
    }

}
