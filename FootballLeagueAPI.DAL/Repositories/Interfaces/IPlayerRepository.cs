using FootballLeague.DAL.Entities;

namespace FootballLeague.DAL.Repositories.Interfaces
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        public Task<Player> GetWithInclude(int Id);
        public Task<List<Player>> GetAllWithInclude();
     
    }
}
