using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Query;
using NURBNB.Alojamiento.Application.UseCases.Pais.Command.CrearPais;
using NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList;

namespace NURBNB.Alojamiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CiudadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearCiudadCommand command)
        {
            try
            {
                var ciudadId = await _mediator.Send(command);
                return Ok(ciudadId);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> SearchCities(string searchTerm = "")
        {
            var items = await _mediator.Send(new GetCiudadQueryList()
            {
                SearchTerm = searchTerm
            });

            return Ok(items);
        }
    }
}
