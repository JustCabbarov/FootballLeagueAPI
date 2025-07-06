using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BLL.DTOs.Match
{
    public class MatchCreateDTO
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public int HostGoalCount { get; set; }
        public int GuestGoalCount { get; set; }
        public int HostTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public List<int>? MatchGoalPlayerIds { get; set; } 
    }
}
