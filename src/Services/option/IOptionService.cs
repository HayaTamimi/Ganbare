using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ganbare.src.DTO.OptionDTO;

namespace ganbare.src.Services.option
{
    public interface IOptionService
    {
        Task<OptionReadDto> CreateOneAsync(OptionCreateDto createDto);
        Task<List<OptionReadDto>> GetAllAsync();
        Task<OptionReadDto> GetByIdAsync(Guid resultId);
        Task<bool> DeleteOneAsync(Guid resultId);
        Task<bool> UpdateOneAsync(Guid resultId, OptionUpdateDto updateDto);
    }
}