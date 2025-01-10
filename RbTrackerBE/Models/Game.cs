using RbTrackerBE.Enums;
using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public GameType GameType { get; set; }
        public Week Week { get; set; }
        public TeamInYear TeamOne { get; set; }
        public TeamInYear TeamTwo { get; set; }
        public int? TeamOneScore { get; set; }
        public int? TeamTwoScore { get; set; }
        public bool? IsTie { get; set; }
        public TeamInYear LikelyWinner { get; set; }
        public TeamInYear? Winner { get; set; }
        public TeamInYear? Loser { get; set; }
    }
}
