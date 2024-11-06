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
        Task<List<QuizReadDto>> GetAllAsync();
        Task<QuizReadDto> GetByIdAsync(Guid quizId);
        Task<bool> DeleteOneAsync(Guid Quiz);

        Task<List<QuizReadDto>>GetByLevel(QuizLevel? level);
       // Task<QuizReadDto> GetAllQuestionsByLevel (QuizLevel? level); 


    }
}