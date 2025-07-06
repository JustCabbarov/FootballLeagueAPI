using AutoMapper;
using FootballLeague.BLL.DTOs;
using FootballLeague.BLL.DTOs.Team;
using FootballLeague.BLL.Services.Interfaces;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;

namespace FootballLeague.BLL.Services.Implementations
{
    public class TeamService : GenericService<TeamDTO,TeamCreateDTO, Team>, ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public readonly IMapper _mapper;

        public TeamService(IMapper mapper, ITeamRepository teamRepository) : base(mapper, teamRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<TeamDTO> GetWithInclude(int id)
        {
            var team = await _teamRepository.GetWithInclude(id);
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<List<TeamDTO>> GetAllWithInclude()
        {
            var teams = await _teamRepository.GetAllWithInclude();
            return _mapper.Map<List<TeamDTO>>(teams);
        }

        public  async Task<TeamDTO> GetTeamByName(string name)
        {
          var team = await _teamRepository.GetTeamByName(name);
            if (team == null)
            {
                return null;
            }
            return _mapper.Map<TeamDTO>(team);


        }
    }
}
