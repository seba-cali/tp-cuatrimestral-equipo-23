using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        protected void btn_Login(object sender, EventArgs e)
        {
            
            Usuario usuuario= new Usuario();
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            
            try
            {
                usuuario.DNI= DNIUSER.Text;
                usuuario.PASSWORD = PASSWORDUSER.Text;
                if (negocioUsuario.login(usuuario) != null)
                {
                    Session.Remove("error");
                    Session.Add("usuario", usuuario);
                    Response.Redirect("Prueba.aspx", false);
                }
                else
                {
                    
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Default.aspx", false);
                }
                
                

            }
            catch (Exception exception)
            {
                Session.Add("error", "no ingreso datos solicitados");
                Response.Redirect("Default.aspx", true);
            }

        }
    }
}