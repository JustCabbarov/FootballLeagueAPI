using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.DTOs.Stadium
{
    public class StadiumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int? TeamId { get; set; }
        public TeamDTO? Team { get; set; } 
    }
}
