namespace FootballLeague.DAL.Entities
{
    public class MatchGoal : BaseEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
