using FootballLeague.BLL.DTOs.Player;
using FootballLeague.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null)
                return NotFound($"No player found with id {id}");

            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PlayerCreateDTO player)
        {
            if (player == null)
                return BadRequest("Player data is null.");
            var data = await _playerService.GetAllAsync();
            if (data.Any(p => p.UniformNumber == player.UniformNumber && p.TeamId == player.TeamId))
                return BadRequest("A player with the same uniform number already exists in this team.");

            var addedPlayer = await _playerService.AddAsync(player);
            return CreatedAtAction(nameof(GetById), new { id = addedPlayer.Id }, addedPlayer);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _playerService.DeleteAsync(id);
            if (!result)
                return NotFound($"No player found with id {id}");

            return NoContent();
        }
    }
}
