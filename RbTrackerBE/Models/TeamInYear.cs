using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class TeamInYear
    {
        [Key]
        public int Id { get; set; }
        public Team Team { get; set; }
        public Year Year { get; set; }
        public float OfRating { get; set; }
        public float DfRating { get; set; }
        public float AvRating { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public string Record { get; set; }
        public int LikelyWins { get; set; }
        public int LikelyLosses { get; set; }
        public int LikelyTies { get; set; }
        public string LikelyRecord { get; set; }
    }
}
