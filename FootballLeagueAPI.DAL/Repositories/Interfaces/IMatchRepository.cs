using FootballLeague.DAL.Entities;

namespace FootballLeague.DAL.Repositories.Interfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        public Task<Match> GetWithInclude(int id);
        public Task<List<Match>> GetAllWithInclude();
        public Task<List<Match>> GetMatchesByTeamId(int teamId);
    }
}
