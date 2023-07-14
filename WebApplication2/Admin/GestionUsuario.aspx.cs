using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;

namespace WebApplication2.Admin
{
    public partial class GestionUsuario : Page
    {
        public Usuario usuario { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }

            usuario = (Usuario)Session["usuario"];
            
            if (usuario.ID_TIPOUSUARIO== 1)
            {
             
            }
        }

    }
}