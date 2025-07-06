using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.DTOs.Player
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GoalCount { get; set; }
        public int UniformNumber { get; set; }
        public int? TeamId { get; set; }
        public TeamDTO? Team { get; set; }

    }
}
