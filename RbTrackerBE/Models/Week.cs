using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Week
    {
        [Key]
        public int Id { get; set; }
        public int WeekNo { get; set; }
        public Year Year { get; set; }
    }
}
