using FootballLeague.DAL.Entities;

namespace FootballLeague.DAL.Repositories.Interfaces
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        public Task<Team> GetWithInclude(int id);
        public Task<List<Team>> GetAllWithInclude();
        Task<Team> GetTeamByName(string name);
    }
}
