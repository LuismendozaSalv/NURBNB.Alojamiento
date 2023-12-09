using MassTransit;
using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.ModificarReservaPropiedad;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.MassTransit.Consumers
{
	public class ReservaFinalizadaConsumer : IConsumer<ReservaFinalizada>
	{
		private readonly IMediator _mediator;

		public ReservaFinalizadaConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<ReservaFinalizada> context)
		{
			var message = context.Message;
			var command = new ModificarReservaPropiedadCommand
			{
				ReservaId = message.ReservaId,
				Estado = Domain.Model.Alojamiento.EstadoReserva.Finalizada
			};
			await _mediator.Send(command);
		}
	}
}
