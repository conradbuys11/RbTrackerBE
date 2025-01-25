using RbTrackerBE.Enums;
using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public ICollection<TeamInYear> TeamInYears { get; } = new List<TeamInYear>();
    }
}
