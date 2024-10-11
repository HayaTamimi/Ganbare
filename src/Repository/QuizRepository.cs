using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Database;
using ganbare.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ganbare.src.Repository
{
    public class QuizRepository
    {
        
        protected DbSet<Quiz> _quiz;
        protected DatabaseContext _databaseContext;

        public QuizRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
           _quiz = databaseContext.Set<Quiz>();
        }

        public async Task<Quiz> CreateOneAsync(Quiz newQuiz)
        {
            
            await _quiz.AddAsync(newQuiz);
            await _databaseContext.SaveChangesAsync();
            return newQuiz;
        }

        public async Task<bool> UpdateOneAsync(Quiz updateQuiz)
        {
            _quiz.Update(updateQuiz);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOneAsync(Quiz quiz)
        {
            _quiz.Remove(quiz);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        public async Task<Quiz?> GetByIdAsync(Guid id)
        {
            return await _quiz.FindAsync(id);
        }
        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _quiz.ToListAsync();
        }  
    }
}