using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Medico: Persona
    {
        public int ID_MEDICO;
        public string Matricula;
        public int ID_USUARIO;

        public Medico() { }
        public Medico(string dni, string nombres, string apellidos, string direccion, string telefono, string email, DateTime fechaNacimiento, string sexo, bool estado, string matricula) : base(dni, nombres, apellidos, direccion, telefono, email, fechaNacimiento, sexo, estado)
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
            this.Matricula = matricula;


        }
    }
}