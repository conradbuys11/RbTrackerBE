using RbTrackerBE.Enums;
using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class TiyInPlayoffPicture
    {
        [Key]
        public int Id { get; set; }
        public int PlayoffPictureId { get; set; }
        public PlayoffPicture PlayoffPicture { get; set; } = null!;
        public int TeamInYearId { get; set; }
        public TeamInYear TeamInYear { get; set; } = null!;
        public Conference Conference { get; set; }
        public int Seed { get; set; }
        public string Record { get; set; } = null!;
    }
}
