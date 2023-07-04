using Dominio;
using Negocio;
using ConexionDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Admin
{
	public partial class Administrar_Personas : System.Web.UI.Page
	{
		public List<Paciente> listPacientes { get; set; }
		//public List<Medico> listMedicos { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{

			NegocioPaciente negocioPaciente = new NegocioPaciente();
			listPacientes = negocioPaciente.listar();
			//NegocioMedico negocioMedico = new NegocioMedico();
			//listMedicos = negocioMedico.listar();

		}

		protected void btnEditar_Click(object sender, EventArgs e)
		{

		}

		protected void btnBorrar_Click(object sender, EventArgs e)
		{
			Paciente paciente = new Paciente();
			NegocioPaciente negocioPaciente = new NegocioPaciente();
			paciente.id = Convert.ToInt32(this.listPacientes);
			//negocioPaciente.eliminarPaciente(paciente);
			Response.Redirect("Administrar_Personas.aspx");
		}
	}
}