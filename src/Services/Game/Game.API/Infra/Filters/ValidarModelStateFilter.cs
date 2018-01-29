using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace trturino.GerenciadorGames.Services.Game.API.Infra.Filters
{
    public class ValidarModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var erros = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            var json = new JsonErroResponse
            {
                Mensagens = erros
            };

            context.Result = new BadRequestObjectResult(json);
        }
    }
}
