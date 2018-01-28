using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amigo.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amigo.API.Controllers
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
    }
}