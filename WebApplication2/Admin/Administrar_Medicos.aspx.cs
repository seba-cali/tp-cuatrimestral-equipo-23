using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Admin
{
	public partial class Administrar_Medicos : System.Web.UI.Page
	{

		public List<Medico> listMedico { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{

			NegocioMedico negocioMedico = new NegocioMedico();
			dgvMedicos.DataSource = negocioMedico.listar();
			dgvMedicos.DataBind();
		}
		protected void btnEliminar_Click(object sender, EventArgs e)
		{
			{
				Button btnEliminar = (Button)sender;
				string idMedico = btnEliminar.CommandArgument;

				NegocioMedico negocioMedico = new NegocioMedico();
				negocioMedico.eliminarMedico(int.Parse(idMedico));
				Response.Redirect("Administrar_Medicos.aspx");

			}
		}

		protected void btnReactivar_Click(object sender, EventArgs e)
		{
			Button btnReactivar = (Button)sender;
			string idMedico = btnReactivar.CommandArgument;

			NegocioMedico negocioMedico = new NegocioMedico();
			negocioMedico.reactivarMedico(int.Parse(idMedico));
			Response.Redirect("Administrar_Medicos.aspx");

		}

		protected void btnModificar_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			string commandArgument = btn.CommandArgument;

			//matufia para obtener los valores del command argument
			string[] argumentValues = commandArgument.Split(',');
			string idMedico = argumentValues[0];
			string idUsuario = argumentValues[1];
			Response.Redirect("alta_Persona.aspx?idMedico=" + idMedico + "&idUsuario=" + idUsuario, false);
		}
	}
}