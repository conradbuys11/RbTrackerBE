using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }
        public int YearNo { get; set; }
    }
}
