using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Tablero : Page
    {
        protected Usuario usuario { get; set; }
        public List<Especialidad> ListaEspecialidades { get; set; }
        public List<Turnos> ListaTurnos { get; set; }
        public List<Paciente> ListaPacientes { get; set; }
        public List<Medico>ListMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            * 0 = Nuevo
            * 1= Confirmado
            * 2= Cancelado
            * 3= No Asisitio
            * 4= Reprogramado
            * 5= Cerrado
            * 
            */
            if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }
            
            usuario = (Usuario)Session["usuario"];
            
            NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
            ListaEspecialidades = negocioEspecialidad.listar();
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            ListaPacientes = negocioPaciente.listar();
            if (usuario.ID_TIPOUSUARIO <3)
            {
                NegocioTurno negocio = new NegocioTurno();
                ListaTurnos = negocio.listar().OrderByDescending(x => x.fecha).ToList();
               
                
            }

            if (usuario.ID_TIPOUSUARIO == 3)
            {
                NegocioMedico negocioMedico = new NegocioMedico();
                ListMedicos = negocioMedico.listar();

                Medico medico = ListMedicos.Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
                NegocioTurno negocio = new NegocioTurno();
                ListaTurnos = negocio.listar();
                ListaTurnos = ListaTurnos.FindAll(x => x.Id_Medico == medico.ID_MEDICO).OrderByDescending(x => x.fecha).ToList();
                
            }

            if (usuario.ID_TIPOUSUARIO == 4)
            {
                Paciente paciente = ListaPacientes.Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
                NegocioTurno negocio = new NegocioTurno();
                ListaTurnos = negocio.listar();
                ListaTurnos = ListaTurnos.FindAll(x => x.Id_Paciente == paciente.ID_PACIENTE).OrderByDescending(x => x.fecha).ToList();
                
                
            }

            //List<Turnos> listaFiltrada = lista.FindAll(x => x.idUsuario == usuario.idUsuario);





        }

        protected void txtEspecialidad_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["ListaEspecialidades"];
            //List<Especialidad> listaFiltrada = lista.FindAll(x => x.nombre == txtEspecialidad.Text);
        }
    }
}