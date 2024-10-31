using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.Entity;
using ganbare.src.Repository;
using ganbare.src.Utils;
using static ganbare.src.DTO.QuizDTO;

namespace ganbare.src.Services.quiz
{
    public class QuizService : IQuizService
    {
        protected readonly QuizRepository _quizRepo;
        protected readonly ResultRepository _resultRepo;

        protected readonly IMapper _mapper;

        public QuizService(QuizRepository quizRepo, IMapper mapper, ResultRepository resultRepo)
        {
            _quizRepo = quizRepo;
            _mapper = mapper;
            _resultRepo = resultRepo;
        }
        public async Task<QuizReadDto> CreateOneAsync(QuizCreateDto createDto)
        {
            var quiz = _mapper.Map<QuizCreateDto, Quiz>(createDto);

            var quizCreated = await _quizRepo.CreateOneAsync(quiz);

            return _mapper.Map<Quiz, QuizReadDto>(quizCreated);
        }

        public async Task<List<QuizReadDto>> GetAllAsync(Logic logic)
        {
            var quizList = await _quizRepo.GetAllAsync(logic);
            return _mapper.Map<List<Quiz>, List<QuizReadDto>>(quizList);
        }

        public async Task<QuizReadDto> GetByIdAsync(Guid quizId)
        {
            var foundQuiz = await _quizRepo.GetByIdAsync(quizId);
            if (foundQuiz == null)
            {
                throw CustomException.NotFound($"Quiz with {quizId} cannot be found! ");
            }
            return _mapper.Map<Quiz, QuizReadDto>(foundQuiz);
        }


        public async Task<QuizReadDto> GetByLevel(QuizLevel? level)
        {
            var foundQuizLevel = await _quizRepo.GetByLevel(level);
            if (foundQuizLevel == null)
            {
                throw CustomException.NotFound($"Quiz with {level} cannot be found! ");
            }
            return _mapper.Map<Quiz, QuizReadDto>(foundQuizLevel);
        }

        // public async Task<List<QuizReadDto>> GetAllQuestionsByLevel(QuizLevel? level)
        // {
        //     var allQuizzes = await _quizRepo.GetAllQuestionsByLevel(level);

        //     if (!allQuizzes.Any())
        //     {
        //         throw CustomException.NotFound("No quizzes of the level found! ");
        //     }

        //     var filteredQuizzes = allQuizzes.Where(q => q.Level == level);

        //     return _mapper.Map<List<Quiz>, List<QuizReadDto>>(filteredQuizzes);

        // }

        //List<QuizReadDto> other function all quzzes

        /*
                public async Task<bool> DeleteOneAsync(Guid quizId)
                {
                    var foundQuiz = await _quizRepo.GetByIdAsync(quizId);
                    if (foundQuiz == null)
                    {
                        throw CustomException.NotFound(
                            $"Quiz with ID {quizId} is not found."
                        );
                    }
                    try
                    {
                        bool isDeleted = await _quizRepo.DeleteOneAsync(foundQuiz);
                        return isDeleted;
                    }
                    catch (Exception ex)
                    {
                        throw CustomException.InternalError(
                            $"An error occurred while deleting the quiz with ID {quizId}: {ex.Message}"
                        );
                    }
                }

                public async Task<bool> UpdateOneAsync(Guid quizId, QuizUpdateDto updateDto)
                {
                    var foundQuiz = await _quizRepo.GetByIdAsync(quizId);

                    if (foundQuiz == null)
                    {
                        throw CustomException.NotFound(
                            $"Quiz with ID {quizId} cannot be found for updating."
                        );
                    }
                    _mapper.Map(updateDto, foundQuiz);
                    return await _quizRepo.UpdateOneAsync(foundQuiz);
                }
                */
    }
}