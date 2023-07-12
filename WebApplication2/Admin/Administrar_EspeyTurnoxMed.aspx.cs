using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            if (!IsPostBack)
            {


                NegocioMedico negocioMedico = new NegocioMedico();

                inputMedico.DataSource = negocioMedico.listar();
                inputMedico.DataTextField = "NombreCompleto";
                inputMedico.DataValueField = "ID_MEDICO";
                inputMedico.DataBind();

                NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
                inputEspecialidad.DataSource = negocioEspecialidad.listar();
                inputEspecialidad.DataTextField = "nombre";
                inputEspecialidad.DataValueField = "id";
                inputEspecialidad.DataBind();


                NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                dgvEspecialidadxTurno.DataSource = negocioEspecialidadxMedico.listarconsulta();
                inputTurno.DataTextField = "Turno_Horario";
                inputTurno.DataBind();

                dgvEspecialidadxTurno.DataBind();

                listMedico = negocioEspecialidadxMedico.listarconsulta();
            }
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


        protected void Ingresar_Click(object sender, EventArgs e)
        {

            try
            {
                NegocioEspecialidadxMedico NegocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                EspecialidadxMedico especialidadxMedico = new EspecialidadxMedico();
                especialidadxMedico.ID_MEDICO = int.Parse(inputMedico.SelectedValue);
                especialidadxMedico.Id_Especialidad = int.Parse(inputEspecialidad.SelectedValue);
                especialidadxMedico.Turno_Horario = int.Parse(inputTurno.SelectedValue);
                NegocioEspecialidadxMedico.RegistrarEspecialidadxMedico(especialidadxMedico);
                Response.Redirect("Administrar_EspeyTurnoxMed");
                //lblmsg.Text = "Relacion cargada con exito.";

            }
            catch(Exception exception) 
            {
                // Capturar la excepción de duplicación 
                if (EsExcepcionDuplicacionEspTur(exception))
                {
                    lblmsg.Text = "⚠ Ya existe esa relacion.";
                    
                }
                else
                {
                    lblmsg.Text = "Ocurrió un error al crear la relacion.";
                    Console.WriteLine(exception);
                }
                Session.Add("Error", "Que paso Manito");
                //Console.WriteLine(exception);
                //throw;
            }
        }
        //FUNCION PARA CHECKEAR SI HAY DNI DUPLICADO EN LA BASE DE DATOS
        private bool EsExcepcionDuplicacionEspTur(Exception exception)
        {

            if (exception is SqlException sqlException && sqlException.Number == 2627)
            {
                return true;
            }

            return false;
        }
    }
}
