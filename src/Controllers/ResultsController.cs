using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.result;
using ganbare.src.Utils;
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
        public async Task<ActionResult<List<ResultReadDto>>> GetAll(Logic logic)
        {
            var resultList = await _resultService.GetAllAsync(logic);
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsyncScores( )
        {
            var resultReadDtos = await _resultService.GetAllAsyncScores();
            return Ok(resultReadDtos);
        }


   //public async Task<ActionResult> GetSpeed([FromRoute] TimeSpan speed)
       // { var speedOfQuiz = await _resultService.GetSpeed(speed);
//            var speeds = speedOfQuiz.FindAll(s =>
         //       s.Result.Speed == speed
         //   );if (speeds == null)
        //    { return NotFound(); }return Ok(speeds);}
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
    }
}