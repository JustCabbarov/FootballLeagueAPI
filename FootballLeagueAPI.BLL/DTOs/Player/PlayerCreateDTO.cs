using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BLL.DTOs.Player
{
    public class PlayerCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GoalCount { get; set; }
        public int UniformNumber { get; set; }
        public int TeamId { get; set; }
    }
}
