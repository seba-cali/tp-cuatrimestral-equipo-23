using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Dominio
{
    public class Medico: Persona
    {
        public int ID_MEDICO { get; set; }
        public string Matricula { get; set; }
        public int ID_USUARIO { get; set; }


        public Medico() { }
        public Medico(string dni, string nombres, string apellidos, string direccion, string telefono, string email, 
            DateTime fechaNacimiento, string sexo, bool estado, string matricula, int idUsuario, int turno) : base(dni, nombres, apellidos, direccion, telefono, email, fechaNacimiento, sexo, estado)
        {

        }
        
    }
}