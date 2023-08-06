using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Pais.Command.CrearPais;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad
{
    public class CrearCiudadHandler : IRequestHandler<CrearCiudadCommand, Guid>
    {
        private ICiudadRepository _ciudadRepository;
        private ICiudadFactory _ciudadFactory;
        private IUnitOfWork _unitOfWork;

        public CrearCiudadHandler(ICiudadRepository ciudadRepository,
            ICiudadFactory ciudadFactory,
            IUnitOfWork unitOfWork)
        {
            _ciudadFactory = ciudadFactory;
            _ciudadRepository = ciudadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearCiudadCommand request, CancellationToken cancellationToken)
        {
            var ciudadCreada = _ciudadFactory.Crear(request.Nombre, request.PaisId);

            await _ciudadRepository.CreateAsync(ciudadCreada);

            await _unitOfWork.Commit();

            return ciudadCreada.Id;
        }
    }
}
