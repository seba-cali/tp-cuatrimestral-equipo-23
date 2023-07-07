using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Registrar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                
                
                
                //setea tipo usuario
                if(inputDNI.Text.Length<=4 || inputPassword.Text.Length<=8)
                {
                    
                
                    Session.Add("error", "DNI incorrecto o password incorrecto");
                    Response.Redirect("Registrar.aspx", false);
                }
                else
                {
                    Usuario usuario = new Usuario();
                    NegocioUsuario usuarioNegocio = new NegocioUsuario();
                    EmailService emailService = new EmailService();
                    //Template email
                    StreamReader str = new StreamReader(Server.MapPath(@"~/assets/template/correo.html"));  
                    string temlate = str.ReadToEnd();  
                    str.Close();  
                    temlate = temlate.Replace("[dni]", inputDNI.Text.Trim());
                    temlate = temlate.Replace("[password]", inputPassword.Text.Trim());
                    //Fin template email
                    usuario.DNI = inputDNI.Text;
                    usuario.CORREO = inputCorreo.Text;
                    usuario.PASSWORD = usuario.encriptar(inputPassword.Text);
                    usuario.telefono = inputTelefono.Text;
                    //asigna id de usuario y lo guarda en session
                    usuario.ID_USUARIO = usuarioNegocio.RegistrarUsuario(usuario);
                
                    Session.Add("usuario", usuario);                

                    emailService.preparaCorreo(usuario.CORREO, "Bienvenido a Dr. Seba", temlate);
                    emailService.enviarEmail();
                
                    Response.Redirect("Default.aspx", false);
                    
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("error manito");
                Session.Add("error", ex.ToString());
            }
        }
       
    }
}