using FootballLeague.BLL.DTOs.MatchGoal;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.DTOs.Match
{
    public class MatchDTO
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public int HostGoalCount { get; set; }
        public int GuestGoalCount { get; set; }
        public int HostTeamId { get; set; }
        public int GuestTeamId { get; set; }
      
        public TeamDTO? HostTeam { get; set; }
        public TeamDTO? GuestTeam { get; set; }
        public List<MatchGoalDTO>? MatchGoals { get; set; }


    }
}
