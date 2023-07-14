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
        protected Medico medico { get; set; }
        protected Paciente paciente { get; set; }
        protected string nombre { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                
            }
            else
            {

                usuario = (Usuario)Session["usuario"];
                try
                {
                    if (usuario.ID_TIPOUSUARIO == 1 )
                    {
                        nombre = "Administrador";
                    }

                    if (usuario.ID_TIPOUSUARIO == 2)
                    {
                        nombre = "Secretaria";
                    }

                    if (usuario.ID_TIPOUSUARIO == 3)
                    {
                        NegocioMedico negocioMedico = new NegocioMedico();
                        medico = negocioMedico.listar().Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
                        nombre = medico.nombres;

                    }

                    if (usuario.ID_TIPOUSUARIO == 4)
                    {
                        NegocioPaciente negocioPaciente = new NegocioPaciente();
                        paciente = negocioPaciente.listar().Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
                        //nombre = paciente.nombres;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    
                }
                
                
            }

        }
        

        protected void btn_logout(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}