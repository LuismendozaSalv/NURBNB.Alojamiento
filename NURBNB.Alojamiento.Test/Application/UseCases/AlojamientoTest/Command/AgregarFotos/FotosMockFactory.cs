using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.AgregarFotos
{
	internal class FotosMockFactory
	{
		public static Propiedad AddFotos(Propiedad propiedad, List<FotoDto> fotos)
		{
			foreach (FotoDto foto in fotos)
			{
				propiedad.AgregarFoto(foto.Url);
			}
			return propiedad;
		}
	}
}
