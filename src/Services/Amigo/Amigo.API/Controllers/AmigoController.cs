using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using trturino.GerenciadorGames.Services.API.Model;

namespace trturino.GerenciadorGames.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AmigoController : Controller
    {
        private readonly IAmigoRespository _amigoRespository;

        public AmigoController(
            IAmigoRespository amigoRespository
            )
        {
            _amigoRespository = amigoRespository;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<Amigo>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var itens = await _amigoRespository.GetTodosAmigosAsync();

            return Ok(itens);
        }

        [HttpGet]
        [Route("[action]/:id")]
        [ProducesResponseType(typeof(Amigo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _amigoRespository.GetAmigoAsync(id);

            if (item == default(Amigo))
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(Amigo), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Amigo amigo)
        {
            if (amigo == default(Amigo))
                return BadRequest();

            var item = await _amigoRespository.AddAmigoAsync(amigo);

            return Accepted(item);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(Amigo), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromBody] Amigo amigo)
        {
            if (amigo == default(Amigo))
                return BadRequest();

            var item = await _amigoRespository.UpdateAmigoAsync(amigo);

            return Accepted(item);
        }
    }
}