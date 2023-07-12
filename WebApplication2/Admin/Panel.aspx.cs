using System;
using System.Web.UI;
using Dominio;

namespace WebApplication2.Admin
{
    
    public partial class Panel : MasterPage
    {
        protected Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            usuario= (Usuario)Session["usuario"];

        }

        protected void btn_logout(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}