using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ganbare.src.Controllers;
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

        public async Task<List<Quiz>> GetByLevel(QuizLevel? level)
        {
            return await _quiz.Where(quiz => quiz.Level == level).ToListAsync();
        }
        //comment same
        //  public async Task<Quiz?> GetAllQuestionsByLevel(QuizLevel? level) //check
        // {
        //     return await _quiz.FindAsync(level);

        // }

        // public int CalculateQuizScore(Quiz quiz, List<Question> questions, List<Option> options)
        // {
        //     int quizScore = 0;

        //     foreach (var question in questions)
        //     {
        //         var userChoice = options.FirstOrDefault(x => x.QuestionId == question.QuestionId);

        //         if (question != null && userChoice != null)
        //         {
        //             var correct = question.Options.FirstOrDefault(o => o.IsCorrect);

        //             if (correct != null && correct.OptionId == userChoice.OptionId)
        //             {
        //                 quizScore++;
        //             }
        //         }
        //     }

        //     return quizScore;
        // }

        public async Task<List<Quiz>> GetAllAsync()
        {

            IQueryable<Quiz> query = _quiz;

            //await query.Where(x => x.Level == QuizLevel.One).ToListAsync();

            // if (logic.LevelScore == "N1")
            // {
            //     query = query.Where(q => q.QuizScore == 3);
            // }
            // else if (logic.LevelScore == "N2")
            // {
            //     query = query.Where(q => q.QuizScore == 2.5);
            // }
            // else if (logic.LevelScore == "N3")
            // {
            //     query = query.Where(q => q.QuizScore == 2);
            // }
            // else if (logic.LevelScore == "N4")
            // {
            //     query = query.Where(q => q.QuizScore == 1.5);
            // }
            // else if (logic.LevelScore == "N5")
            // {
            //     query = query.Where(q => q.QuizScore == 1);
            // }
            query = query.Take(10);

            return await query.ToListAsync();
        }

    }

}