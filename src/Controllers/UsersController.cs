using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Services.user;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ganbare.src.DTO.UserDTO;

namespace ganbare.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase

    {
        protected readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserReadDto>>> GetAll()
        {
            var userList = await _userService.GetAllAsync();
            return Ok(userList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserReadDto>> GetById([FromRoute] Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOne(Guid id, UserUpdateDto updateDto)
        {
            var userUpdatedById = await _userService.UpdateOneAsync(id, updateDto);
            if (!userUpdatedById)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var userDelete = await _userService.DeleteOneAsync(id);
            if (!userDelete)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("signUp")]
        public async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto createDto)
        {
            var UserCreated = await _userService.CreateOneAsync(createDto);
            return Ok(UserCreated);
        }

//and you can get the client_id from Google Developer Console

        [HttpPost("signIn")]
        public async Task<ActionResult<string>> SignInUser([FromBody] UserSigninDto createDto)
        {
            var token = await _userService.SignInAsync(createDto);
            if (token == "Not Found")
            {
                return NotFound();
            }
            else if (token == "Unauthorized")
            {
                return Unauthorized();
            }
            else
                return Ok(token);
        }
    }

}