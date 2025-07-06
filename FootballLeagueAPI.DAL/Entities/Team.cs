namespace FootballLeague.DAL.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int TeamCode { get; set; }
        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int StadiumId { get; set; }
        public Stadium? Stadium { get; set; }
        public List<Player>? Players { get; set; }
    }
}
