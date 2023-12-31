﻿using System;

namespace Dominio
{
    public class Paciente : Persona
    {
        public int ID_PACIENTE {get; set; }
        public int ID_USUARIO {get; set; }
        public string nombreCompleto => nombres + " " + apellidos;

        public Paciente() { }
        public Paciente(string dni, string nombres, string apellidos, string direccion, string telefono, string email, DateTime fechaNacimiento, string sexo, bool estado) : base(dni, nombres, apellidos, direccion, telefono, email, fechaNacimiento, sexo, estado)
        {
        }

        
    }
}