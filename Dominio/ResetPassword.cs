using System;
using System.Threading;

namespace Dominio
{
    public class ResetPassword
    {
        public int id_ResetPassword { get; set; }
        public string codigo { get; set; }
        public int id_Usuario { get; set; }
        public bool estado { get; set; }
        public DateTime fecha { get; set; }
        
        public ResetPassword() { }
        
    }
}