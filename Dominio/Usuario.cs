using System;
using System.Security.Cryptography;
using System.Text;

namespace Dominio
{
    public class Usuario : Persona
    {
        public int ID_USUARIO { get; set; }

        public string PASSWORD {get; set;}

        public int ID_TIPOUSUARIO { get; set; }
        
        public Usuario(){}
        public Usuario(string password, int id_tipousuario,string dni, string nombres, string apellidos, string direccion, string telefono, string email, DateTime fechaNacimiento, string sexo, bool estado) 
            : base(dni, nombres, apellidos, direccion, telefono, email, fechaNacimiento, sexo, estado)
        {
           
            /*this.PASSWORD = encriptar(password);
            this.ID_TIPOUSUARIO = id_tipousuario;
            this.DNI = dni;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefono = telefono;
            this.CORREO = email;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            this.ESTADO = estado;*/
           

        }
        public string encriptar(String password)  
        {  
            
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();  
            byte[] encrypt;  
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));  
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)  
            {  
                encryptdata.Append(encrypt[i].ToString());  
            }
            
            return encryptdata.ToString();  
        }
        
       
        
        
    }
}