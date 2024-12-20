using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Utils;
using static ganbare.src.DTO.ResultDTO;

namespace ganbare.src.Services.result
{
    public interface IResultService
    {
        Task<ResultReadDto> CreateOneAsync(ResultCreateDto createDto);//
        Task<List<ResultReadDto>> GetAllAsync(); //
        Task<ResultReadDto> GetByIdAsync(Guid resultId); //
        Task<bool> DeleteOneAsync(Guid resultId); //
        Task<List<ResultReadDto>> GetAllAsyncScores();
        Task<bool> UpdateOneAsync(Guid id, ResultUpdateDto updateDto);


    }
}