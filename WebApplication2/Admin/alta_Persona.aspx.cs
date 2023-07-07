﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
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
		public List<Especialidad> ListaEspecialidades { get; set; }
		public NegocioPaciente negocioPaciente;
		public NegocioMedico negocioMedico;
		protected void Page_Load(object sender, EventArgs e)
		{
			

            Session.Add("OK", null);
			string idPaciente = Request.QueryString["idPaciente"] != null ? Request.QueryString["idPaciente"].ToString() : "";
			string idUsuario = Request.QueryString["idUsuario"] != null ? Request.QueryString["idUsuario"].ToString() : "";
			if (idPaciente != "" && idUsuario != "" && !IsPostBack)
			{
				esPaciente = true;
				NegocioPaciente negocio = new NegocioPaciente();
				NegocioUsuario usuario = new NegocioUsuario();
				//List<Paciente> listaPacientes = negocio.listar(idPaciente);
				//Paciente seleccionado = listaPacientes[0];		
				Paciente seleccionado = (negocio.listar(idPaciente))[0];
				Usuario usuarioseleccionado = (usuario.listar(idUsuario))[0];
				inputUsuario.Text = usuarioseleccionado.DNI;
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
			else
			{
				
					esPaciente = false;
					
					NegocioPaciente negocioPaciente = new NegocioPaciente();
					NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
					ListaEspecialidades = negocioEspecialidad.listar();
					negocioPaciente = new NegocioPaciente();
					loco.Controls.Clear();
					
					ListBox checkBox = new ListBox();
					checkBox.ID = "nery";
					checkBox.SelectionMode = ListSelectionMode.Multiple;
					checkBox.CssClass = "form-control";

				if (IsPostBack)
				{
					foreach (Especialidad pivot in ListaEspecialidades)
					{
						checkBox.Items.Add(new ListItem(pivot.nombre, pivot.id.ToString()));

						loco.Controls.Add(checkBox);
					}
				}
					
			}

		}
					
			public bool esPaciente { get; set; }



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
				medico.Matricula = inputMatricula.Text;
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

				usuario.DNI = inputDNI.Text;
				usuario.PASSWORD = inputPassword.Text;
				usuario.CORREO = inputEmail.Text;
				usuario.ID_TIPOUSUARIO = 4;

				usuario.ID_USUARIO = negocioUsuario.RegistrarUsuario(usuario);
				//
				

				negocioUsuario.RegistrarUsuario(usuario,IDUSUARIO);
				Console.WriteLine("1"+inputNombres.Text);

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