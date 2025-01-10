using RbTrackerBE.Enums;
using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
    }
}
