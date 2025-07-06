using FootballLeague.DAL.Entities;

namespace FootballLeague.DAL.Repositories.Interfaces
{
    public interface IStadiumRepository : IGenericRepository<Stadium>
    {
        public Task<Stadium> GetWithInclude(int id);
        public Task<List<Stadium>> GetAllWithInclude();
    }
}
