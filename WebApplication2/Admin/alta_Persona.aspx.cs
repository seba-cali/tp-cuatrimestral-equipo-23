using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Admin
{
	public partial class alta_Persona : System.Web.UI.Page
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
			string idPaciente = Request.QueryString["idPaciente"] != null ? Request.QueryString["idPaciente"].ToString() : "";
			string idUsuario = Request.QueryString["idUsuario"] != null ? Request.QueryString["idUsuario"].ToString() : "";
			//todo:Checkear por que Paciente no crea ni usuario ni paciente si algo falla, pero medico si lo hace (no deberia)
			if (idPaciente != "" && idUsuario != "" && !IsPostBack)
			{
				esMedico = false;
				esPaciente = true;
				NegocioPaciente negocio = new NegocioPaciente();
				NegocioUsuario usuario = new NegocioUsuario();
				//List<Paciente> listaPacientes = negocio.listar(idPaciente);
				//Paciente seleccionado = listaPacientes[0];		
				Paciente seleccionado = (negocio.listar(idPaciente))[0];
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
			}
			else if (idMedico != "" && idUsuario != "" && !IsPostBack)
			{
				esMedico = true;
				esPaciente = false;
				MedicoElegido = true;
				chkMedico.Checked = true;
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
				//ListBox checkBox = new ListBox();
				//checkBox.ID = "nery";
				//checkBox.SelectionMode = ListSelectionMode.Multiple;
				//checkBox.CssClass = "form-control";
				//if (IsPostBack)
				//{

				//    foreach (Especialidad pivot in ListaEspecialidades)
				//    {
				//        checkBox.Items.Add(new ListItem(pivot.nombre, pivot.id.ToString()));
				//    }

				//    loco.Controls.Add(checkBox);
				//}

			}
			else
			{
				/*esPaciente = false;

				NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
				List<Especialidad> ListaEspecialidades=new List<Especialidad>();
				 ListaEspecialidades= negocioEspecialidad.listar();

				ListBox checkBox = new ListBox();

				checkBox.ID = "nery";
				checkBox.SelectionMode = ListSelectionMode.Multiple;
				checkBox.CssClass = "form-control";				
				*/
				esPaciente = false;
				esMedico = false;

				NegocioPaciente negocioPaciente = new NegocioPaciente();
				//NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
				//ListaEspecialidades = negocioEspecialidad.listar();
				//negocioPaciente = new NegocioPaciente();
				//loco.Controls.Clear();

				//ListBox checkBox = new ListBox();
				//checkBox.ID = "nery";
				//checkBox.SelectionMode = ListSelectionMode.Multiple;
				//checkBox.CssClass = "form-control";

				//if (IsPostBack)
				//{

				//	foreach (Especialidad pivot in ListaEspecialidades)
				//	{
				//		checkBox.Items.Add(new ListItem(pivot.nombre, pivot.id.ToString()));
				//	}

				//	loco.Controls.Add(checkBox);
				//}
			}
		}

		public bool esPaciente { get; set; }
		public bool esMedico { get; set; }

		public bool MedicoElegido { get; set; }
		protected void chkMedico_CheckedChanged(object sender, EventArgs e)
		{
			MedicoElegido = chkMedico.Checked;

		}
		public void btnSubmit_Click(object sender, EventArgs e)
		{
			Session.Add("OK", "");
			inputMatricula.CausesValidation = false;
			rfvMatricula.Enabled = false;
			//validacion general para que se carguen todos los campos espeficicados como requeridos en alta persona en el front
			if (Page.IsValid)
			{
				try
				{
					
					//CREACION DE PACIENTE NUEVO
					Paciente paciente = new Paciente();
					Usuario usuario = new Usuario();
					NegocioUsuario negocioUsuario = new NegocioUsuario();
					negocioPaciente = new NegocioPaciente();

					usuario.username = inputDNI.Text; //aca usamos el mismo input tanto para paciente como para usuario
					usuario.PASSWORD = usuario.encriptar(inputPassword.Text);
					usuario.CORREO = inputEmail.Text;
					usuario.ID_TIPOUSUARIO = 4;
					usuario.ID_USUARIO = negocioUsuario.RegistrarUsuario(usuario);
					paciente.nombres = inputNombres.Text;
					paciente.apellidos = inputApellidos.Text;
					paciente.sexo = inputSexo.Text;
					paciente.fechaNacimiento = Convert.ToDateTime(inputFechaNacimiento.Text);
					paciente.telefono = inputTelefono.Text;
					paciente.CORREO = inputEmail.Text;  //va o copia de usuario?
					paciente.direccion = inputDireccion.Text;
					paciente.ESTADO = true;
					paciente.ID_USUARIO = usuario.ID_USUARIO;
					paciente.DNI = inputDNI.Text;
					paciente.ID_PACIENTE = negocioPaciente.RegistrarPaciente(paciente, 0);
					Session.Add("OK", "SE CREO EL PACIENTE CON EXITO");
					LimpiarControles(this);
					lblmsg.Text = "😷 Se creó el paciente con éxito.";

				}
				catch (Exception exception)
				{
					// Capturar la excepción de duplicación de DNI
					if (EsExcepcionDuplicacionDNI(exception))
					{
						lblmsg.Text = "⚠ Ya existe un paciente o usuario con ese DNI.";
						inputDNI.Text = string.Empty;
						//inputUsuario.Text = string.Empty;
					}
					else
					{
						lblmsg.Text = "Ocurrió un error al crear el paciente.";
						Console.WriteLine(exception);
					}
					Session.Add("Error", "Que paso Manito");
					//Console.WriteLine(exception);
					//throw;
				}
			}

			else
			{
				lblmsg.Text = "Llene todos los campos para cargar Paciente";
			}
		}
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

					// Obtén las especialidades seleccionadas
					//TODO: comento estas lineas porque ya las especialidades no se cargan desde aca
					//NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
					//EspecialidadxMedico especialidadxMedico = new EspecialidadxMedico();
					//ListBox checkBox = (ListBox)loco.FindControl("nery");
					//List<int> especialidadesSeleccionadas = new List<int>();
					//foreach (ListItem item in checkBox.Items)
					//{
					//	if (item.Selected)
					//	{
					//		int idEspecialidad = Convert.ToInt32(item.Value);
					//		especialidadesSeleccionadas.Add(idEspecialidad);
					//		especialidadxMedico.ID_MEDICO = medico.ID_MEDICO;
					//		especialidadxMedico.Id_Especialidad = idEspecialidad;
					//		negocioEspecialidadxMedico.RegistrarEspecialidadxMedico(especialidadxMedico);
					//	}
					//}

					Session.Add("OK", "SE CREO EL MEDICO CON EXITO");
					LimpiarControles(this);
					MedicoElegido = false;
					chkMedico.Checked = false;
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
						MedicoElegido = false;
						chkMedico.Checked = false;
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
				lblmsg.Text = "Llene todos los campos para cargar Médico";
			}
		}
		protected void btnActualizarPaciente_Click(object sender, EventArgs e)
		{
			int IDPACIENTE = Convert.ToInt32(Request.QueryString["idPaciente"]);
			int IDUSUARIO = Convert.ToInt32(Request.QueryString["idUsuario"]);

			Session.Add("OK", "");
			try
			{
				Paciente paciente = new Paciente();
				Usuario usuario = new Usuario();
				NegocioUsuario negocioUsuario = new NegocioUsuario();
				negocioPaciente = new NegocioPaciente();

				usuario.username = inputDNI.Text;
				usuario.PASSWORD = usuario.encriptar(inputPassword.Text);
				usuario.CORREO = inputEmail.Text;
				usuario.ID_TIPOUSUARIO = 4;
				negocioUsuario.RegistrarUsuario(usuario, IDUSUARIO);
				paciente.nombres = inputNombres.Text;
				paciente.apellidos = inputApellidos.Text;
				paciente.sexo = inputSexo.Text;
				paciente.fechaNacimiento = Convert.ToDateTime(inputFechaNacimiento.Text);
				paciente.telefono = inputTelefono.Text;
				paciente.CORREO = inputEmail.Text;  //va o copia de usuario?
				paciente.direccion = inputDireccion.Text;
				paciente.ESTADO = true;
				paciente.ID_USUARIO = IDUSUARIO;
				paciente.DNI = inputDNI.Text;
				paciente.ID_PACIENTE = negocioPaciente.RegistrarPaciente(paciente, IDPACIENTE);
				Session.Add("OK", "SE ACTUALIZO EL PACIENTE CON EXITO");
				Response.Redirect("Administrar_Personas.aspx", false);

				Session.Add("OK", "SE ACTUALIZO EL PACIENTE CON EXITO");
				LimpiarControles(this);
				MedicoElegido = false;
				chkMedico.Checked = false;
				lblmsg.Text = "🤧 Se actualizo el paciente con éxito.";


			}
			catch (Exception exception)
			{
				Session.Add("Error", "Que paso Manito");
				Console.WriteLine(exception);
				throw;
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
				Response.Redirect("Administrar_Personas.aspx", false);

				Session.Add("OK", "SE ACTUALIZO EL MEDICO CON EXITO");
				LimpiarControles(this);
				MedicoElegido = false;
				chkMedico.Checked = false;
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
					MedicoElegido = false;
					chkMedico.Checked = false;
					//inputUsuario.Text = string.Empty;
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