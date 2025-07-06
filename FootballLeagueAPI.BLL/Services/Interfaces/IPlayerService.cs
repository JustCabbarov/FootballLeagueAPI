using FootballLeague.BLL.DTOs.Player;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Services.Interfaces
{
    public interface IPlayerService : IGenericService<PlayerDTO,PlayerCreateDTO, Player>
    {
        public Task<PlayerDTO> GetWithInclude(int id);
        public Task<List<PlayerDTO>> GetAllWithInclude();
    }
}
