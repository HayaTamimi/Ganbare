using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;
using static ganbare.src.DTO.LeaderboardDTO;

namespace ganbare.src.Services.leaderboard
{
    public interface ILeaderboardService
    {
        Task<LeaderboardReadDto> CreateOneAsync(LeaderboardCreateDto createDto);
        Task<List<LeaderboardReadDto>> GetAllAsync();
        Task<LeaderboardReadDto> GetByIdAsync(Guid leaderboardId);
        Task<bool> DeleteOneAsync(Guid leaderboardId);
        Task<bool> UpdateOneAsync(Guid leaderboardId, LeaderboardUpdateDto updateDto);

        // still not sure about it
        //Task<List<LeaderboardReadDto>> GetAllAsyncScores(User score); 

    }
}