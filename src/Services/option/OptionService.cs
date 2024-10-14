using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.Entity;
using ganbare.src.Repository;
using ganbare.src.Utils;
using static ganbare.src.DTO.OptionDTO;

namespace ganbare.src.Services.option
{
    public class OptionService : IOptionService
    {
        protected readonly OptionRepository _optionRepo;
        protected readonly IMapper _mapper;

        public OptionService(OptionRepository optionRepo, IMapper mapper)
        {
            _optionRepo = optionRepo;
            _mapper = mapper;
        }
        public async Task<OptionReadDto> CreateOneAsync(OptionCreateDto createDto)
        {
            var option = _mapper.Map<OptionCreateDto, Option>(createDto);

            var optionCreated = await _optionRepo.CreateOneAsync(option);

            return _mapper.Map<Option, OptionReadDto>(optionCreated);
        }

        public async Task<List<OptionReadDto>> GetAllAsync()
        {
            var optionList = await _optionRepo.GetAllAsync();
            return _mapper.Map<List<Option>, List<OptionReadDto>>(optionList);
        }

        public async Task<OptionReadDto> GetByIdAsync(Guid optionId)
        {
            var foundOption = await _optionRepo.GetByIdAsync(optionId);
            if (foundOption == null)
            {
                throw CustomException.NotFound($"Option with {optionId} cannot be found! ");
            }
            return _mapper.Map<Option, OptionReadDto>(foundOption);
        }

        public async Task<bool> DeleteOneAsync(Guid optionId)
        {
            var foundOption = await _optionRepo.GetByIdAsync(optionId);
            if (foundOption == null)
            {
                throw CustomException.NotFound(
                    $"Option with ID {optionId} is not found."
                );
            }
            try
            {
                bool isDeleted = await _optionRepo.DeleteOneAsync(foundOption);
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw CustomException.InternalError(
                    $"An error occurred while deleting the option with ID {optionId}: {ex.Message}"
                );
            }
        }

        public async Task<bool> UpdateOneAsync(Guid optionId, OptionUpdateDto updateDto)
        {
            var foundOption = await _optionRepo.GetByIdAsync(optionId);

            if (foundOption == null)
            {
                throw CustomException.NotFound(
                    $"Option with ID {optionId} cannot be found for updating."
                );
            }
            _mapper.Map(updateDto, foundOption);
            return await _optionRepo.UpdateOneAsync(foundOption);
        }
    }
}