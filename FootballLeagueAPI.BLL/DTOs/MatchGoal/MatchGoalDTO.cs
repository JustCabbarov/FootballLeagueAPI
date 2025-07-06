using FootballLeague.BLL.DTOs.Match;
using FootballLeague.BLL.DTOs.Player;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.DTOs.MatchGoal
{
    public class MatchGoalDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public MatchDTO? Match { get; set; }
        public int PlayerId { get; set; }
        public PlayerDTO? Player { get; set; }
     
    }
}
