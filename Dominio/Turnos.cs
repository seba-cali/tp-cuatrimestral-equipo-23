using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Turnos
    {
        public int Id_Turno { get; set; }
        public DateTime fecha { get; set; }
        public bool Estado { get; set; }
        public int Id_Medico { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Hora { get; set; }
        public int Id_Especialidad { get; set; }
        public string observacion { get; set; }
        public Turnos(){}
        
        public static Dictionary<int,string> xt {get;set;}
        
        public static Dictionary<int, string> GetTurnos(int xturno =0)
        {
            xt = new Dictionary<int, string>();
            
            if (xturno ==0)
            {
                xt.Add(1, " 6:00 a 7:00 Hs");
                xt.Add(2, " 7:00 a 8:00 Hs");
                xt.Add(3, " 9:00 a 10:00 Hs");
                xt.Add(4, " 11:00 a 12:00 Hs");
                xt.Add(5, " 12:00 a 13:00 Hs");
                
            }
            if (xturno ==1)
            {
                
                xt.Add(6, " 13:00 a 14:00 Hs");
                xt.Add(7, " 14:00 a 15:00 Hs");
                xt.Add(8, " 15:00 a 16:00 Hs");
                xt.Add(9, " 16:00 a 17:00 Hs");
                xt.Add(10, " 17:00 a 18:00 Hs");
                
            }
            if (xturno == 2)
            {
                xt.Add(11, " 18:00 a 19:00 Hs");
                xt.Add(12, " 19:00 a 20:00 Hs");
                xt.Add(13, " 20:00 a 21:00 Hs");
                xt.Add(14, " 21:00 a 22:00 Hs");
                xt.Add(15, " 22:00 a 23:00 Hs");
                
            }

            return xt;
            
        }
        public static Dictionary<int, string> GetRepro()
        {
            xt = new Dictionary<int, string>();
            
                xt.Add(1, " 6:00 a 7:00 Hs");
                xt.Add(2, " 7:00 a 8:00 Hs");
                xt.Add(3, " 9:00 a 10:00 Hs");
                xt.Add(4, " 11:00 a 12:00 Hs");
                xt.Add(5, " 12:00 a 13:00 Hs");
                xt.Add(6, " 13:00 a 14:00 Hs");
                xt.Add(7, " 14:00 a 15:00 Hs");
                xt.Add(8, " 15:00 a 16:00 Hs");
                xt.Add(9, " 16:00 a 17:00 Hs");
                xt.Add(10, " 17:00 a 18:00 Hs");
                xt.Add(11, " 18:00 a 19:00 Hs");
                xt.Add(12, " 19:00 a 20:00 Hs");
                xt.Add(13, " 20:00 a 21:00 Hs");
                xt.Add(14, " 21:00 a 22:00 Hs");
                xt.Add(15, " 22:00 a 23:00 Hs");
                
            

            return xt;
            
        }
    }
    
    
}