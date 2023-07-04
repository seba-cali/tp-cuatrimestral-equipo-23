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
		public NegocioMedico negocioMedico;
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


        public bool MedicoElegido { get; set; }
        protected void chkMedico_CheckedChanged(object sender, EventArgs e)
        {
            MedicoElegido = chkMedico.Checked;
         
        }





        public void btnSubmit_Click(object sender, EventArgs e)
		{
			Session.Add("OK", "");
			try
			{

				Paciente paciente = new Paciente();
				Usuario usuario = new Usuario();
				NegocioUsuario negocioUsuario = new NegocioUsuario();
				negocioPaciente = new NegocioPaciente();

				usuario.DNI = inputDNI.Text;
				usuario.PASSWORD = inputPassword.Text;
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
				paciente.ID_USUARIO= usuario.ID_USUARIO;
				paciente.DNI = inputDNI.Text;
				paciente.ID_PACIENTE = negocioPaciente.RegistrarPaciente(paciente,0);
				Session.Add("OK", "SE CREO EL PACIENTE CON EXITO");

			}
			catch (Exception exception)
			{
				Session.Add("Error", "Que paso Manito");
				Console.WriteLine(exception);
				throw;
			}
		}

        protected void AltaMedico_Click(object sender, EventArgs e)
        {
            Session.Add("OK", "");
            try
            {

                Medico medico = new Medico();
                Usuario usuario = new Usuario();
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                negocioMedico = new NegocioMedico();
                usuario.DNI = inputDNI.Text;
                usuario.PASSWORD = inputPassword.Text;
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
				medico.ID_MEDICO = negocioMedico.RegistrarMedico(medico, 0);
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