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
			Session.Add("listMedico", negocioMedico.listar());
			dgvMedicos.DataSource = Session["listMedico"];
			//dgvMedicos.DataSource = negocioMedico.listar();
			dgvMedicos.DataBind();
			dgvMedicos.Columns[0].Visible = false;
			dgvMedicos.Columns[1].Visible = false;
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
			Response.Redirect("alta_Medico.aspx?idMedico=" + idMedico + "&idUsuario=" + idUsuario, false);
		}

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
			List<Medico> listMedicos =(List<Medico>)Session["listMedico"];
			List<Medico> listMedicosFiltrada = listMedicos.FindAll(x => x.nombres.ToLower().Contains(filtro.Text.ToLower()) || x.apellidos.ToLower().Contains(filtro.Text.ToLower()) || x.DNI.ToString().Contains(filtro.Text.ToLower()));
			dgvMedicos.DataSource = listMedicosFiltrada;
			dgvMedicos.DataBind();

        }

        protected void btnEspecialidad_Click(object sender, EventArgs e)
        {
            Button btnEspecialidad = (Button)sender;
            string idMedico = btnEspecialidad.CommandArgument;
            Response.Redirect("Administrar_EspeYTurnoxMed.aspx?idMedico="+idMedico,false);
        }
    }
}