using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto
{
	public class PaisCiudadesDtoTests
	{
		[Fact]
		public void PaisCiudadesDto_Validar_Inicializacion()
		{
			// Arrange
			bool error = false;
			string msg = "OK";
			var cities = new List<string> { "Ciudad1", "Ciudad2", "Ciudad3" };

			// Act
			var data = new Data
			{
				iso2 = "US",
				iso3 = "USA",
				country = "United States",
				cities = cities
			};

			var paisCiudadesDto = new PaisCiudadesDto
			{
				error = error,
				msg = msg,
				data = new List<Data> { data }
			};

			// Assert
			Assert.Equal(error, paisCiudadesDto.error);
			Assert.Equal(msg, paisCiudadesDto.msg);
			Assert.NotNull(paisCiudadesDto.data);
			Assert.Single(paisCiudadesDto.data); // Verifica que haya solo un elemento en la lista de data

			var dataElement = paisCiudadesDto.data[0]; // Obtiene el primer elemento de la lista de data
			Assert.Equal("US", dataElement.iso2);
			Assert.Equal("USA", dataElement.iso3);
			Assert.Equal("United States", dataElement.country);
			Assert.Equal(cities, dataElement.cities);
		}
	}
}
