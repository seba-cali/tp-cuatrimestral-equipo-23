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


	public partial class alta_Persona : System.Web.UI.Page
	{
		public CheckBox check;
		public List<Especialidad> ListaEspecialidades { get; set; }
		public NegocioPaciente negocioPaciente;
		protected void Page_Load(object sender, EventArgs e)
		{
			Session.Add("OK", null);
			NegocioPaciente negocioPaciente = new NegocioPaciente();
			NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
			ListaEspecialidades = negocioEspecialidad.listar();
			negocioPaciente = new NegocioPaciente();
			foreach (Especialidad pivot in ListaEspecialidades)
			{
				check = new CheckBox();
				check.ID = pivot.id.ToString();
				check.CssClass = "form-check-input";
				/*btn.Text = "Agregar al carrito 🛒";
				btn.ID = index.ToString();
				btn.Click += new EventHandler(btnAddCarro_Click);
				btn.CommandArgument= item.Id.ToString();
				btn.CssClass = "btn btn-primary botonHidenPrincipal";
				heroP.Controls.Add(btn);
				index++;*/

			}

		}


        protected void Button1_Click(object sender, EventArgs e)
        {
           Console.WriteLine("asdasdasd **************");

        }

		protected void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				Usuario user = new Usuario();
				NegocioUsuario usuarioNegocio = new NegocioUsuario();
				Paciente paciente = new Paciente();
				//Medico medico = new Medico();

				user.DNI = inputDNI.Text;
				user.PASSWORD = inputPassword.Text;
				user.CORREO = inputEmail.Text;
				user.ID_TIPOUSUARIO = 4;
				user.ID_USUARIO = usuarioNegocio.RegistrarUsuario(user);
				paciente.nombres = inputNombres.Text;
				paciente.apellidos = inputApellidos.Text;
				paciente.direccion = inputDireccion.Text;
				paciente.telefono = inputTelefono.Text;
				paciente.fechaNacimiento = DateTime.Parse(inputFechaNacimiento.Text);
				paciente.ESTADO = true;
				paciente.ID_USUARIO = user.ID_USUARIO;



			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
		}

		public void btnSubmit_Click(object sender, EventArgs e)
		{
			Session.Add("OK", "");
			try
			{

				Paciente paciente = new Paciente();
				paciente.nombres = inputNombres.Text;
				paciente.apellidos = inputApellidos.Text;
				//no existe paciente.Usuario ni Password
				paciente.sexo = inputSexo.Text;
				paciente.fechaNacimiento = Convert.ToDateTime(inputFechaNacimiento.Text);
				paciente.telefono = inputTelefono.Text;
				paciente.CORREO = inputEmail.Text;  //va o copia de usuario?
				paciente.direccion = inputDireccion.Text;
				paciente.ID_USUARIO = negocioPaciente.RegistrarPaciente(paciente, 0);
				Session.Add("OK", "SE CREO EL PACIENTE CON EXITO");

			}
			catch (Exception exception)
			{
				Session.Add("Error", "Que paso Manito");
				Console.WriteLine(exception);
				throw;
			}
		}
	}
}