using RbTrackerBE.DTOs;
using RbTrackerBE.Models;

namespace RbTrackerBE.Services
{
    public interface IDbService
    {
        public Task<TeamInYear> TeamInYearDtoConversion(TeamInYearDto dto);
        public Task<Week> WeekDtoConversion(WeekDto dto);
        public Task<Game> GameDtoConversion(GameDto dto);
    }
}
