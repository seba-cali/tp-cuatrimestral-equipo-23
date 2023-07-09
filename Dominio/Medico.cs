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
        public int ID_ESPECIALIDAD  { get; set; }
        public int ID_USUARIO { get; set; }
        public int turno { get; set; }
        

        public Medico() { }
        public Medico(string dni, string nombres, string apellidos, string direccion, string telefono, string email, 
            DateTime fechaNacimiento, string sexo, bool estado, string matricula, int idEspecialidad,int idUsuario, int turno) : base(dni, nombres, apellidos, direccion, telefono, email, fechaNacimiento, sexo, estado)
        {

        }
        public static Dictionary<int, string> getTurnos(int xturno)
        {
            Dictionary<int, string> turnos = new Dictionary<int, string>();
            
            if (xturno ==0)
            {
                turnos.Add(1, " 6:00 a 7:00 Hs");
                turnos.Add(2, " 7:00 a 8:00 Hs");
                turnos.Add(3, " 9:00 a 10:00 Hs");
                turnos.Add(4, " 11:00 a 12:00 Hs");
                turnos.Add(5, " 12:00 a 13:00 Hs");
                
            }
            if (xturno ==1)
            {
                
                turnos.Add(6, " 13:00 a 14:00 Hs");
                turnos.Add(7, " 14:00 a 15:00 Hs");
                turnos.Add(8, " 15:00 a 16:00 Hs");
                turnos.Add(9, " 16:00 a 17:00 Hs");
                turnos.Add(10, " 17:00 a 18:00 Hs");
             
            }
            if (xturno == 2)
            {
                turnos.Add(11, " 18:00 a 19:00 Hs");
                turnos.Add(12, " 19:00 a 20:00 Hs");
                turnos.Add(13, " 20:00 a 21:00 Hs");
                turnos.Add(14, " 21:00 a 22:00 Hs");
                turnos.Add(15, " 22:00 a 23:00 Hs");
            }

        
            return turnos;
        }
    }
}