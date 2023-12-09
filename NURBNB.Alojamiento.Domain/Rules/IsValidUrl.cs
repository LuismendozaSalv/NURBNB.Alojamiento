using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Rules
{
	public class IsValidUrl : IBussinessRule
	{
		private readonly string _url;
		public string Message => "La url es inválida";

		public IsValidUrl(string url)
		{
			_url = url;
		}
		public bool IsValid()
		{
			if (Uri.TryCreate(_url, UriKind.Absolute, out Uri uriResult))
			{

				return !string.IsNullOrEmpty(uriResult.Scheme);
			}
			return false;
		}
	}
}
