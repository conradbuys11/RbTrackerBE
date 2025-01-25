using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class TeamInYear
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;
        public int YearId { get; set; }
        public float OfRating { get; set; }
        public float DfRating { get; set; }
        // public float AvRating { get; set; } should be a function
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        // public string Record { get; set; } should be a function
        public int LikelyWins { get; set; }
        public int LikelyLosses { get; set; }
        public int LikelyTies { get; set; }
        // public string LikelyRecord { get; set; } should be a function
        public int? ByeId { get; set; }
        public Week? Bye { get; set; }
        public ICollection<Game> AwayGames { get; } = new List<Game>();
        public ICollection<Game> HomeGames { get; } = new List<Game>();
    }
}
