using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trturino.GerenciadorGames.Services.API.Model;

namespace trturino.GerenciadorGames.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [Authorize]
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
        [Route("action")]
        [ProducesResponseType(typeof(List<Amigo>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var itens = await _amigoRespository.GetTodosAmigosAsync();

            return Ok(itens);
        }
    }
}