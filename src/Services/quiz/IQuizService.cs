using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;
using static ganbare.src.DTO.QuizDTO;

namespace ganbare.src.Services.quiz
{
    public interface IQuizService
    {
        Task<QuizReadDto> CreateOneAsync(QuizCreateDto createDto);
        //Task<QuizReadDto> CreateOneAsync(Guid userId, QuizCreateDto createDto);
        //Task<QuizReadDto> CreateOneAsync(Guid userId, Guid questionId, QuizCreateDto createDto);
        Task<List<QuizReadDto>> GetAllAsync();
        Task<QuizReadDto> GetByIdAsync(Guid quizId);
        Task<bool> DeleteOneAsync(Guid quizId);
        Task<bool> UpdateOneAsync(Guid quizId, QuizUpdateDto updateDto);
        //Task<List<QuizReadDto>> GetAllAsyncByLevels(Level level); // To get the quizzes of specific level

    }
}