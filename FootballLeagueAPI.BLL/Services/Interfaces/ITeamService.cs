using FootballLeague.BLL.DTOs;
using FootballLeague.BLL.DTOs.Team;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Services.Interfaces
{
    public interface ITeamService : IGenericService<TeamDTO,TeamCreateDTO, Team>
    {
        public Task<TeamDTO> GetWithInclude(int id);
        public Task<List<TeamDTO>> GetAllWithInclude();
        public Task<TeamDTO> GetTeamByName(string name);
    }
}
