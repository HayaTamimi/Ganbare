using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ganbare.src.DTO.QuestionDTO;

namespace ganbare.src.Services.question
{
    public interface IQuestionService
    {
        Task<QuestionReadDto> CreateOneAsync(QuestionCreateDto createDto);
        Task<List<QuestionReadDto>> GetAllAsync();
        Task<QuestionReadDto> GetByIdAsync(Guid questionId);
        Task<bool> DeleteOneAsync(Guid questionId);
        Task<bool> UpdateOneAsync(Guid questionId, QuestionUpdateDto updateDto);

    }
}