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
		public string DNI { get; set; } 
		public string nombres { get; set; }
		public string apellidos { get; set; }
		public string direccion { get; set; }
		public string telefono { get; set; }
		public string CORREO { get; set; }
		public DateTime fechaNacimiento { get; set; }
		public string sexo { get; set; }
		public bool ESTADO { get; set; }

		public Persona(){}
		public Persona(string dni, string nombres, string apellidos, string direccion, string telefono, string email, DateTime fechaNacimiento, string sexo, bool estado)
		{
			this.DNI = dni;
			this.nombres = nombres;
			this.apellidos = apellidos;
			this.direccion = direccion;
			this.telefono = telefono;
			this.CORREO = email;
			this.fechaNacimiento = fechaNacimiento;
			this.sexo = sexo;
			this.ESTADO = estado;
		}

	}
	
	
	
	
}
