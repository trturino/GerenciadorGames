using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using trturino.GerenciadorGames.Services.Emprestimo.API.Infra.Repo;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/emprestimo")]
    //[Authorize]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoController(
            IEmprestimoRepository emprestimoRepository
        )
        {
            _emprestimoRepository = emprestimoRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Model.Emprestimo>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var itens = await _emprestimoRepository.GetTodosAsync();

            return Ok(itens);
        }

        [HttpGet]
        [Route("amigo/{id}")]
        [ProducesResponseType(typeof(List<Model.Emprestimo>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByAmigo(int id)
        {
            var itens = await _emprestimoRepository.GetByAmigoId(id);

            return Ok(itens);
        }

        [HttpGet]
        [Route("game/{id}")]
        [ProducesResponseType(typeof(List<Model.Emprestimo>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByGameId(int id)
        {
            var itens = await _emprestimoRepository.GetByGameId(id);

            return Ok(itens);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Model.Emprestimo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _emprestimoRepository.GetAsync(id);

            if (item == default(Model.Emprestimo))
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(API.Model.Emprestimo), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Model.Emprestimo amigo)
        {
            if (amigo == default(API.Model.Emprestimo))
                return BadRequest();

            var item = await _emprestimoRepository.AddAsync(amigo);

            return Accepted(item);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Model.Emprestimo), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromBody] Model.Emprestimo amigo)
        {
            if (amigo == default(API.Model.Emprestimo))
                return BadRequest();

            var item = await _emprestimoRepository.UpdateAsync(amigo);

            return Accepted(item);
        }
    }
}