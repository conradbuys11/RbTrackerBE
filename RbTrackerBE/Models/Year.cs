using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }
        public int YearNo { get; set; }
        public ICollection<Week> Weeks { get; } = new List<Week>();
        public ICollection<TeamInYear> TeamInYears { get; } = new List<TeamInYear>();
    }
}
