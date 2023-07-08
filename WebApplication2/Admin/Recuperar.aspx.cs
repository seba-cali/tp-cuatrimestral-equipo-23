using System;
using System.IO;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Recuperar : Page
    {
        public string code="";
        public int pivot=0;
        public int idcode=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }
            //toma codigo por url dwl sitio
            code = Request.QueryString["code"] != null ? Request.QueryString["code"].ToString() : "";
            
            Session["error"] = null;
            Session["OK"] = null;
            Session["w"] = null;
            
            if (code != "")
            {
                idcode = 0;
                inputCode.Text = code;
                pivot = 1;
            }


        }
        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            //valida que el codigo sea correcto
            //si es correcto redirige a reset password
            //
            try
            {
                NegocioResetPassword verifica = new NegocioResetPassword();

                if (verifica.BuscarXCorreo(inputEmailAddress.Text) != null && inputEmailAddress.Text != "")
                {
                    Usuario usuario = new Usuario();
                    
                    
                    usuario = verifica.BuscarXCorreo(inputEmailAddress.Text);
                    
                    usuario.CORREO = inputEmailAddress.Text;
                    Dominio.ResetPassword resetPassword = new Dominio.ResetPassword();
                    
                    resetPassword.id_Usuario = usuario.ID_USUARIO;
                    resetPassword.codigo = resetPassword.generateRandom();
                    resetPassword.fecha = DateTime.Now;
                    resetPassword.estado = true;
                    if(verifica.generateCode(resetPassword)>0){
                        EmailService emailService = new EmailService();
                        StreamReader str = new StreamReader(Server.MapPath(@"~/assets/template/recuperar.html"));
                        string temlate = str.ReadToEnd();
                        str.Close();
                        temlate = temlate.Replace("[codigo]", resetPassword.codigo);
                        temlate = temlate.Replace("[code]", resetPassword.codigo);
                        emailService.preparaCorreo(usuario.CORREO, "Recuperar cuenta de Dr. Seba", temlate);
                        emailService.enviarEmail();
                        pivot = 1;
                        idcode = 0;
                        Session.Add("OK", "Revise su correo");
                        
                    }
                    else
                    {
                        pivot = 0;
                        Session.Add("error", "Error al generar codigo");
                        Response.Redirect("Recuperar.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        protected void btnFindPaswword(object sender, EventArgs e)
        {
            NegocioResetPassword verifica = new NegocioResetPassword();
            int aux = verifica.BuscarXCode(inputCode.Text);
            
            if (aux > 0)
            {
                Session.Add("w",aux.ToString());    
                pivot = 2;
            }else if (aux==-1)
            {
                Session.Add("error", "Codigo ya fue utilizado  genere uno nuvo");
                pivot = 0;
            }
            else
            {
                Session.Add("error", "Codigo incorrecto o invalido");
                pivot = 1;
                
            }
        }
        protected void btnUpdatePaswword(object sender, EventArgs e)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            Usuario usuario = new Usuario();
            string pass = usuario.encriptar(inputPassword.Text);
            negocioUsuario.BuscarXIdUpdate(Convert.ToInt32(Session["w"].ToString()), pass);
            Session.Add("OK", "Contraseña actualizada");
            Response.Redirect("Default.aspx", false);
           
        }
    }
}