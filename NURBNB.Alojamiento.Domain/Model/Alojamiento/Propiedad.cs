using NURBNB.Alojamiento.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public class Propiedad : AggregateRoot
	{
		public TituloPropiedad Titulo { get; private set; }
		public DescripcionPropiedad Descripcion { get; private set; }
		public Precio Precio { get; private set; }
		public Direccion? Direccion { get; private set; }
		public Capacidad? Capacidad { get; private set; }
		public TipoPropiedad TipoPropiedad { get; private set; }
		private readonly IList<Foto> _fotos;
		public IEnumerable<Foto> Fotos => _fotos;
		private readonly IList<Regla> _reglas;
		public IEnumerable<Regla> Reglas => _reglas;
		private readonly IList<PropiedadComodidad> _comodidades;
		public IEnumerable<PropiedadComodidad> Comodidades => _comodidades;
		private readonly IList<Reserva> _reservas;
		public IEnumerable<Reserva> Reservas => _reservas;
		public Guid UsuarioId { get; private set; }

		internal Propiedad()
		{

		}
		public Propiedad(string titulo, string descripcion, TipoPropiedad tipoPropiedad,
			decimal precio, Capacidad capacidad, Guid usuarioId)
		{
			Id = Guid.NewGuid();
			Titulo = titulo;
			Descripcion = descripcion;
			Precio = precio;
			TipoPropiedad = tipoPropiedad;
			Capacidad = capacidad;
			_fotos = new List<Foto>();
			_reglas = new List<Regla>();
			_comodidades = new List<PropiedadComodidad>();
			_reservas = new List<Reserva>();
			UsuarioId = usuarioId;

		}

		public void AgregarDireccion(string calle, string avenida, string referencia,
			double latitud, double longitud, Ciudad ciudad)
		{
			Direccion = new Direccion(this.Id, calle, avenida, referencia, latitud, longitud, ciudad);
		}

		public void AgregarComodidad(Guid comodidadId)
		{
			if (_comodidades.Any(comodidad => comodidad.ComodidadId == comodidadId))
			{
				throw new ArgumentException("La comodidad ya existe");
			}

			PropiedadComodidad propiedadComodidad = new(comodidadId);
			_comodidades.Add(propiedadComodidad);
		}

		public void AgregarFoto(string url)
		{
			if (_fotos.Any(foto => foto.Url == url))
			{
				throw new ArgumentException("La foto ya existe");
			}
			_fotos.Add(url);
		}

		public void AgregarRegla(string regla)
		{
			if (_reglas.Any(reglaObj => reglaObj.Value == regla))
			{
				throw new ArgumentException("La regla ya existe");
			}
			_reglas.Add(regla);
		}

		public void AgregarReserva(Reserva reserva)
		{
			if (_reservas.Any(reservaObj => reservaObj.Id == reserva.Id))
			{
				throw new ArgumentException("La reserva ya existe");
			}
			_reservas.Add(reserva);
		}
	}
}
