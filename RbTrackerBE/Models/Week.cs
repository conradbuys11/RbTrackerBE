using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Week
    {
        [Key]
        public int Id { get; set; }
        public int WeekNo { get; set; }
        public int YearId { get; set; }
        public Year Year { get; set; } = null!;
        public ICollection<Game> Games { get; } = new List<Game>();
        public ICollection<TeamInYear> Byes { get; } = new List<TeamInYear>();
    }
}
