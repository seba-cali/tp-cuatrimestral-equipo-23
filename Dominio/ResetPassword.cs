using System;
using System.Text;
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
        
        
        public string generateRandom()
        {
            Random random = new Random();
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(8);
            for (int i = 0; i < 8; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}