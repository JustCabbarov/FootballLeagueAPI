using FootballLeague.BLL.DTOs.Match;
using FootballLeague.BLL.DTOs.MatchGoal;
using FootballLeague.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class matchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMatchGoalService _matchGoalService;

        public matchController(IMatchService matchService, IMatchGoalService matchGoalService)
        {
            _matchService = matchService;
            _matchGoalService = matchGoalService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var match = await _matchService.GetByIdAsync(id);
            if (match == null)
                return NotFound($"No match found with id {id}");

            return Ok(match);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matchs = await _matchService.GetAllAsync();
            return Ok(matchs);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MatchCreateDTO match)
        {
            if (match == null)
                return BadRequest("Match data is null.");



            var addedMatch = await _matchService.AddAsync(match);
            var matchGoals = match.MatchGoalPlayerIds?
            .Select(playerId => new CreateMatchGoalDTO
            {
                MatchId = addedMatch.Id,
                PlayerId = playerId
            }).ToList();
            foreach (var item in matchGoals)
            {
                await _matchGoalService.AddAsync(item);

            }
            return CreatedAtAction(nameof(GetById), new { id = addedMatch.Id }, addedMatch);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _matchService.DeleteAsync(id);
            if (!result)
                return NotFound($"No match found with id {id}");

            return NoContent();
        }
    }
}
