using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class PlayoffPicture
    {
        [Key]
        public int Id { get; set; }
        public int WeekId { get; set; }
        public Week Week { get; set; } = null!;
        public ICollection<TiyInPlayoffPicture> TiyInPlayoffPictures { get; } = new List<TiyInPlayoffPicture>();
    }
}
