using Dominio;
using Negocio;
using ConexionDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace WebApplication2.Admin
{
	public partial class Administrar_Personas : System.Web.UI.Page
	{
		public List<Paciente> listPacientes { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{

			NegocioPaciente negocioPaciente = new NegocioPaciente();
			dgvPacientes.DataSource = negocioPaciente.listarConSp();
			dgvPacientes.DataBind();


		}



		protected void btnEditar_Click(object sender, EventArgs e)
		{

		}

		protected void btnEliminar_Click(object sender, EventArgs e)
		{
			{
				Button btnEliminar = (Button)sender;
				string idPaciente = btnEliminar.CommandArgument;

				NegocioPaciente negocioPaciente = new NegocioPaciente();
				negocioPaciente.eliminarPaciente(int.Parse(idPaciente));
				Response.Redirect("Administrar_Personas.aspx");

			}
		}

		protected void btnReactivar_Click(object sender, EventArgs e)
		{
			Button btnReactivar = (Button)sender;
			string idPaciente = btnReactivar.CommandArgument;

			NegocioPaciente negocioPaciente = new NegocioPaciente();
			negocioPaciente.reactivarPaciente(int.Parse(idPaciente));
			Response.Redirect("Administrar_Personas.aspx");

		}

		protected void btnModificar_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			string commandArgument = btn.CommandArgument;

			//matufia para obtener los valores del command argument
			string[] argumentValues = commandArgument.Split(',');
			string idPaciente = argumentValues[0];
			string idUsuario = argumentValues[1];
			Response.Redirect("alta_Persona.aspx?idPaciente=" + idPaciente +"&idUsuario=" + idUsuario ,false);
		}
	}
}