using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.option;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ganbare.src.DTO.OptionDTO;

namespace ganbare.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class OptionsController : ControllerBase
    {
        protected readonly IOptionService _optionService;

        public OptionsController(IOptionService service)
        {
            _optionService = service;
        }
 
        [HttpPost]
     [Authorize(Roles = "Admin")]
        public async Task<ActionResult<OptionReadDto>> CreateOne([FromBody] OptionCreateDto createDto)
        {
            var optionCreated = await _optionService.CreateOneAsync(createDto);
            return Ok(optionCreated);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<OptionReadDto>>> GetAll()
        {
            var optionList = await _optionService.GetAllAsync();
            return Ok(optionList);
        }

        [HttpGet("{id}")]
         [Authorize(Roles = "Admin")]
        public async Task<ActionResult<OptionReadDto>> GetById([FromRoute] Guid id)
        {
            var option = await _optionService.GetByIdAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOne(Guid id, OptionUpdateDto updateDto)
        {
            var optionUpdatedById = await _optionService.UpdateOneAsync(id, updateDto);
            if (!optionUpdatedById)
            {
                return NotFound();
            }
            return Ok();
        }

         [HttpGet("/questions/{questionsId}")]  
         [Authorize(Roles = "Admin")]
        public async Task<ActionResult<OptionReadDto>> GetAllByQuestionId([FromRoute] Guid questionId)
        {
            var option = await _optionService.GetAllByQuestionId(questionId);

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var optionDelete = await _optionService.DeleteOneAsync(id);
            if (!optionDelete)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}