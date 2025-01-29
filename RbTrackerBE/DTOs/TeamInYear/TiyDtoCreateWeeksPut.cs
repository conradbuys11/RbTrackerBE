namespace RbTrackerBE.DTOs.TeamInYear
{
    /// <summary>
    /// Used to PUT a TeamInYear with the bye id. From CreateWeeks page.
    /// </summary>
    public class TiyDtoCreateWeeksPut
    {
        public int Id { get; set; }
        public int ByeId { get; set; }

        public TiyDtoCreateWeeksPut(int id, int byeId)
        {
            Id = id;
            ByeId = byeId;
        }
    }
}
