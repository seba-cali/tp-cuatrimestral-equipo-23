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
		protected void Page_Load(object sender, EventArgs e)
		{
			NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
			ListaEspecialidades = negocioEspecialidad.listar();
			foreach(Especialidad pivot in ListaEspecialidades)
			{
				check = new CheckBox();
				check.ID = pivot.id.ToString();
				check.
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
	}
}