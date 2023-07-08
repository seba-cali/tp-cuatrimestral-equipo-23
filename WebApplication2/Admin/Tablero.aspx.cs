using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Tablero : Page
    {
        public List<Especialidad> ListaEspecialidades { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }
            NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
            ListaEspecialidades = negocioEspecialidad.listar();

            foreach(Dominio.Especialidad item in ListaEspecialidades)
            {
                //txtEspecialidad.Items.Add(item.nombre.ToString());
            }



        }

        protected void txtEspecialidad_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["ListaEspecialidades"];
            //List<Especialidad> listaFiltrada = lista.FindAll(x => x.nombre == txtEspecialidad.Text);
        }
    }
}