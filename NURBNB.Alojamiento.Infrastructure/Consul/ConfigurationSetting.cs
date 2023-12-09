using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.Consul
{
	public class ConfigurationSetting
	{
		public string ServiceName { get; set; }
		public string ServiceHost { get; set; }
		public int ServicePort { get; set; }
		public string ConsulAddresss { get; set; }
	}
}
