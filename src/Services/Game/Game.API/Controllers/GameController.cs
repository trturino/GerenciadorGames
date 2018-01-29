using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using trturino.GerenciadorGames.Services.Game.API.Infra.Repo;

namespace trturino.GerenciadorGames.Services.Game.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(
            IGameRepository gameRepository
        )
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<Model.Game>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var itens = await _gameRepository.GetTodosAsync();

            return Ok(itens);
        }

        [HttpGet]
        [Route("[action]/disponiveis")]
        [ProducesResponseType(typeof(List<Model.Game>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDisponiveis()
        {
            var itens = await _gameRepository.GetDisponiveisAsync();

            return Ok(itens);
        }

        [HttpGet]
        [Route("[action]/:id")]
        [ProducesResponseType(typeof(Model.Game), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _gameRepository.GetAsync(id);

            if (item == default(Model.Game))
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(API.Model.Game), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Model.Game amigo)
        {
            if (amigo == default(API.Model.Game))
                return BadRequest();

            var item = await _gameRepository.AddAsync(amigo);

            return Accepted(item);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(Model.Game), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromBody] Model.Game amigo)
        {
            if (amigo == default(API.Model.Game))
                return BadRequest();

            var item = await _gameRepository.UpdateAsync(amigo);

            return Accepted(item);
        }
    }
}