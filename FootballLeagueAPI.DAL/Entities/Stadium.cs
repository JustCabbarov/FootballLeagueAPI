namespace FootballLeague.DAL.Entities
{
    public class Stadium : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
