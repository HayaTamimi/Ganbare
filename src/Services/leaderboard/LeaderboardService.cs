using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.DTO;
using ganbare.src.Entity;
using ganbare.src.Repository;
using ganbare.src.Utils;
using static ganbare.src.DTO.LeaderboardDTO;

namespace ganbare.src.Services.leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        protected readonly LeaderboardRepository _leaderboardRepo;
        protected readonly IMapper _mapper;


        public LeaderboardService(LeaderboardRepository leaderboardRepo, IMapper mapper)
        {
            _leaderboardRepo = leaderboardRepo;
            _mapper = mapper;
        }
        public async Task<LeaderboardReadDto> CreateOneAsync(LeaderboardCreateDto createDto)
        {
            var totalScores = createDto.Results.Sum(r => r.TotalScore);

            var leaderboard = _mapper.Map<LeaderboardCreateDto, Leaderboard>(createDto);

            var leaderboardCreated = await _leaderboardRepo.CreateOneAsync(leaderboard);

            return _mapper.Map<Leaderboard, LeaderboardReadDto>(leaderboardCreated);
        }

        public async Task<List<LeaderboardReadDto>> GetAllAsync()
        {
            var leaderboardList = await _leaderboardRepo.GetAllAsync();
            return _mapper.Map<List<Leaderboard>, List<LeaderboardReadDto>>(leaderboardList);
        }

        public async Task<LeaderboardReadDto> GetByIdAsync(Guid leaderboardId)
        {
            var foundLeaderboard = await _leaderboardRepo.GetByIdAsync(leaderboardId);
            if (foundLeaderboard == null)
            {
                throw CustomException.NotFound($"Leaderboard with {leaderboardId} cannot be found! ");
            }
            return _mapper.Map<Leaderboard, LeaderboardReadDto>(foundLeaderboard);
        }

        public async Task<bool> DeleteOneAsync(Guid leaderboardId)
        {
            var foundLeaderboard = await _leaderboardRepo.GetByIdAsync(leaderboardId);
            if (foundLeaderboard == null)
            {
                throw CustomException.NotFound(
                    $"Leaderboard with ID {leaderboardId} is not found."
                );
            }
            try
            {
                bool isDeleted = await _leaderboardRepo.DeleteOneAsync(foundLeaderboard);
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw CustomException.InternalError(
                    $"An error occurred while deleting the leaderboard with ID {leaderboardId}: {ex.Message}"
                );
            }
        }

        public async Task<bool> UpdateOneAsync(Guid leaderboardId, LeaderboardUpdateDto updateDto)
        {
            var foundLeaderboard = await _leaderboardRepo.GetByIdAsync(leaderboardId);

            if (foundLeaderboard == null)
            {
                throw CustomException.NotFound(
                    $"Leaderboard with ID {leaderboardId} cannot be found for updating."
                );
            }
            _mapper.Map(updateDto, foundLeaderboard);
            return await _leaderboardRepo.UpdateOneAsync(foundLeaderboard);
        }

}
}