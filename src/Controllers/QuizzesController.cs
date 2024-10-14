using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.quiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ganbare.src.DTO.QuizDTO;
using static ganbare.src.DTO.UserDTO;

namespace ganbare.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuizzesController : ControllerBase
    {
       protected readonly IQuizService _quizService;

        public QuizzesController(IQuizService service)
        {
            _quizService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDto>>> GetAll()
        {
            var quizList = await _quizService.GetAllAsync();
            return Ok(quizList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuizReadDto>> GetById([FromRoute] Guid id)
        {
            var quiz = await _quizService.GetByIdAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

/*
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOne(Guid id, QuizUpdateDto updateDto)
        {
            var quizUpdatedById = await _quizService.UpdateOneAsync(id, updateDto);
            if (!quizUpdatedById)
            {
                return NotFound();
            }
            return Ok();
        

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var quizDelete = await _quizService.DeleteOneAsync(id);
            if (!quizDelete)
            {
                return NotFound();
            }
            return NoContent();
        }
*/
    }
}