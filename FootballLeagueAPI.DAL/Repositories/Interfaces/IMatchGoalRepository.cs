using FootballLeague.DAL.Entities;

namespace FootballLeague.DAL.Repositories.Interfaces
{
    public interface IMatchGoalRepository : IGenericRepository<MatchGoal>
    {
        public Task<List<MatchGoal>> GetWithInclude(int PlayerId);
        public Task<List<MatchGoal>> GetAllWithInclude();
    }
}
