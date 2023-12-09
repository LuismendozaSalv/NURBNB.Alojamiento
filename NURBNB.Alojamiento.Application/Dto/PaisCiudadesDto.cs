using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.Dto
{
	public class PaisCiudadesDto
	{
		public bool error { get; set; }
		public string msg { get; set; }
		public List<Data> data { get; set; }
	}

	public class Data
	{
		public string iso2 { get; set; }
		public string iso3 { get; set; }
		public string country { get; set; }
		public List<string> cities { get; set; }
	}
}
