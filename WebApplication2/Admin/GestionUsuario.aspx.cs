using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
	public partial class GestionUsuario : Page
	{
		public Usuario usuario { get; set; }
		public List<Usuario> ListaUsuarios { get; set; }
		public List<Medico> ListaMedicos { get; set; }
		public List<Paciente> ListaPacientes { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{


			/*if (Session["usuario"] == null)
			{
				 Response.Redirect("Default.aspx", false);
			}


			usuario = (Usuario)Session["usuario"];*/

			//if (usuario.ID_TIPOUSUARIO == 1)
			{
				NegocioUsuario negocioUsuario = new NegocioUsuario();
				ListaUsuarios = negocioUsuario.listar();
				NegocioMedico negocioMedico = new NegocioMedico();
				ListaMedicos = negocioMedico.listar();
				NegocioPaciente negocioPaciente = new NegocioPaciente();
				ListaPacientes = negocioPaciente.listar();

			}
			// else
			{
				// Response.Redirect("Tablero.aspx", false);
			}
		}

		protected void modificaUsuario(object sender, EventArgs e)
		{


		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			if (int.TryParse(Verdura.Text, out int id))
			{
				NegocioUsuario negocioUsuario = new NegocioUsuario();
				if(inputEstado.SelectedValue!="0"){
					bool estado = inputEstado.SelectedValue == "true" ? true : false;
					negocioUsuario.bajaLogica(id, estado);
				}
				if(inputSetUser.SelectedValue!="0"){
					int nuevoRolId = int.Parse(inputSetUser.SelectedValue);
					negocioUsuario.cambiarRol(id, nuevoRolId); // Llamar a la función cambiarRol con el nuevoRolId
				}
				Response.Redirect("GestionUsuario.aspx", false);
			}
			else
			{
				// Mostrar un mensaje de error al usuario: "El ID debe ser un número válido."
			}

		}
	}
}