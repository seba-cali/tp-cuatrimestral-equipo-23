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
        public EspecialidadxMedico() { }
    }
}
