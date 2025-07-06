using FootballLeague.BLL.DTOs.Stadium;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Services.Interfaces
{
    public interface IStadiumService : IGenericService<StadiumDTO, StadiumCreateDTO,Stadium>
    {
        public Task<StadiumDTO> GetWithInclude(int id);
        public Task<List<StadiumDTO>> GetAllWithInclude();
    }
}
