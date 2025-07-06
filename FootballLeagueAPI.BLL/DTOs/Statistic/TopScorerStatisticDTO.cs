using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BLL.DTOs.Statistic
{
    public class TopScorerStatisticDTO
    {
        public string  TeamName { get; set; }
        public int GoalsFor{ get; set; }
    public int GoalsAgainst { get; set; }
    }
}
