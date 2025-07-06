using FootballLeague.DAL.Data;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DAL.Repositories.Implementations
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly AppDbContext _context;
        public TeamRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Team> GetWithInclude(int id)
            => await _context.Teams
            .Where(x => !x.IsDeleted)
            .Include(x => x.Stadium)
            .Include(x => x.Players)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Team>> GetAllWithInclude()
            => await _context.Teams
            .Where(x => !x.IsDeleted)
            .Include(x => x.Stadium)
            .Include(x => x.Players)
            .ToListAsync();

        public Task<Team> GetTeamByName(string name)
        {
            return _context.Teams
                .Where(x => !x.IsDeleted && x.Name == name)
                .Include(x => x.Stadium)
                .Include(x => x.Players)
                .FirstOrDefaultAsync();
        }
    }
}
