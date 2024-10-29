using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Database;
using ganbare.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ganbare.src.Repository
{
    public class QuestionRepository
    {
        protected DbSet<Question> _question;
        protected DatabaseContext _databaseContext;

        public QuestionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _question = databaseContext.Set<Question>();
        }

        public async Task<Question> CreateOneAsync(Question newQuestion)
        {

            await _question.AddAsync(newQuestion);
            await _databaseContext.SaveChangesAsync();
            return newQuestion;
        }

        public async Task<bool> UpdateOneAsync(Question updateQuestion)
        {
            _question.Update(updateQuestion);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOneAsync(Question question)
        {
            _question.Remove(question);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<Question?> GetByIdAsync(Guid id)
        {
            return await _question.FindAsync(id);
        }
        public async Task<List<Question>> GetAllAsync()
        {
            return await _question.ToListAsync();
        }


    }
}