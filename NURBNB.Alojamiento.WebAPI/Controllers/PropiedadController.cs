using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;

namespace NURBNB.Alojamiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {

        private readonly IMediator _mediator;
        public PropiedadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearPropiedadCommand command)
        {
            var propiedadId = await _mediator.Send(command);
            return Ok(propiedadId);
        }
    }
}
