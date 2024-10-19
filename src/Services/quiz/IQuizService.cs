using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;
using ganbare.src.Utils;
using static ganbare.src.DTO.QuizDTO;

namespace ganbare.src.Services.quiz
{
    public interface IQuizService
    {
        Task<QuizReadDto> CreateOneAsync(QuizCreateDto createDto);
        //Task<QuizReadDto> CreateOneAsync(Guid userId, QuizCreateDto createDto);
        //Task<QuizReadDto> CreateOneAsync(Guid userId, Guid questionId, QuizCreateDto createDto);
        //Task<List<QuizReadDto>> GetAllAsync();
        Task<List<QuizReadDto>> GetAllAsync(Logic logic);
        Task<QuizReadDto> GetByIdAsync(Guid quizId);

        Task<QuizReadDto> GetByLevelAsync(QuizLevel quizLevel);

        //Task<List<QuizReadDto>> GetAllAsyncByLevels(); // didn't made logic of it yet

        //Task<Quiz> GetPoints(QuizLevel level);
       // public Task<Result> QuizResults(Guid id);

        //Task<bool> DeleteOneAsync(Guid quizId);
        //Task<bool> UpdateOneAsync(Guid quizId, QuizUpdateDto updateDto);

    }
}