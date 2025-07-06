using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.BLL.DTOs.Match;
using FootballLeague.BLL.DTOs.Player;

namespace FootballLeague.BLL.DTOs.MatchGoal
{
    public class CreateMatchGoalDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
       
        public int PlayerId { get; set; }
    }
}
