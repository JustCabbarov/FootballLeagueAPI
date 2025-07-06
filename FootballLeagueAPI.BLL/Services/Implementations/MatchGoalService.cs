using AutoMapper;
using FootballLeague.BLL.DTOs.MatchGoal;
using FootballLeague.BLL.Services.Interfaces;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;

namespace FootballLeague.BLL.Services.Implementations
{
    public class MatchGoalService : GenericService<MatchGoalDTO, CreateMatchGoalDTO,MatchGoal>, IMatchGoalService
    {
        private readonly IMatchGoalRepository _matchGoalRepository;
        private readonly IMapper _mapper;

        public MatchGoalService(IMatchGoalRepository matchGoalRepository, IMapper mapper) : base(mapper, matchGoalRepository)
        {
            _matchGoalRepository = matchGoalRepository;
        }

        public async Task<List<MatchGoalDTO>> GetWithInclude(int PlayerId)
        {
            if (_matchGoalRepository == null)
                throw new Exception("_matchGoalRepository is null in MatchGoalService");

            var matchGoal = await _matchGoalRepository.GetWithInclude(PlayerId);
            if (matchGoal == null)
                throw new Exception("Repository returned null from GetWithInclude");

            return _mapper.Map<List<MatchGoalDTO>>(matchGoal);
        }


        public async Task<List<MatchGoalDTO>> GetAllWithInclude()
        {
            var matchGoals = await _matchGoalRepository.GetAllWithInclude();
            return _mapper.Map<List<MatchGoalDTO>>(matchGoals);
        }
    }
}
