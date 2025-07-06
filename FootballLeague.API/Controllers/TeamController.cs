using FootballLeague.BLL.DTOs.Team;
using FootballLeague.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class teamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IStadiumService _stadiumService;

        public teamController(ITeamService teamService, IStadiumService stadiumService)
        {
            _teamService = teamService;
            _stadiumService = stadiumService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound($"No team found with id {id}");

            return Ok(team);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeamCreateDTO team)
        {

            if (team == null)
                return BadRequest("Team data is null.");

            var addedTeam = await _teamService.AddAsync(team);
            return CreatedAtAction(nameof(GetById), new { id = addedTeam.Id }, addedTeam);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _teamService.DeleteAsync(id);
            if (!result)
                return NotFound($"No team found with id {id}");

            return NoContent();
        }
    }
}
