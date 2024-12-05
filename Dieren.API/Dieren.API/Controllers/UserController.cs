using AutoMapper;
using Dieren.DAL.Dtos;
using Dieren.DAL.Models;
using Dieren.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dieren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _uow.UserRepository.GetAllAsync(d => d.Dieren);
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _uow.UserRepository.GetByIDAsync(id, d => d.Dieren);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _uow.UserRepository.Update(user);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(User user)
        {
            _uow.UserRepository.Insert(user);
            await _uow.SaveAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return CreatedAtAction("GetUser", new { id = user.UserId }, userDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _uow.UserRepository.GetByIDAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _uow.UserRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _uow.UserRepository.Get(e => e.UserId == id).Any();
        }
    }
}
