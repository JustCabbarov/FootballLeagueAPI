using AutoMapper;
using FootballLeague.BLL.DTOs.Player;
using FootballLeague.BLL.Services.Interfaces;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;

namespace FootballLeague.BLL.Services.Implementations
{
    public class PlayerService : GenericService<PlayerDTO,PlayerCreateDTO, Player>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public readonly IMapper _mapper;

        public PlayerService(IMapper mapper, IPlayerRepository playerRepository) : base(mapper, playerRepository)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<PlayerDTO> GetWithInclude(int id)
        {
            var player = await _playerRepository.GetWithInclude(id);
            return _mapper.Map<PlayerDTO>(player);
        }

        public async Task<List<PlayerDTO>> GetAllWithInclude()
        {
            var players = await _playerRepository.GetAllWithInclude();
            return _mapper.Map<List<PlayerDTO>>(players);
        }
    }
}
