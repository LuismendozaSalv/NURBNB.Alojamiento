using NURBNB.Alojamiento.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Rules
{
	public class IsvalidCoordinateTest
	{
		[Theory]
		[InlineData(-17.789038893013487, -63.164908393957404, true)]
		[InlineData(-190.789038893013487, -63.164908393957404, false)]
		public void ValoresCoordenadasValidas(double longitud, double latitud, bool resultadoEsperado)
		{
			IsValidCoordinate rule = new IsValidCoordinate(longitud, latitud);
			bool isValid = rule.IsValid();
			Assert.Equal(resultadoEsperado, isValid);
		}
	}
}
