using System;
using System.Security.Cryptography;
using System.Text;

namespace Dominio
{
    public class Usuario : Persona
    {
        public int ID_USUARIO;
        public string name;

        public string PASSWORD;

        public int ID_TIPOUSUARIO;
        
        public Usuario(){}
        public Usuario(string dni, string nombres, string apellidos, string direccion, string telefono, string email, DateTime fechaNacimiento, string sexo, bool estado) : base(dni, nombres, apellidos, direccion, telefono, email, fechaNacimiento, sexo, estado)
        {
        }
        
        
        public static string MD5Hash(string text)  
        {  
            MD5 md5 = new MD5CryptoServiceProvider();  

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));  
  
            //get hash result after compute it  
            byte[] result = md5.Hash;  

            StringBuilder strBuilder = new StringBuilder();  
            for (int i = 0; i < result.Length; i++)  
            {  
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));  
            }  

            return strBuilder.ToString();  
        }

        
    }
}