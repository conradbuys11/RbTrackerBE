using RbTrackerBE.Enums;

namespace RbTrackerBE.DTOs.TeamInYear
{
    /// <summary>
    /// Used to GET a TeamInYear. From ViewYear page.
    /// </summary>
    public class TiyDtoViewYear
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public float OfRating { get; set; }
        public float DfRating { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int LikelyWins { get; set; }
        public int LikelyLosses { get; set; }
        public int LikelyTies { get; set; }
        public int ByeId { get; set; }
        public int Seed { get; set; }
        public YearResult Result { get; set; }

        public TiyDtoViewYear(
            int id,
            string teamName,
            Conference conference,
            Division division,
            float ofRating,
            float dfRating,
            int wins,
            int losses,
            int ties,
            int likelyWins,
            int likelyLosses,
            int likelyTies,
            int byeId,
            int seed,
            YearResult result
            )
        {
            Id = id;
            TeamName = teamName;
            Conference = conference;
            Division = division;
            OfRating = ofRating;
            DfRating = dfRating;
            Wins = wins;
            Losses = losses;
            Ties = ties;
            LikelyWins = likelyWins;
            LikelyLosses = likelyLosses;
            LikelyTies = likelyTies;
            ByeId = byeId;
            Seed = seed;
            Result = result;
        }
    }
}
