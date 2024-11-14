using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.leaderboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ganbare.src.DTO.LeaderboardDTO;

namespace ganbare.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LeaderboardsController : ControllerBase
    {
        protected readonly ILeaderboardService _leaderboardService;
        public LeaderboardsController(ILeaderboardService service)
        {
            _leaderboardService = service;
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<LeaderboardReadDto>> CreateOne([FromBody] LeaderboardCreateDto createDto)
        {
            var leaderboardCreated = await _leaderboardService.CreateOneAsync(createDto);
            return Ok(leaderboardCreated);
   
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaderboardReadDto>>> GetAll()
        {
            var leaderboardList = await _leaderboardService.GetAllAsync();
            return Ok(leaderboardList);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<LeaderboardReadDto>> GetById([FromRoute] Guid id)
        {
            var leaderboard = await _leaderboardService.GetByIdAsync(id);

            if (leaderboard == null)
            {
                return NotFound();
            }

            return Ok(leaderboard);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOne(Guid id, LeaderboardUpdateDto updateDto)
        {
            var leaderboardUpdatedById = await _leaderboardService.UpdateOneAsync(id, updateDto);
            if (!leaderboardUpdatedById)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var leaderboardDelete = await _leaderboardService.DeleteOneAsync(id);
            if (!leaderboardDelete)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}