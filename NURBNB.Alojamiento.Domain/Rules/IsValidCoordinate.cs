using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Rules
{
	public class IsValidCoordinate : IBussinessRule
	{
		private readonly double _latitude;
		private readonly double _longitude;

		public string Message => "La coordenada no es válida";

		public IsValidCoordinate(double latitude, double longitude)
		{
			_latitude = latitude;
			_longitude = longitude;
		}
		public bool IsValid()
		{
			if (_latitude >= -90 && _latitude <= 90)
			{
				if (_longitude >= -180 && _longitude <= 180)
				{
					return true;
				}
			}
			return false;
		}
	}
}
