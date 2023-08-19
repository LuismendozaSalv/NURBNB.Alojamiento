using Moq;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad
{
    public class CrearCiudad_Test
    {
        Mock<ICiudadRepository> _ciudadRepository;
        Mock<IPaisRepository> _paisRepository;
        Mock<ICiudadFactory> _ciudadFactory;
        Mock<IUnitOfWork> _unitOfWork;

        public CrearCiudad_Test()
        {
            _ciudadFactory = new Mock<ICiudadFactory>();
            _ciudadRepository = new Mock<ICiudadRepository>();
            _paisRepository = new Mock<IPaisRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void CrearCiudad()
        {
            var ciudad = CiudadMockFactory.getCiudad();

            _paisRepository.Setup(_paisRepository => _paisRepository.FindByIdAsync(ciudad.Country.Id))
                .ReturnsAsync(ciudad.Country);
            _ciudadFactory.Setup(_ciudadFactory => _ciudadFactory.Crear(ciudad.Name, ciudad.Country.Id))
                .ReturnsAsync(ciudad);
            var handler = new CrearCiudadHandler(
                _ciudadRepository.Object,
                _ciudadFactory.Object,
                _unitOfWork.Object
            );
            var tcs = new CancellationTokenSource(1000);

            CrearCiudadCommand evento = new CrearCiudadCommand
            {
                Nombre = ciudad.Name,
                PaisId = ciudad.Country.Id,
            };

            var idCiudad = handler.Handle(evento, tcs.Token);

            Assert.Equal(ciudad.Id, idCiudad.Result);
        }
    }
}
