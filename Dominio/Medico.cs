using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


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
                turnos.Add(1, " 6:00 AM a 6:30 AM");
                turnos.Add(2, " 6:30 AM a 7:00 AM");
                turnos.Add(3, " 7:00 AM a 7:30 AM");
                turnos.Add(4, " 7:30 AM a 8:00 AM");
                turnos.Add(5, " 8:00 AM a 8:30 AM");
                turnos.Add(6, " 8:30 AM a 9:00 AM");
                turnos.Add(7, " 9:00 AM a 9:30 AM");
                turnos.Add(8, " 9:30 AM a 10:00 AM");
                turnos.Add(9, " 10:00 AM a 10:30 AM");
                turnos.Add(10, " 10:30 AM a 11:00 AM");
            }
            if (xturno ==1)
            {
                
                turnos.Add(11, " 11:00 AM a 11:30 AM");
                turnos.Add(12, " 11:30 AM a 12:00 PM");
                turnos.Add(13, " 12:00 PM a 12:30 PM");
                turnos.Add(14, " 12:30 PM a 13:00 PM");
                turnos.Add(15, " 13:00 PM a 13:30 PM");
                turnos.Add(16, " 13:30 PM a 14:00 PM");
                turnos.Add(17, " 14:00 PM a 14:30 PM");
                turnos.Add(18, " 14:30 PM a 15:00 PM");
                turnos.Add(19, " 15:00 PM a 15:30 PM");
                turnos.Add(20, " 15:30 PM a 16:00 PM");
            }
            if (xturno == 2)
            {
                turnos.Add(21, " 16:00 PM a 16:30 PM");
                turnos.Add(22, " 16:30 PM a 17:00 PM");
                turnos.Add(23, " 17:00 PM a 17:30 PM");
                turnos.Add(24, " 17:30 PM a 18:00 PM");
                turnos.Add(25, " 18:00 PM a 18:30 PM");
                turnos.Add(26, " 18:30 PM a 19:00 PM");
                turnos.Add(27, " 19:00 PM a 19:30 PM");
                turnos.Add(28, " 19:30 PM a 20:00 PM");
                turnos.Add(29, " 20:00 PM a 20:30 PM");
                turnos.Add(30, " 20:30 PM a 21:00 PM");
            }
            

            return turnos;
        }
    }
}