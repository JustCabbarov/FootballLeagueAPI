using AutoMapper;
using FootballLeague.BLL.DTOs.Stadium;
using FootballLeague.BLL.Services.Interfaces;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;

namespace FootballLeague.BLL.Services.Implementations
{
    public class StadiumService : GenericService<StadiumDTO,StadiumCreateDTO, Stadium>, IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;
        public readonly IMapper _mapper;

        public StadiumService(IMapper mapper, IStadiumRepository stadiumRepository) : base(mapper, stadiumRepository)
        {
            _stadiumRepository = stadiumRepository;
            _mapper = mapper;
        }

        public async Task<StadiumDTO> GetWithInclude(int id)
        {
            var stadium = await _stadiumRepository.GetWithInclude(id);
            return _mapper.Map<StadiumDTO>(stadium);
        }

        public async Task<List<StadiumDTO>> GetAllWithInclude()
        {
            var stadiums = await _stadiumRepository.GetAllWithInclude();
            return _mapper.Map<List<StadiumDTO>>(stadiums);
        }
    }
}
