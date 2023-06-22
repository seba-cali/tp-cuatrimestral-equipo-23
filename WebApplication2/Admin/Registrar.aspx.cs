using System;
using System.IO;
using System.Web.UI;
using Dominio;
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
            Console.WriteLine("entra boton");
            try
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
                usuario.PASSWORD = inputPassword.Text;
                usuario.telefono = inputTelefono.Text;
                usuario.ID_USUARIO = usuarioNegocio.RegistrarUsuario(usuario);
                Session.Add("usuario", usuario);                

                emailService.preparaCorreo(usuario.CORREO, "Bienvenido a Dr. Seba", temlate);
                emailService.enviarEmail();
                
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Console.WriteLine("error manito");
                Session.Add("error", ex.ToString());
            }
        }
    }
}