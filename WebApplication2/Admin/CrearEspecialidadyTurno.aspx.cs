using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class CrearEspecialidadyTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Realiza las operaciones de guardado de la especialidad y turno
            // Accede a los valores seleccionados de los DropDownList utilizando ddlMedico.SelectedValue, ddlEspecialidad.SelectedValue, ddlTurno.SelectedValue, etc.

            // Cierra la página emergente y actualiza la página actual
            string script = "window.opener.location.reload(); window.close();";
            ClientScript.RegisterStartupScript(this.GetType(), "closePopup", script, true);
        }
    }
}