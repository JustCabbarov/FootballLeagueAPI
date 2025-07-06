using FootballLeague.BLL.DTOs.Statistic;
using FootballLeague.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly IStadiumService _stadiumService;
        private readonly IMatchService _matchService;
        private readonly IMatchGoalService _matchGoalService;

        public StatisticsController(IPlayerService playerService, ITeamService teamService, IStadiumService stadiumService, IMatchService matchService, IMatchGoalService matchGoalService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _stadiumService = stadiumService;
            _matchService = matchService;
            _matchGoalService = matchGoalService;
        }

        [HttpGet("team/{name}")]
        public async Task<IActionResult> GetTeamStatistic(string name)
        {
            StatisticDTO DTO = new StatisticDTO();

            var data = await _teamService.GetTeamByName(name);
            if (data == null)
                return NotFound($"No team found with name {name}");

            var matches = await _matchService.GetMatchesByTeamId(data.Id);
            if (matches == null || matches.Count == 0)
                return NotFound($"No matches found for team {name}");

            foreach (var match in matches)
            {
                bool isHost = match.HostTeamId == data.Id;
                bool isGuest = match.GuestTeamId == data.Id;

                if (isHost)
                {
                    if (match.HostGoalCount > match.GuestGoalCount)
                    {
                        DTO.Wins++;
                        DTO.Points += 3;
                    }
                    else if (match.HostGoalCount < match.GuestGoalCount)
                    {
                        DTO.Losses++;
                    }
                    else
                    {
                        DTO.Draws++;
                        DTO.Points += 1;
                    }

                    DTO.GoalsFor += match.HostGoalCount;
                    DTO.GoalsAgainst += match.GuestGoalCount;
                    var avarage = (match.HostGoalCount - match.GuestGoalCount) / 2;
                    DTO.GoalAvarage = avarage;
                }
                else if (isGuest)
                {
                    if (match.GuestGoalCount > match.HostGoalCount)
                    {
                        DTO.Wins++;
                        DTO.Points += 3;
                    }
                    else if (match.GuestGoalCount < match.HostGoalCount)
                    {
                        DTO.Losses++;
                    }
                    else
                    {
                        DTO.Draws++;
                        DTO.Points += 1;
                    }

                    DTO.GoalsFor += match.GuestGoalCount;
                    DTO.GoalsAgainst += match.HostGoalCount;
                    var avarage = (match.HostGoalCount - match.GuestGoalCount) / 2;
                    DTO.GoalAvarage = avarage;
                }
            }

            DTO.TeamName = data.Name;
            return Ok(DTO);
        }
        [HttpGet("player/{PlayerId}")]
        public async Task<IActionResult> GetPlayerStatistic(int PlayerId)
        {
            PlayerStatisticDTO DTO = new PlayerStatisticDTO();
            var data = await _playerService.GetByIdAsync(PlayerId);
            if (data == null)
                return NotFound($"No player found with id {PlayerId}");
            var matches = await _matchGoalService.GetWithInclude(data.Id);
            DTO.FullName = data.Name + " " + data.Surname;
            DTO.UniformNumber = data.UniformNumber;
            foreach (var match in matches)
            {
                DTO.GoalCount++;


            }
            return Ok(DTO);
        }



        [HttpGet("team")]
        public async Task<IActionResult> GetAllTeamStatistics()
        {
            var teams = await _teamService.GetAllWithInclude();
            if (teams == null || teams.Count == 0)
                return NotFound("No teams found.");

            var statisticsList = new List<StatisticDTO>();

            foreach (var team in teams)
            {
                var matches = await _matchService.GetMatchesByTeamId(team.Id);
                if (matches == null || matches.Count == 0)
                    continue;

                var dto = new StatisticDTO
                {
                    TeamName = team.Name
                };

                foreach (var match in matches)
                {
                    bool isHost = match.HostTeamId == team.Id;
                    bool isGuest = match.GuestTeamId == team.Id;

                    if (isHost)
                    {
                        if (match.HostGoalCount > match.GuestGoalCount)
                        {
                            dto.Wins++;
                            dto.Points += 3;
                        }
                        else if (match.HostGoalCount < match.GuestGoalCount)
                        {
                            dto.Losses++;
                        }
                        else
                        {
                            dto.Draws++;
                            dto.Points += 1;
                        }

                        dto.GoalsFor += match.HostGoalCount;
                        dto.GoalsAgainst += match.GuestGoalCount;
                    }
                    else if (isGuest)
                    {
                        if (match.GuestGoalCount > match.HostGoalCount)
                        {
                            dto.Wins++;
                            dto.Points += 3;
                        }
                        else if (match.GuestGoalCount < match.HostGoalCount)
                        {
                            dto.Losses++;
                        }
                        else
                        {
                            dto.Draws++;
                            dto.Points += 1;
                        }

                        dto.GoalsFor += match.GuestGoalCount;
                        dto.GoalsAgainst += match.HostGoalCount;
                    }
                }

                dto.GoalAvarage = (dto.GoalsFor - dto.GoalsAgainst) / 2;
                statisticsList.Add(dto);
            }

            return Ok(statisticsList);
        }
        [HttpGet("team/LeastScorer")]
        public async Task<IActionResult> GetMostConcededTeams()
        {
            var teams = await _teamService.GetAllWithInclude();
            if (teams == null || teams.Count == 0)
                return NotFound("No teams found.");

            var statisticsList = new List<TopScorerStatisticDTO>();

            foreach (var team in teams)
            {
                var matches = await _matchService.GetMatchesByTeamId(team.Id);
                if (matches == null || matches.Count == 0)
                    continue;

                var dto = new TopScorerStatisticDTO
                {
                    TeamName = team.Name
                };

                foreach (var match in matches)
                {
                    bool isHost = match.HostTeamId == team.Id;
                    bool isGuest = match.GuestTeamId == team.Id;

                    if (isHost)
                    {
                        dto.GoalsFor += match.HostGoalCount;
                        dto.GoalsAgainst += match.GuestGoalCount;
                    }
                    else if (isGuest)
                    {
                        dto.GoalsFor += match.GuestGoalCount;
                        dto.GoalsAgainst += match.HostGoalCount;
                    }
                }

                statisticsList.Add(dto);
            }

            if (statisticsList.Count == 0)
                return NotFound("No team statistics found.");

            var mostConcededTeam = statisticsList.OrderByDescending(x => x.GoalsAgainst).FirstOrDefault();
            var leastConcededTeam = statisticsList.OrderBy(x => x.GoalsAgainst).FirstOrDefault();

            return Ok(new
            {
                MostConcededTeam = new
                {
                    mostConcededTeam.TeamName,
                    GoalsFor = mostConcededTeam.GoalsFor,
                    GoalsAgainst = mostConcededTeam.GoalsAgainst
                },
                LeastConcededTeam = new
                {
                    leastConcededTeam.TeamName,
                    GoalsFor = leastConcededTeam.GoalsFor,
                    GoalsAgainst = leastConcededTeam.GoalsAgainst
                }
            });
        }


        [HttpGet("team/TopScorer")]
        public async Task<IActionResult> GetLeastConcededTeams()
        {
            var teams = await _teamService.GetAllWithInclude();
            if (teams == null || teams.Count == 0)
                return NotFound("No teams found.");

            var statisticsList = new List<TopScorerStatisticDTO>();

            foreach (var team in teams)
            {
                var matches = await _matchService.GetMatchesByTeamId(team.Id);
                if (matches == null || matches.Count == 0)
                    continue;

                var dto = new TopScorerStatisticDTO
                {
                    TeamName = team.Name
                };

                foreach (var match in matches)
                {
                    bool isHost = match.HostTeamId == team.Id;
                    bool isGuest = match.GuestTeamId == team.Id;

                    if (isHost)
                    {
                        dto.GoalsFor += match.HostGoalCount;
                        dto.GoalsAgainst += match.GuestGoalCount;
                    }
                    else if (isGuest)
                    {
                        dto.GoalsFor += match.GuestGoalCount;
                        dto.GoalsAgainst += match.HostGoalCount;
                    }
                }

                statisticsList.Add(dto);
            }

            if (statisticsList.Count == 0)
                return NotFound("No team statistics found.");

            var mostConcededTeam = statisticsList.OrderByDescending(x => x.GoalsFor).FirstOrDefault();
            var leastConcededTeam = statisticsList.OrderBy(x => x.GoalsFor).FirstOrDefault();

            return Ok(new
            {
                MostConcededTeam = new
                {
                    mostConcededTeam.TeamName,
                    GoalsFor = mostConcededTeam.GoalsFor,
                    GoalsAgainst = mostConcededTeam.GoalsAgainst
                },
                LeastConcededTeam = new
                {
                    leastConcededTeam.TeamName,
                    GoalsFor = leastConcededTeam.GoalsFor,
                    GoalsAgainst = leastConcededTeam.GoalsAgainst
                }
            });
        }

        [HttpGet("player/TopScorerPlayer")]
        public async Task<IActionResult> GetTopScorerPlayer()
        {
            var players = await _playerService.GetAllWithInclude();
            if (players == null || players.Count == 0)
                return NotFound("No players found.");
            var playerStatistics = new List<PlayerStatisticDTO>();
            foreach (var player in players)
            {
                var matches = await _matchGoalService.GetWithInclude(player.Id);
                if (matches == null || matches.Count == 0)
                    continue;
                var dto = new PlayerStatisticDTO
                {
                    FullName = player.Name + " " + player.Surname,
                    UniformNumber = player.UniformNumber
                };
                foreach (var match in matches)
                {
                    dto.GoalCount++;
                }
                playerStatistics.Add(dto);
            }
            if (playerStatistics.Count == 0)
                return NotFound("No player statistics found.");
            var topScorer = playerStatistics.OrderByDescending(x => x.GoalCount).FirstOrDefault();
            return Ok(new
            {
                TopScorerPlayer = new
                {
                    topScorer.TeamName,
                    topScorer.FullName,
                    topScorer.UniformNumber,
                    topScorer.GoalCount
                }
            });


        }
    }
}
