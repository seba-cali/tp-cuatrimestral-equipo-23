using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class Turnos : System.Web.UI.Page
    {
        public List<Especialidad> ListaEspecialidades { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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