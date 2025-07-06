using FootballLeague.BLL.DTOs.MatchGoal;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Services.Interfaces
{
    public interface IMatchGoalService : IGenericService<MatchGoalDTO, CreateMatchGoalDTO, MatchGoal>
    {
        public Task<List<MatchGoalDTO>> GetWithInclude(int PlayerId);
        public Task<List<MatchGoalDTO>> GetAllWithInclude();
    }
}
