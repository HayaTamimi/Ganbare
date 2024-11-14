using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.question;
using ganbare.src.Services.user;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ganbare.src.DTO.QuestionDTO;

namespace ganbare.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuestionsController : ControllerBase
    {
        protected readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService service)
        {
            _questionService = service;
        }


        [HttpPost]
       //  [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuestionReadDto>> CreateOne([FromBody] QuestionCreateDto createDto)
        {
            var questionCreated = await _questionService.CreateOneAsync(createDto);
            return Ok(questionCreated);
        }

        [HttpGet]
        public async Task<ActionResult<List<QuestionReadDto>>> GetAll()
        {
            var questionList = await _questionService.GetAllAsync();
            return Ok(questionList);
        }

        [HttpGet("{id}")]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuestionReadDto>> GetById([FromRoute] Guid id)
        {
            var question = await _questionService.GetByIdAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpPut("{id}")]
   // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOne(Guid id, QuestionUpdateDto updateDto)
        {
            var questionUpdatedById = await _questionService.UpdateOneAsync(id, updateDto);
            if (!questionUpdatedById)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
   // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var questionDelete = await _questionService.DeleteOneAsync(id);
            if (!questionDelete)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}