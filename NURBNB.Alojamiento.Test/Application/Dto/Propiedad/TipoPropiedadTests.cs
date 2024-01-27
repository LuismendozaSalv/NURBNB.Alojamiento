using NURBNB.Alojamiento.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto.Propiedad
{
	public class TipoPropiedadTests
	{
		[Fact]
		public void Enum_Contains_Correct_Values()
		{
			// Arrange
			var expectedValues = new[] { 0, 1, 2 };

			// Act
			var actualValues = (int[])Enum.GetValues(typeof(TipoPropiedad));

			// Assert
			Microsoft.VisualBasic.Collection.Equals(expectedValues, actualValues);
		}
	}
}
