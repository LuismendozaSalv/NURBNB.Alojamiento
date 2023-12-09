using NURBNB.Alojamiento.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Rules
{
	public class IsValidUrlTests
	{
		[Fact]
		public void IsValid_ValidUrl_ReturnsTrue()
		{
			// Arrange
			string validUrl = "https://www.example.com";
			var validator = new IsValidUrl(validUrl);

			// Act
			bool result = validator.IsValid();

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void IsValid_InvalidUrl_ReturnsFalse()
		{
			// Arrange
			string invalidUrl = "not_a_valid_url";
			var validator = new IsValidUrl(invalidUrl);

			// Act
			bool result = validator.IsValid();

			// Assert
			Assert.False(result);
		}
	}
}
