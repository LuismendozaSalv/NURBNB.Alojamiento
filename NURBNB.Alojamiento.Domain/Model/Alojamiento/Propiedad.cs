﻿using NURBNB.Alojamiento.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    public class Propiedad : AggregateRoot
    {
        public TituloPropiedad Titulo { get; private set; }
        public DescripcionPropiedad Descripcion { get; private set; }
        public Precio Precio { get; private set; }
        public Direccion Direccion { get; private set; }
        public Capacidad Capacidad { get; private set; }
        public TipoPropiedad TipoPropiedad { get; private set; }
        private readonly IList<Foto> _fotos;
        public IEnumerable<Foto> Fotos => _fotos;
        private readonly IList<Regla> _reglas;
        public IEnumerable<Regla> Reglas => _reglas;
        //private readonly IList<Comodidad>? _comodidades;
        //public IEnumerable<Comodidad>? Comodidades => _comodidades;

        internal Propiedad()
        {
            
        }
        internal Propiedad(string titulo, string descripcion, TipoPropiedad tipoPropiedad, 
            decimal precio, Capacidad capacidad)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descripcion = descripcion;
            Precio = precio;
            TipoPropiedad = tipoPropiedad;
            Capacidad = capacidad;
            _fotos = new List<Foto>();
            _reglas = new List<Regla>();
            //_comodidades = new List<Comodidad>();
        }

        public void AgregarDireccion(string calle, string avenida, string referencia, 
            double latitud, double longitud, Ciudad ciudad)
        {
            Direccion = new Direccion(this.Id, calle, avenida, referencia, latitud, longitud, ciudad);
        }
        
        //public void AgregarComodidad(string value)
        //{
        //    if (_comodidades.Any(comodidad => comodidad.Value == value))
        //    {
        //        throw new ArgumentException("La comodidad ya existe");
        //    }
        //    _comodidades.Add(value);
        //}

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
    }
}
