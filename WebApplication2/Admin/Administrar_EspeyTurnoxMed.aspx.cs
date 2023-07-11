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
    public partial class Administrar_EspeyTurnoxMed : System.Web.UI.Page
    {
       

		public List<EspecialidadxMedico> listMedico { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
            dgvEspecialidadxTurno.DataSource = negocioEspecialidadxMedico.listarconsulta();
            dgvEspecialidadxTurno.DataBind();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                Button btnEliminar = (Button)sender;
                string commandArgument = btnEliminar.CommandArgument;
                string[] argumentValues = commandArgument.Split(',');
                string idMedico = argumentValues[0];
                string idEsp = argumentValues[1];
                string TurnoHorario = argumentValues[2];

                NegocioEspecialidadxMedico negocioEspecialidadxMed = new NegocioEspecialidadxMedico();
                negocioEspecialidadxMed.eliminarfisico(int.Parse(idMedico),int.Parse(idEsp),int.Parse(TurnoHorario));
                Response.Redirect("Administrar_EspeyTurnoxMed");

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
            string TurnoHorario= argumentValues[2];
            Response.Redirect("alta_Persona.aspx?idMedico=" + idMedico + "&idUsuario=" + idUsuario, false);
        }
    }
}
