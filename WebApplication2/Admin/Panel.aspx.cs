using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    
    public partial class Panel : MasterPage
    {
        protected Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
                usuario = (Usuario)Session["usuario"];
                
            
            
        }
        private bool VerificaUsuario(int o)
        {
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            List<Paciente>ListaPacientes = new List<Paciente>();
            ListaPacientes = negocioPaciente.listar();
            Paciente paciente = ListaPacientes.Find(x => x.ID_USUARIO == o);
            return paciente==null?false:true;
        }

        protected void btn_logout(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}