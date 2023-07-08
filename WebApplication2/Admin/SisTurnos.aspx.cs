using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    
    public partial class SisTurnos : Page
    {
        public int id_medico {get;set;}
        public int id_especialidad {get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }*/
            Session["error"] = null;
            Session["OK"] = null;
            Session["w"] = null;
            
            NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
            List<Especialidad> ListaEspecialidades=new List<Especialidad>();
            ListaEspecialidades= negocioEspecialidad.listar();
			NegocioMedico negocioMedico = new NegocioMedico();
            List<Medico> ListaMedicos = new List<Medico>();
            ListaMedicos = negocioMedico.listar();
					
            
            ListBox checkBox = new ListBox();
            checkBox.SelectedIndexChanged += new EventHandler(SelectEspecialidad);
            checkBox.ID = "nery";
            checkBox.CssClass = "form-control";				
            foreach (Especialidad pivot in ListaEspecialidades)
            {
                checkBox.Items.Add(new ListItem(pivot.nombre, pivot.id.ToString()));
						
                Muestra1.Controls.Add(checkBox);
            }
        }

        protected void SelectHorario(object sender, EventArgs e)
        {
            int id_turno = Convert.ToInt32(((ListItem)sender).Value);
            bool [] loco  = new bool[10];
            //arriba
            bool pivote = false;
            if(loco[id_turno+1]==true)
            {
                pivote = true;
            }
            else
            {
                pivote = false;
            }
        }
        protected void SelectEspecialidad(object sender, EventArgs e)
        {
            
        }
    }
}