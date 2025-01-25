using RbTrackerBE.DTOs;
using RbTrackerBE.Models;

namespace RbTrackerBE.Services
{
    public interface IDbService
    {
        public Task<TeamInYear> TeamInYearDtoConversion(TeamInYearDto dto);
    }
}
