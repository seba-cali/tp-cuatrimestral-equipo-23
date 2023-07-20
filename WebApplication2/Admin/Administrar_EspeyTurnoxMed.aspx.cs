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

                NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                NegocioMedico negocioMedico = new NegocioMedico();
                Medico medico = new Medico();

                string idMedico = Request.QueryString["idMedico"] != null ? Request.QueryString["idMedico"].ToString() : "";
                inputMedico.DataSource = negocioMedico.listar(idMedico);
                medico = negocioMedico.LlamarMedico(idMedico);
                lblMedico.Text = "Medico: "+medico.NombreCompleto;
                lblMatricula.Text = "M.N: "+medico.Matricula;
                inputMedico.DataTextField = "NombreCompleto";
                inputMedico.DataValueField = "ID_MEDICO";
                inputMedico.DataBind();

                NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
                inputEspecialidad.DataSource = negocioEspecialidad.listar();
                inputEspecialidad.DataTextField = "nombre";
                inputEspecialidad.DataValueField = "id";
                inputEspecialidad.DataBind();
                filtroEspecialidad.DataTextField= "nombre";
                filtroEspecialidad.DataValueField = "id";
                filtroEspecialidad.DataSource = negocioEspecialidad.listar();
                filtroEspecialidad.DataBind();


                
                dgvEspecialidadxTurno.DataSource = negocioEspecialidadxMedico.listarxMedico(idMedico);
                inputTurno.DataTextField = "Turno_Horario";
                inputTurno.DataBind();

                dgvEspecialidadxTurno.DataBind();
                //dgvEspecialidadxTurno.Columns[0].Visible = false;
                //dgvEspecialidadxTurno.Columns[1].Visible = false;
               //dgvEspecialidadxTurno.Columns[2].Visible = false;
                //dgvEspecialidadxTurno.Columns[4].Visible = false;
                //listMedico = negocioEspecialidadxMedico.listarxMedico(idMedico);
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
                Response.Redirect("Administrar_EspeYTurnoxMed.aspx?idMedico=" + idMedico, false);

            }
        }


        protected void Ingresar_Click(object sender, EventArgs e)
        {

            try
            {
                string idMedico = Request.QueryString["idMedico"] != null ? Request.QueryString["idMedico"].ToString() : "";
                NegocioEspecialidadxMedico NegocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                EspecialidadxMedico especialidadxMedico = new EspecialidadxMedico();
                especialidadxMedico.ID_MEDICO = int.Parse(inputMedico.SelectedValue);
                especialidadxMedico.Id_Especialidad = int.Parse(inputEspecialidad.SelectedValue);
                especialidadxMedico.Turno_Horario = int.Parse(inputTurno.SelectedValue);
                NegocioEspecialidadxMedico.RegistrarEspecialidadxMedico(especialidadxMedico);
                Response.Redirect("Administrar_EspeYTurnoxMed.aspx?idMedico=" + idMedico, false);
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

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkBox.NamingContainer;
            int idMedico = Convert.ToInt32(row.Cells[0].Text); // Suponiendo que el ID del médico está en la primera columna.
            int idEsp = Convert.ToInt32(row.Cells[2].Text); // Suponiendo que el ID de Especialidad está en la 3er columna.
            int Turno = Convert.ToInt32(row.Cells[4].Text); // Suponiendo que el Turno está en la 5ta columna.
            // Obtener el día de la semana según el ID del checkbox
            string diaSemana = checkBox.ID.Replace("cb", "");

            // Obtener el valor actual del checkbox (marcado o desmarcado)
            bool atiende = checkBox.Checked;

            // Realizar acciones según el día de la semana y el estado del checkbox
            if (diaSemana == "Lunes")
            {
                string dia = "Atiende_Lunes";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia,idMedico,idEsp,Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
                
            }
            else if (diaSemana == "Martes")
            {
                string dia = "Atiende_Martes";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia, idMedico, idEsp, Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
            }
            else if (diaSemana == "Miercoles")
            {
                string dia = "Atiende_Miercoles";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia, idMedico, idEsp, Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
            }
            else if (diaSemana == "Jueves")
            {
                string dia = "Atiende_Jueves";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia, idMedico, idEsp, Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
            }
            else if (diaSemana == "Viernes")
            {
                string dia = "Atiende_Viernes";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia, idMedico, idEsp, Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
            }
            else if (diaSemana == "Sabado")
            {
                string dia = "Atiende_Sabado";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia, idMedico, idEsp, Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
            }
            else if (diaSemana == "Domingo")
            {
                string dia = "Atiende_Domingo";
                if (atiende)
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.reactivarDia(dia, idMedico, idEsp, Turno);
                }
                else
                {
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    negocioEspecialidadxMedico.DesactivarDia(dia, idMedico, idEsp, Turno);
                }
            }

        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrar_Medicos.aspx");
        }

        protected void rblTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el valor seleccionado del RadioButtonList
                RadioButtonList rblTurnos = sender as RadioButtonList;
                int TurnoNuevo = Convert.ToInt32(rblTurnos.SelectedValue);
                NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                GridViewRow row = (GridViewRow)rblTurnos.NamingContainer;
                int idMedico = Convert.ToInt32(row.Cells[0].Text); // Suponiendo que el ID del médico está en la primera columna.
                int idEsp = Convert.ToInt32(row.Cells[2].Text); // Suponiendo que el ID de Especialidad está en la 3er columna.
                int TurnoViejo = Convert.ToInt32(row.Cells[4].Text); // Suponiendo que el Turno está en la 5ta columna.
                negocioEspecialidadxMedico.cambioTurno(TurnoNuevo, idMedico, idEsp, TurnoViejo);
                Response.Redirect("Administrar_EspeYTurnoxMed.aspx?idMedico=" + idMedico, false);
            }
            catch (Exception ex)
            {
                // Capturar la excepción de duplicación 
                if (EsExcepcionDuplicacionEspTur(ex))
                {
                    lblMsje.Text = "⚠ Ya existe esa relacion.";

                }
                else
                {
                    lblMsje.Text = "Ocurrió un error al crear la relacion.";
                    Console.WriteLine(ex);
                }

            }
        }

        protected void AplicarFiltro_Click(object sender, EventArgs e)
        {
            string idMedico = Request.QueryString["idMedico"] != null ? Request.QueryString["idMedico"].ToString() : "";
            NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
            dgvEspecialidadxTurno.DataSource = negocioEspecialidadxMedico.listarfiltro(filtroEspecialidad.SelectedValue,idMedico);
            dgvEspecialidadxTurno.DataBind();
        }

        protected void LimpiarFiltro_Click(object sender, EventArgs e)
        {
            string idMedico = Request.QueryString["idMedico"] != null ? Request.QueryString["idMedico"].ToString() : "";
            Response.Redirect("Administrar_EspeYTurnoxMed.aspx?idMedico=" + idMedico, false);
        }
    }
}
