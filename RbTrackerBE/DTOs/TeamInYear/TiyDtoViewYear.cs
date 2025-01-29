namespace RbTrackerBE.DTOs.TeamInYear
{
    /// <summary>
    /// Used to GET a TeamInYear. From ViewYear page.
    /// </summary>
    public class TiyDtoViewYear
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int TeamConference { get; set; }
        public int TeamDivision { get; set; }
        public float OfRating { get; set; }
        public float DfRating { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int LikelyWins { get; set; }
        public int LikelyLosses { get; set; }
        public int LikelyTies { get; set; }
        public int ByeId { get; set; }

        public TiyDtoViewYear(
            int id,
            string teamName,
            int teamConference,
            int teamDivision,
            float ofRating,
            float dfRating,
            int wins,
            int losses,
            int ties,
            int likelyWins,
            int likelyLosses,
            int likelyTies,
            int byeId
            )
        {
            Id = id;
            TeamName = teamName;
            TeamConference = teamConference;
            TeamDivision = teamDivision;
            OfRating = ofRating;
            DfRating = dfRating;
            Wins = wins;
            Losses = losses;
            Ties = ties;
            LikelyWins = likelyWins;
            LikelyLosses = likelyLosses;
            LikelyTies = likelyTies;
            ByeId = byeId;
        }
    }
}
