using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class FotoTests
	{
		[Fact]
		public void Constructor_URLValida_CreaNuevaUrl()
		{
			// Arrange
			string url = "https://example.com/image.jpg";

			// Act
			var foto = new Foto(url);

			// Assert
			Assert.Equal(url, foto.Url);
		}

		[Theory]
		[InlineData("invalid-url")]
		[InlineData("")]
		[InlineData(null)]
		public void Constructor_UrlInvalida_RetornaThrowException(string invalidUrl)
		{
			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Foto(invalidUrl));
		}

		[Fact]
		public void Constructor_GeneraIdUnico()
		{
			// Act
			var foto1 = new Foto("https://example.com/image1.jpg");
			var foto2 = new Foto("https://example.com/image2.jpg");

			// Assert
			Assert.NotEqual(foto1.Id, foto2.Id);
		}

		[Fact]
		public void ConversionImplicita_AString_DeberiaRetornarValorCorrecto()
		{
			// Arrange
			string url = "https://example.com/image.jpg";
			var foto = new Foto(url);

			// Act
			string result = foto;

			// Assert
			Assert.Equal(url, result);
		}

		[Fact]
		public void ConversionImplicita_DesdeString_DeberiaCrearInstanciaConUrlCorrecta()
		{
			// Arrange
			string url = "https://example.com/image.jpg";

			// Act
			Foto foto = url;

			// Assert
			Assert.Equal(url, foto.Url);
		}
	}
}
