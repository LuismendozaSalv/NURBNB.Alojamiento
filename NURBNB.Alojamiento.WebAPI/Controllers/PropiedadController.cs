using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarComodidadesPropiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarDireccionPropiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReglasPropiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Query;

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
        [Route("CrearPropiedad")]
        public async Task<IActionResult> CrearPropiedad([FromBody] CrearPropiedadCommand command)
        {
            try
            {
                var propiedadId = await _mediator.Send(command);
                return Ok(propiedadId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarDireccion")]
        public async Task<IActionResult> AgregarDireccion([FromBody] AgregarDireccionPropiedadCommand command)
        {
            try
            {
                var propiedadId = await _mediator.Send(command);
                return Ok(propiedadId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarFotos")]
        public async Task<IActionResult> AgregarFotos([FromBody] AgregarFotosPropiedadCommand command)
        {
            try
            {
                var propiedadId = await _mediator.Send(command);
                return Ok(propiedadId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarReglas")]
        public async Task<IActionResult> AgregarReglas([FromBody] AgregarReglasPropiedadCommand command)
        {
            try
            {
                var propiedadId = await _mediator.Send(command);
                return Ok(propiedadId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarComodidades")]
        public async Task<IActionResult> AgregarComodidades([FromBody] AgregarComodidadesPropiedadCommand command)
        {
            try
            {
                var propiedadId = await _mediator.Send(command);
                return Ok(propiedadId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPropiendadXCiudad")]
        public async Task<IActionResult> BuscarPropiendadXCiudad(string ciudadTerm = "")
        {
            var items = await _mediator.Send(new IGetPropiedadQueryList()
            {
                CiudadTerm = ciudadTerm
            });

            return Ok(items);
        }
    }
}
