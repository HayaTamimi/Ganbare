using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Services.question
{
    public interface IQuestionService
    {
        Task<QuestionReadDto> CreateOneAsync(Guid userGuid, QuestionCreateDto orderCreate);
        Task<List<QuestionReadDto>> GetAllAsync();

        Task<List<QuestionReadDto>> GetByIdAsync(Guid userId);

        Task<bool> DeleteOneAsync(Guid id, Guid userId, bool isAdmin);

        //Get by UserId
        Task<List<QuestionReadDto>> GetAllByUserIdAsync(Guid userId);

        //update
        Task<bool> UpdateOneAsync(Guid id, QuestionUpdateDto orderUpdate);

    }
}