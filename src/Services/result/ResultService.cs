using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.DTO;
using ganbare.src.Entity;
using ganbare.src.Repository;
using ganbare.src.Utils;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using static ganbare.src.DTO.ResultDTO;


namespace ganbare.src.Services.result
{
    public class ResultService : IResultService
    {
        protected readonly ResultRepository _resultRepo;
        protected readonly IMapper _mapper;

        public ResultService(ResultRepository resultRepo, IMapper mapper)
        {
            _resultRepo = resultRepo;
            _mapper = mapper;

        }

        public async Task<List<ResultReadDto>> GetAllAsync()
        {
            var resultList = await _resultRepo.GetAllAsync();
            return _mapper.Map<List<Result>, List<ResultReadDto>>(resultList);
        }

        public async Task<ResultReadDto> GetByIdAsync(Guid resultId)
        {
            var foundResult = await _resultRepo.GetByIdAsync(resultId);
            if (foundResult == null)
            {
                throw CustomException.NotFound($"Result with {resultId} cannot be found! ");
            }
            return _mapper.Map<Result, ResultReadDto>(foundResult);
        }

        public async Task<bool> DeleteOneAsync(Guid resultId)
        {
            var foundResult = await _resultRepo.GetByIdAsync(resultId);
            if (foundResult == null)
            {
                throw CustomException.NotFound(
                    $"Result with ID {resultId} is not found."
                );
            }
            try
            {
                bool isDeleted = await _resultRepo.DeleteOneAsync(foundResult);
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw CustomException.InternalError(
                    $"An error occurred while deleting the result with ID {foundResult}: {ex.Message}"
                );
            }
        }

        public async Task<ResultReadDto> CreateOneAsync(ResultCreateDto createDto)
        {
            var result = _mapper.Map<ResultCreateDto, Result>(createDto);

            var resultCreated = await _resultRepo.CreateOneAsync(result);

            return _mapper.Map<Result, ResultReadDto>(resultCreated);
        }

        public async Task<List<ResultReadDto>> GetAllAsyncScores() // IMPORTENT
        {

            var resultList = await _resultRepo.GetAllAsyncScores();
            var resultScores = _mapper.Map<List<Result>, List<ResultReadDto>>(resultList);


            resultScores[0].TotalScore = resultScores[0].Quizzes.Sum(r => r.QuizScore);


            // resultScores[0].TotalScore = 100;

            return resultScores;

        }

        public async Task<bool> UpdateOneAsync(Guid resultId, ResultUpdateDto updateDto)
        {
            var foundResult = await _resultRepo.GetByIdAsync(resultId);

            if (foundResult == null)
            {
                throw CustomException.NotFound(
                    $"Result with ID {resultId} cannot be found for updating."
                );
            }
            _mapper.Map(updateDto, foundResult);
            return await _resultRepo.UpdateOneAsync(foundResult);
        }
    }
}