namespace FootballLeague.DAL.Entities
{
    public class Match : BaseEntity
    {
        public int WeekNumber { get; set; }
        public int HostGoalCount { get; set; }
        public int GuestGoalCount { get; set; }
        public int HostTeamId { get; set; }
        public Team? HostTeam { get; set; }
        public int GuestTeamId { get; set; }
        public Team? GuestTeam { get; set; }
        public List<MatchGoal>? MatchGoals { get; set; }
    }
}
