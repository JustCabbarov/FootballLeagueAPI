using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BLL.DTOs.Statistic
{
    public class PlayerStatisticDTO
    {
        public int UniformNumber { get; set; }
        public string FullName { get; set; }
        public int GoalCount { get; set; }
        public string TeamName { get; set; }
    }
}
