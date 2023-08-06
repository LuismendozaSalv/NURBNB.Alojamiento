using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NURBNB.Alojamiento.Application.UseCases.Pais.Command.CrearPais;
using NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList;

namespace NURBNB.Alojamiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearPaisCommand command)
        {
            var paisId = await _mediator.Send(command);
            return Ok(paisId);
        }

        [HttpGet]
        public async Task<IActionResult> SearchCountries(string searchTerm = "")
        {
            var items = await _mediator.Send(new GetPaisQueryList ()
            {
                SearchTerm = searchTerm
            });

            return Ok(items);
        }
    }
}
