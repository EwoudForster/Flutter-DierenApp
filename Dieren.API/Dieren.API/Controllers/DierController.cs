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
    public class DierController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DierController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Diers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DierDto>>> GetDiers()
        {
            var diers = await _uow.DierRepository.GetAllAsync(d => d.Users);
            var dierDtos = _mapper.Map<IEnumerable<DierDto>>(diers);
            return Ok(dierDtos);
        }

        // GET: api/Diers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DierDto>> GetDier(int id)
        {
            var dier = await _uow.DierRepository.GetByIDAsync(id, d => d.Users);

            if (dier == null)
            {
                return NotFound();
            }

            var dierDto = _mapper.Map<DierDto>(dier); // Map to DierDto
            return Ok(dierDto);
        }

        // PUT: api/Diers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDier(int id, Dier dier)
        {
            if (id != dier.DierId)
            {
                return BadRequest();
            }

            _uow.DierRepository.Update(dier);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DierExists(id))
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

        // POST: api/Diers
        [HttpPost]
        public async Task<ActionResult<Dier>> PostDier(Dier dier)
        {
            _uow.DierRepository.Insert(dier);
            await _uow.SaveAsync();

            var dierDto = _mapper.Map<DierDto>(dier);
            return CreatedAtAction("GetDier", new { id = dier.DierId }, dierDto);
        }

        // DELETE: api/Diers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDier(int id)
        {
            var dier = await _uow.DierRepository.GetByIDAsync(id);
            if (dier == null)
            {
                return NotFound();
            }

            _uow.DierRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool DierExists(int id)
        {
            return _uow.DierRepository.Get(e => e.DierId == id).Any();
        }
    }
}
