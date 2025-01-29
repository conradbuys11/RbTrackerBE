namespace RbTrackerBE.DTOs.Team
{
    /// <summary>
    /// Used to GET a team. From CreateYear page.
    /// </summary>
    public class TeamDtoCreateYear
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TeamDtoCreateYear(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
