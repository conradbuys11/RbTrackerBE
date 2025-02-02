using RbTrackerBE.Models;

namespace RbTrackerBE
{
    public static class Helpers
    {
        public static float AvRating(this TeamInYear team)
        {
            return (team.OfRating + team.DfRating) / 2;
        }
    }
}
