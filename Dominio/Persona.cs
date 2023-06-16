using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Persona
	{
		public int id { get; set; }
		public string dni { get; set; } 
		public string nombres { get; set; }
		public string apellidos { get; set; }
		public string direccion { get; set; }
		public string telefono { get; set; }
		public string email { get; set; }
		public DateTime fechaNacimiento { get; set; }
		public string sexo { get; set; }
		public bool estado { get; set; }
	}
}
