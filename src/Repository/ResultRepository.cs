using System.Text.RegularExpressions;
using AutoMapper;
using ganbare.src.Database;
using ganbare.src.Entity;
using ganbare.src.Utils;
using Microsoft.EntityFrameworkCore;


namespace ganbare.src.Repository
{
    public class ResultRepository
    {
        protected DbSet<Result> _result;
        protected DatabaseContext _databaseContext;


        public ResultRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _result = databaseContext.Set<Result>();

        }

        public async Task<Result> AddResultAsync(Result newResult)
        {
            await _result.AddAsync(newResult);
            await _databaseContext.SaveChangesAsync();
            return newResult;

        }

        public async Task<Result> CreateOneAsync(Result newResult)
        {

            await _result.AddAsync(newResult);
            await _databaseContext.SaveChangesAsync();
            return newResult;
        }

        public async Task<bool> UpdateOneAsync(Result updateResult)
        {
            _result.Update(updateResult);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOneAsync(Result result)
        {
            _result.Remove(result);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<Result?> GetByIdAsync(Guid id)
        {
            return await _result.FindAsync(id);
        }
        public async Task<List<Result>> GetAllAsync(Logic logic)
        {

            return await _result.ToListAsync();
        }

        public async Task<List<Result>> GetSpeed(TimeSpan speed)
        {
            var list = await _result.Include(l => l.Quiz).ToListAsync();
            return list;
        }
        public async Task<List<Result>> GetAllAsyncScores()
        {       // to get the order on the leaderboard 
                // order by total scores
                // then by speed
            var userResults = await _result.GroupBy(r => r.UserId)
            .Select(Group => new
            {
                UserId = Group.Key,
                TotalScore = Group.Sum(result => result.TotalScore),
                Speed = Group.Quiz.TimeTaken
            })
                .OrderBy(r => r.TotalScore)
                .ThenBy(r => r.Speed)
                .ToListAsync();

            return userResults;
        }


            //var results = await _resultRepo.GetAllAsyncScores();
            // var resultMap = _mapper.Map<List<Result>, List<ResultReadDto>>(results);
            //return resultMap;
    }
}
