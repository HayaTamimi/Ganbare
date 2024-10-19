using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Database;
using ganbare.src.Entity;
using ganbare.src.Utils;
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

         public async Task<Quiz?> GetByLevelAsync(QuizLevel quizLevel)
        {
            return await _quiz.FindAsync(quizLevel);

        }
        public async Task<List<Quiz>> GetAllAsync(Logic logic)
        {
            IQueryable<Quiz> query = _quiz;

            await query.Where(x => x.Level == QuizLevel.One).ToListAsync();
            await query.Where(x => x.Level == QuizLevel.Two).ToListAsync();
            await query.Where(x => x.Level == QuizLevel.Three).ToListAsync();
            await query.Where(x => x.Level == QuizLevel.Four).ToListAsync();
            await query.Where(x => x.Level == QuizLevel.Five).ToListAsync();

            if (logic.LevelScore == "One")
            {
                query = query.Where(q => q.QuizScore == 3);
            }
            else if (logic.LevelScore == "Two")
            {
                query = query.Where(q => q.QuizScore == 2.5);
            }
            else if (logic.LevelScore == "Three")
            {
                query = query.Where(q => q.QuizScore == 2);
            }
            else if (logic.LevelScore == "Four")
            {
                query = query.Where(q => q.QuizScore == 1.5);
            }
            else if (logic.LevelScore == "Five")
            {
                query = query.Where(q => q.QuizScore == 1);
            }

            return await query.ToListAsync();
        }

    }

}