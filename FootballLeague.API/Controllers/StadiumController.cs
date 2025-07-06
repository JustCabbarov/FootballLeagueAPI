using FootballLeague.BLL.DTOs.Stadium;
using FootballLeague.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {

        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stadium = await _stadiumService.GetByIdAsync(id);
            if (stadium == null)
                return NotFound($"No stadium found with id {id}");

            return Ok(stadium);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stadiums = await _stadiumService.GetAllAsync();
            return Ok(stadiums);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StadiumCreateDTO stadium)
        {
            if (stadium == null)
                return BadRequest("Stadium data is null.");

            var addedStadium = await _stadiumService.AddAsync(stadium);
            return CreatedAtAction(nameof(GetById), new { id = addedStadium.Id }, addedStadium);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _stadiumService.DeleteAsync(id);
            if (!result)
                return NotFound($"No stadium found with id {id}");

            return NoContent();
        }
    }
}
