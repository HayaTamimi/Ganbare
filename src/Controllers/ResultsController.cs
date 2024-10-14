using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ganbare.src.DTO.ResultDTO;

namespace ganbare.src.Controllers
{
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ResultsController : ControllerBase
    {
        protected readonly IResultService _resultService;

        public ResultsController(IResultService service)
        {
            _resultService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultReadDto>>> GetAll()
        {
            var resultList = await _resultService.GetAllAsync();
            return Ok(resultList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultReadDto>> GetById([FromRoute] Guid id)
        {
            var result = await _resultService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

/*
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOne(Guid id, ResultUpdateDto updateDto)
        {
            var resultUpdatedById = await _resultService.UpdateOneAsync(id, updateDto);
            if (!resultUpdatedById)
            {
                return NotFound();
            }
            return Ok();
        }
*/
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var resultDelete = await _resultService.DeleteOneAsync(id);
            if (!resultDelete)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}