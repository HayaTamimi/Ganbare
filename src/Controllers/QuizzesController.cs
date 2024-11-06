using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;
using ganbare.src.Services.quiz;
using ganbare.src.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication.PgOutput.Messages;
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


        [HttpPost]
        //  [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuizReadDto>> CreateOne([FromBody] QuizCreateDto createDto)
        {
            var quizCreated = await _quizService.CreateOneAsync(createDto);
            return Ok(quizCreated);
        }


        [HttpGet]
        public async Task<ActionResult<List<UserReadDto>>> GetAll()
        {
            var quizList = await _quizService.GetAllAsync();
            return Ok(quizList);
        }

        [HttpGet("{id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuizReadDto>> GetById([FromRoute] Guid id)
        {
            var quiz = await _quizService.GetByIdAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }


        [HttpGet("quizzes")] // Get one quiz by level
        public async Task<ActionResult<QuizReadDto>> GetByLevel(QuizLevel? level)
        {
            var quizLevel = await _quizService.GetByLevel(level);

            // if (level.HasValue)
            // {
            //     quizLevel = quizLevel.Where(q => q.Level == level);
            // }

            // var quizzes = await quizLevel.ToListAsync();
            return Ok(quizLevel);
        }

        // [HttpGet("quizzes/{level}")] // GET => /quizzes?level=n5 
        // public async Task<ActionResult<List<QuizReadDto>> GetAllQuestionsByLevel(QuizLevel? level)
        // {

        //     var quizLevel = await _quizService.GetAllQuestionsByLevel(level);

        //     return Ok(quizLevel);
        // }

        /* [HttpPut("{id}")]
         [Authorize(Roles = "Admin")]
         public async Task<ActionResult> UpdateOne(Guid id, QuizUpdateDto updateDto)
         {
             var quizUpdatedById = await _quizService.UpdateOneAsync(id, updateDto);
             if (!quizUpdatedById)
             {
                 return NotFound();
             }
             return Ok(); */


         [HttpDelete("{id}")]
         //[Authorize(Roles = "Admin")]
         public async Task<ActionResult> DeleteOne(Guid id)
         {
             var quizDelete = await _quizService.DeleteOneAsync(id);
             if (!quizDelete)
             {
                 return NotFound();
             }
             return NoContent();
         }

    }
}