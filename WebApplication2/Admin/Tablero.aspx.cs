using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Tablero : Page
    {
        protected Usuario usuario { get; set; }
        public List<Especialidad> ListaEspecialidades { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            * 0 = Nuevo
            * 1= Confirmado
            * 2= Cancelado
            * 3= No Asisitio
            * 4= Reprogramado
            * 5= Cerrado
            * 
            */
            if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }
            usuario = (Usuario)Session["usuario"];
            NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
            ListaEspecialidades = negocioEspecialidad.listar();
            
            NegocioTurno negocioTurno = new NegocioTurno();
            List<Turnos> listaTurnos = negocioTurno.listar();
            

            


        }

        protected void txtEspecialidad_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["ListaEspecialidades"];
            //List<Especialidad> listaFiltrada = lista.FindAll(x => x.nombre == txtEspecialidad.Text);
        }
    }
}