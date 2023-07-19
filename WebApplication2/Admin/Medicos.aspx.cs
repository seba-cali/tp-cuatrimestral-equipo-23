using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Medicos : Page
    {
        protected Usuario usuario { get; set; }
        public List<Especialidad> ListaEspecialidades { get; set; }
        public List<Turnos> ListaTurnos { get; set; }
        public List<Paciente> ListaPacientes { get; set; }
        public List<Medico>ListMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"]==null)
            {
                Session["error"] = "Debe iniciar sesion";
                Response.Redirect("Default.aspx", false);
            }
            if (!IsPostBack)
            {
                    
                Session["OK"] = null;
                Session["class"] = null;
                Session["error"] = null;
            }
            if(formGroupId.Text!=""&& formGroupId!=null)
                Session["idMed"] = formGroupId.Text;
            usuario = (Usuario)Session["usuario"];
            
            NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
            ListaEspecialidades = negocioEspecialidad.listar();
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            ListaPacientes = negocioPaciente.listar();
            
            NegocioMedico negocioMedico = new NegocioMedico();
            ListMedicos = negocioMedico.listar();
            Medico medico = ListMedicos.Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
            NegocioTurno negocio = new NegocioTurno();
            ListaTurnos = negocio.listar();
            ListaTurnos = ListaTurnos.FindAll(x => x.Id_Medico == medico.ID_MEDICO).OrderByDescending(x => x.fecha).ToList();

        }

		protected void Button2_OnClick(object sender, EventArgs e)
		{
			if (int.TryParse(formGroupId.Text, out int turnoId))
			{
				try
				{
					Turnos turno = new Turnos();
					NegocioTurno negocio = new NegocioTurno();
					turno.Id_Turno= Convert.ToInt32(formGroupId.Text);
					turno.EstadoInf = Convert.ToInt32(inputEstado.SelectedValue);
					turno.observacionMed = inputObs.Text;

					negocio.UpdateTurnoMed(turno);
					Session["OK"] = "Se actualizó el estado del paciente";
               Response.Redirect("Medicos.aspx", false);
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception);
					Session["error"] = "No se pudo actualizar el estado del paciente";
					Response.Redirect("Medicos.aspx", false);
				}
			}
			else
			{
				Session["error"] = "El valor del Id del turno no es válido";
				Response.Redirect("Medicos.aspx", false);
			}
		}
	}
}