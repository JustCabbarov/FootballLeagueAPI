using FootballLeague.BLL.DTOs.Stadium;

namespace FootballLeague.BLL.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamCode { get; set; }
        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int? StadiumId { get; set; }
        public StadiumDTO? Stadium { get; set; }
      
        public List<int>? PlayersId { get; set; }
    }
}
