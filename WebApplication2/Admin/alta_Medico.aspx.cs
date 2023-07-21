using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using ConexionDB;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication2.Admin
{
	public partial class alta_Medico : System.Web.UI.Page
	{
        public CheckBox check;
        public List<string> SeleccionEspecialidad { get; set; }
        public void LimpiarControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = (TextBox)c;
                    textBox.Text = string.Empty;
                }
                else if (c is DropDownList)
                {
                    DropDownList dropDownList = (DropDownList)c;
                    dropDownList.ClearSelection();
                }
                else if (c is CheckBoxList)
                {
                    CheckBoxList checkBoxList = (CheckBoxList)c;
                    foreach (ListItem item in checkBoxList.Items)
                    {
                        item.Selected = false;
                    }
                }
                else if (c is RadioButtonList)
                {
                    RadioButtonList radioButtonList = (RadioButtonList)c;
                    radioButtonList.ClearSelection();
                }

                if (c.HasControls())
                {
                    LimpiarControles(c);
                }
            }
        }





        public List<Especialidad> ListaEspecialidades { get; set; }

        public NegocioPaciente negocioPaciente;
        public NegocioMedico negocioMedico;

        protected void Page_Load(object sender, EventArgs e)
        {


            Session.Add("OK", null);
            string idMedico = Request.QueryString["idMedico"] != null ? Request.QueryString["idMedico"].ToString() : "";
            string idUsuario = Request.QueryString["idUsuario"] != null ? Request.QueryString["idUsuario"].ToString() : "";
            //todo:Checkear por que Paciente no crea ni usuario ni paciente si algo falla, pero medico si lo hace (no deberia)

            if (idMedico != "" && idUsuario != "" && !IsPostBack)
            {
                esMedico = true;
                NegocioMedico negocio = new NegocioMedico();
                NegocioUsuario usuario = new NegocioUsuario();
                //List<Paciente> listaPacientes = negocio.listar(idPaciente);
                //Paciente seleccionado = listaPacientes[0];		
                Medico seleccionado = (negocio.listar(idMedico))[0];
                Usuario usuarioseleccionado = (usuario.listar(idUsuario))[0];
                inputDNI.Text = usuarioseleccionado.username;
                inputPassword.Text = usuarioseleccionado.PASSWORD;
                inputRePassword.Text = usuarioseleccionado.PASSWORD;
                inputEmail.Text = usuarioseleccionado.CORREO;
                inputNombres.Text = seleccionado.nombres;
                inputApellidos.Text = seleccionado.apellidos;
                //precargar fecha de nacimiento	
                DateTime fechaNacimiento = seleccionado.fechaNacimiento;
                inputFechaNacimiento.Text = fechaNacimiento.ToString("yyyy-MM-dd");
                //precargar combobox sexo
                inputSexo.SelectedValue = seleccionado.sexo;
                inputTelefono.Text = seleccionado.telefono;
                inputDireccion.Text = seleccionado.direccion;
                inputDNI.Text = seleccionado.DNI;
                inputMatricula.Text = seleccionado.Matricula;

            }
            
        }
        public bool esMedico { get; set; }

        //FUNCION PARA CHECKEAR SI HAY DNI DUPLICADO EN LA BASE DE DATOS
        private bool EsExcepcionDuplicacionDNI(Exception exception)
        {
            if (exception is SqlException sqlException && sqlException.Number == 2627)
            {
                return true;
            }
            return false;
        }
        //FIN FUNCION PARA CHECKEAR SI HAY DNI DUPLICADO EN LA BASE DE DATOS
        protected void AltaMedico_Click(object sender, EventArgs e)
        {
            Session.Add("OK", "");
            rfvMatricula.Enabled = true;
            inputMatricula.CausesValidation = true;
            if (Page.IsValid)
            {
                try
                {
                    Medico medico = new Medico();
                    Usuario usuario = new Usuario();
                    NegocioUsuario negocioUsuario = new NegocioUsuario();
                    negocioMedico = new NegocioMedico();
                    usuario.username = inputDNI.Text;
                    usuario.PASSWORD = usuario.encriptar(inputPassword.Text);
                    usuario.CORREO = inputEmail.Text;
                    usuario.ID_TIPOUSUARIO = 3;
                    usuario.ID_USUARIO = negocioUsuario.RegistrarUsuario(usuario);
                    medico.nombres = inputNombres.Text;
                    medico.apellidos = inputApellidos.Text;
                    medico.sexo = inputSexo.Text;
                    medico.fechaNacimiento = Convert.ToDateTime(inputFechaNacimiento.Text);
                    medico.telefono = inputTelefono.Text;
                    medico.CORREO = inputEmail.Text;  //va o copia de usuario?
                    medico.direccion = inputDireccion.Text;
                    medico.ESTADO = true;
                    medico.ID_USUARIO = usuario.ID_USUARIO;
                    medico.DNI = inputDNI.Text;
                    medico.Matricula = inputMatricula.Text;
                    medico.ID_MEDICO = negocioMedico.RegistrarMedico(medico, 0);

                    Session.Add("OK", "SE CREO EL MEDICO CON EXITO");
                    LimpiarControles(this);
                    lblmsg.Text = "⚕ Se creó el médico con éxito.";
                }
                catch (Exception exception)
                {
                    // Capturar la excepción de duplicación de DNI, usuario o Matricula
                    if (EsExcepcionDuplicacionDNI(exception))
                    {
                        lblmsg.Text = "⚠ Ya existe un médico o usuario con ese DNI o Matricula.";
                        inputDNI.Text = string.Empty;
                        inputMatricula.Text = string.Empty;
                        //inputUsuario.Text = string.Empty;
                    }
                    else
                    {
                        lblmsg.Text = "Ocurrió un error al crear el medico.";
                        Console.WriteLine(exception);
                    }
                    Session.Add("Error", "Que paso Manito");
                    //Console.WriteLine(exception);
                    //throw;
                }
            }
            else
            {
                lblmsg.Text = "Complete todos los campos para cargar Médico";
            }
        }
        protected void btnActualizarMedico_Click(object sender, EventArgs e)
        {
            int IDMEDICO = Convert.ToInt32(Request.QueryString["idMedico"]);
            int IDUSUARIO = Convert.ToInt32(Request.QueryString["idUsuario"]);

            Session.Add("OK", "");
            try
            {
                Medico medico = new Medico();
                Usuario usuario = new Usuario();
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                negocioMedico = new NegocioMedico();
                usuario.username = inputDNI.Text;
                usuario.PASSWORD = usuario.encriptar(inputPassword.Text);
                usuario.CORREO = inputEmail.Text;
                usuario.ID_TIPOUSUARIO = 3;
                negocioUsuario.RegistrarUsuario(usuario, IDUSUARIO);
                medico.nombres = inputNombres.Text;
                medico.apellidos = inputApellidos.Text;
                medico.sexo = inputSexo.Text;
                medico.fechaNacimiento = Convert.ToDateTime(inputFechaNacimiento.Text);
                medico.telefono = inputTelefono.Text;
                medico.CORREO = inputEmail.Text;  //va o copia de usuario?
                medico.direccion = inputDireccion.Text;
                medico.ESTADO = true;
                medico.ID_USUARIO = IDUSUARIO;
                medico.DNI = inputDNI.Text;
                medico.Matricula = inputMatricula.Text;
                medico.ID_MEDICO = negocioMedico.RegistrarMedico(medico, IDMEDICO);
                Response.Redirect("Administrar_Medicos.aspx", false);

                Session.Add("OK", "SE ACTUALIZO EL MEDICO CON EXITO");
                LimpiarControles(this);
                lblmsg.Text = "⚕ Se actualizo el médico con éxito.";




            }
            catch (Exception exception)
            {
                // Capturar la excepción de duplicación de DNI, usuario o Matricula
                if (EsExcepcionDuplicacionDNI(exception))
                {
                    lblmsg.Text = "⚠ Ya existe un médico o usuario con ese DNI o Matricula.";
                    inputDNI.Text = string.Empty;
                    inputMatricula.Text = string.Empty;
                }
                else
                {
                    lblmsg.Text = "Ocurrió un error al actualizar el medico.";
                    Console.WriteLine(exception);
                }
                Session.Add("Error", "Que paso Manito");
                //Console.WriteLine(exception);
                //throw;
            }
        }
    }
}
