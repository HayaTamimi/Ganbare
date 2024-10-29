using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.Entity;
using ganbare.src.Repository;
using ganbare.src.Utils;
using static ganbare.src.DTO.QuestionDTO;

namespace ganbare.src.Services.question
{

    public class QuestionService : IQuestionService
    {
        protected readonly QuestionRepository _questionRepo;
        protected readonly IMapper _mapper;

        public QuestionService(QuestionRepository questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }
        public async Task<QuestionReadDto> CreateOneAsync(QuestionCreateDto createDto)
        {
            var question = _mapper.Map<QuestionCreateDto, Question>(createDto);

            var questionCreated = await _questionRepo.CreateOneAsync(question);

            return _mapper.Map<Question, QuestionReadDto>(questionCreated);
        }

        public async Task<List<QuestionReadDto>> GetAllAsync()
        {
            var questionList = await _questionRepo.GetAllAsync();
            return _mapper.Map<List<Question>, List<QuestionReadDto>>(questionList);
        }

        public async Task<QuestionReadDto> GetByIdAsync(Guid questionId)
        {
            var foundQuestion = await _questionRepo.GetByIdAsync(questionId);
            if (foundQuestion == null)
            {
                throw CustomException.NotFound($"Question with {questionId} cannot be found! ");
            }
            return _mapper.Map<Question, QuestionReadDto>(foundQuestion);
        }

        public async Task<bool> DeleteOneAsync(Guid questionId)
        {
            var foundQuestion = await _questionRepo.GetByIdAsync(questionId);
            if (foundQuestion == null)
            {
                throw CustomException.NotFound(
                    $"Question with ID {questionId} is not found."
                );
            }
            try
            {
                bool isDeleted = await _questionRepo.DeleteOneAsync(foundQuestion);
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw CustomException.InternalError(
                    $"An error occurred while deleting the question with ID {questionId}: {ex.Message}"
                );
            }
        }

        public async Task<bool> UpdateOneAsync(Guid questionId, QuestionUpdateDto updateDto)
        {
            var foundQuestion = await _questionRepo.GetByIdAsync(questionId);

            if (foundQuestion == null)
            {
                throw CustomException.NotFound(
                    $"Question with ID {questionId} cannot be found for updating."
                );
            }
            _mapper.Map(updateDto, foundQuestion);
            return await _questionRepo.UpdateOneAsync(foundQuestion);
        }


    }
}
