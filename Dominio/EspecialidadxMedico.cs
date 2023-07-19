using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EspecialidadxMedico
    {


        public int ID_ESPECIALIDADXMEDICO { get; set; }
        public int ID_MEDICO { get; set; }

        public string Name { get; set; }

        public string Especialidad { get; set; }

        public int Id_Especialidad { get; set; }

        public int Turno_Horario { get; set; }

        public bool Atiende_Lunes { get; set; }
        public bool Atiende_Martes { get; set; }
        public bool Atiende_Miercoles { get; set; }
        public bool Atiende_Jueves { get; set; }
        public bool Atiende_Viernes { get; set; }
        public bool Atiende_Sabado { get; set; }
        public bool Atiende_Domingo { get; set; }

        
        public EspecialidadxMedico() { }
    }
}
