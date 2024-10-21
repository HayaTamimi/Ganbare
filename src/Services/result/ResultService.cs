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

        public async Task<List<ResultReadDto>> GetAllAsync(Logic logic)
        {
            var resultList = await _resultRepo.GetAllAsync(logic);
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

        //        Task<List<ResultReadDto>> GetSpeed(TimeSpan speed);
        // public async Task<List<ResultReadDto>> GetSpeed(TimeSpan speed)
        // {var resultSpeed = await _resultRepo.GetSpeed(speed);
        //var resultOFS = _mapper.Map<List<Result>, List<ResultReadDto>>(resultSpeed);
        // return resultOFS; }

        /*
                public async Task<List<ResultReadDto>> GetAllAsyncScores(Logic logic)
                {
                    var results = await _resultRepo.GetAllAsyncScores();
                    var resultMap = _mapper.Map<List<Result>, List<ResultReadDto>>(results);
                    return resultMap;
                }
        
class Pet
{
    public string Name { get; set; }
    public double Age { get; set; }
}

public static void GroupByEx4()
{
    List<Pet> petsList = new List<Pet>{   new Pet { Name="Daisy", Age=4.3 } };
    var query = petsList.GroupBy(
        pet => Math.Floor(pet.Age),
        pet => pet.Age,
        (baseAge, ages) => new
        {
            Key = baseAge,
            Count = ages.Count(),
            Min = ages.Min(),
            Max = ages.Max()
        });}*/
        public async Task<List<ResultReadDto>> GetAllAsyncScores() // I tried everything inside() and nothing worked
        {
            var query = await _result.GroupBy(r => r.UserId) //_resultRepo  didn't work
                .Select(result => new
                {
                    UserId = result.Key,
                    TotalScore = result.Sum(result => result.TotalScore)
                })
                .OrderByDescending(r => r.TotalScore)
                .ThenBy(r => r.Speed)
                .ToListAsync();

            //list of result objects
            return query.Select(result => new Result
            {
                UserId = result.UserId,
                TotalScore = result.TotalScore
            }).ToList();
        }
        /*
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
                                }*/
    }
}