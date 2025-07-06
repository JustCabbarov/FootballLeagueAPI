using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BLL.DTOs.Statistic
{
    public class StatisticDTO
    {
        public string TeamName { get; set; }
        public int Played { get; set; }        
        public int Wins { get; set; }          
        public int Draws { get; set; }         
        public int Losses { get; set; }        
        public int GoalsFor { get; set; }      
        public int GoalsAgainst { get; set; }  
        public int GoalAvarage { get; set; }
        public int Points { get; set; }
    }
}
