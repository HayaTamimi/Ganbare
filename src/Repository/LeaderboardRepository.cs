using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Database;
using ganbare.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ganbare.src.Repository
{
    public class LeaderboardRepository
    {
        protected DbSet<Leaderboard> _leaderboard;
        protected DatabaseContext _databaseContext;

        public LeaderboardRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _leaderboard = databaseContext.Set<Leaderboard>();
        }

        public async Task<Leaderboard> CreateOneAsync(Leaderboard newLeaderboard)
        {

            await _leaderboard.AddAsync(newLeaderboard);
            await _databaseContext.SaveChangesAsync();
            return newLeaderboard;
        }
        

        public async Task<bool> UpdateOneAsync(Leaderboard updateLeaderboard)
        {
            _leaderboard.Update(updateLeaderboard);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOneAsync(Leaderboard leaderboard)
        {
            _leaderboard.Remove(leaderboard);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<Leaderboard?> GetByIdAsync(Guid id)
        {
            return await _leaderboard.FindAsync(id);
        }
        public async Task<List<Leaderboard>> GetAllAsync()
        {
            return await _leaderboard.ToListAsync();
        }

    }
}