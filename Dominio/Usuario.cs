using System.Security.Cryptography;
using System.Text;

namespace Dominio
{
    public class Usuario : Persona
    {
        public int ID_USUARIO { get; set; }
        public string DNI{ get; set; }
        public string PASSWORD { get ; set; }
        public string CORREO{ get; set; }
        public bool ESTADO{ get; set; }
        public int ID_TIPOUSUARIO{ get; set; }

        public Usuario(){}
        public Usuario(string dni, string password, string correo, bool estado, int idTipousuario)
        {
            DNI = dni;
            PASSWORD = password;
            CORREO = correo;
            ESTADO = estado;
            ID_TIPOUSUARIO = idTipousuario;
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