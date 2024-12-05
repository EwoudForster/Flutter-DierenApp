using AutoMapper;
using Dieren.DAL.Dtos;
using Dieren.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dieren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ScoreController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Score
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserScoreDto>>> GetScores()
        {
            // pak alle users
            var users = await _uow.UserRepository.GetAllAsync(u => u.Dieren);

            // Bereken de score per user
            var userScores = users.Select(user => new UserScoreDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Score = user.Dieren?.Sum(d => d.Points) ?? 0
            })
            .ToList()
            .OrderBy(u => u.Score) // Sorteer op score
            .ToList();


            return Ok(userScores);
        }
    }
}
