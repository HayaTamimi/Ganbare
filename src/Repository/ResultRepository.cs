using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Database;
using ganbare.src.Entity;
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
        public async Task<List<Result>> GetAllAsync()
        {
            return await _result.ToListAsync();
        }        
    }
}