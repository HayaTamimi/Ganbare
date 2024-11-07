using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Database;
using ganbare.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ganbare.src.Repository
{
    public class OptionRepository
    {
        protected DbSet<Option> _option;
        protected DatabaseContext _databaseContext;

        public OptionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
           _option = databaseContext.Set<Option>();
        }

        public async Task<Option> CreateOneAsync(Option newOption)
        {
            
            await _option.AddAsync(newOption);
            await _databaseContext.SaveChangesAsync();
            return newOption;
        }

        public async Task<bool> UpdateOneAsync(Option updateOption)
        {
            _option.Update(updateOption);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOneAsync(Option option)
        {
            _option.Remove(option);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<Option?> GetByIdAsync(Guid id)
        
        {
           return await _option.FindAsync(id);
        }
        public async Task<List<Option>> GetAllAsync()
        {
            return await _option.ToListAsync();
        }     

         public async Task<List<Option>> GetAllByQuestionId(Guid questionId)
        {
            return await _option.Where((option) => 
            option.QuestionId == questionId).ToListAsync();
        }     
    }
}