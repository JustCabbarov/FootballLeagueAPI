namespace FootballLeague.DAL.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GoalCount { get; set; }
        public int UniformNumber { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public List<MatchGoal>?MatchGoals { get; set; }
    }
}
