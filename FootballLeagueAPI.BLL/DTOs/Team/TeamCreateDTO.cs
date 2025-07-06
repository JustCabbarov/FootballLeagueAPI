using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BLL.DTOs.Team
{
    public class TeamCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamCode { get; set; }
        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int StadiumId { get; set; }
    }
}
