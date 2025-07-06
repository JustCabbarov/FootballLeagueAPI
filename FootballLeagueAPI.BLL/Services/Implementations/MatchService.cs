
using AutoMapper;
using FootballLeague.BLL.DTOs.Match;
using FootballLeague.BLL.Services.Interfaces;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;

namespace FootballLeague.BLL.Services.Implementations
{
    public class MatchService : GenericService<MatchDTO,MatchCreateDTO, Match>, IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMapper mapper, IMatchRepository matchRepository) : base(mapper, matchRepository)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<MatchDTO> GetWithInclude(int id)
        {
            var match = await _matchRepository.GetWithInclude(id);
            return _mapper.Map<MatchDTO>(match);
        }

        public async Task<List<MatchDTO>> GetAllWithInclude()
        {
            var matches = await _matchRepository.GetAllWithInclude();
            return _mapper.Map<List<MatchDTO>>(matches);
        }

        public async Task<List<MatchDTO>> GetMatchesByTeamId(int teamId)
        {
            var matches = await _matchRepository.GetMatchesByTeamId(teamId);
            if (matches == null || !matches.Any())
            {
                return new List<MatchDTO>();
            }
            return _mapper.Map<List<MatchDTO>>(matches);

        }
    }
}
