using FootballLeague.DAL.Data;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DAL.Repositories.Implementations
{
    public class StadiumRepository : GenericRepository<Stadium>, IStadiumRepository
    {
        private readonly AppDbContext _context;
        public StadiumRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Stadium> GetWithInclude(int id)
            => await _context.Stadiums
            .Where(x => !x.IsDeleted)
            .Include(x => x.Team)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Stadium>> GetAllWithInclude()
            => await _context.Stadiums
            .Where(x => !x.IsDeleted)
            .Include(x => x.Team)
            .ToListAsync();
    }
}
