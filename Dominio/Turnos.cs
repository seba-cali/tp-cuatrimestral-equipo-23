using System;

namespace Dominio
{
    public class Turnos
    {
        public int Id_Turno { get; set; }
        public DateTime fecha { get; set; }
        public bool Id_Estado { get; set; }
        public int Id_Especialidad { get; set; }
        public int Id_Medico { get; set; }
        public int Id_Paciente { get; set; }
        
    }
}