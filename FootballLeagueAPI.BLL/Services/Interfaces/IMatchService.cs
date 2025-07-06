using FootballLeague.BLL.DTOs.Match;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Services.Interfaces
{
    public interface IMatchService : IGenericService<MatchDTO, MatchCreateDTO,Match>
    {
        public Task<MatchDTO> GetWithInclude(int id);
        public Task<List<MatchDTO>> GetAllWithInclude();
        public Task<List<MatchDTO>> GetMatchesByTeamId(int teamId);
    }
}
