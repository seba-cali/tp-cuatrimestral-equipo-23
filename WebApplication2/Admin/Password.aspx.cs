using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Password : Page
    {
        public Usuario Usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Usuario = (Usuario)Session["usuario"];
            }

        }

        protected void guardaPassword_OnClick(object sender, EventArgs e)
        {
            try
            {
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                
                
                if(inputNuevoPassword.Text==inputConfirmaPassword.Text)
                {
                    string passant = Usuario.encriptar(inputPassword.Text);
                    string pass = Usuario.encriptar(inputNuevoPassword.Text);
                    
                    negocioUsuario.BuscarXIdUpdatePass(Usuario.ID_USUARIO,passant, pass);
                    
                    Session.Add("OK", "Contraseña actualizada");
                    Response.Redirect("Default.aspx", false);;
                }
                else
                {
                    Session.Add("errorreg", "password no valido");
                    Response.Redirect("Password.aspx", false);
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}