using MassTransit;
using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.ModificarReservaPropiedad;
using NURBNB.IntegrationEvents;

namespace NURBNB.Alojamiento.Infrastructure.MassTransit.Consumers
{
	public class CheckOutFinalizadoConsumer : IConsumer<CheckOutFinalizado>
	{
		private readonly IMediator _mediator;

		public CheckOutFinalizadoConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<CheckOutFinalizado> context)
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