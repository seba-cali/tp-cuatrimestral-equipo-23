﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace WebApplication2
{
	public partial class Cartilla : System.Web.UI.Page
	{
		public List<Especialidad> ListaEspecialidades { get; set; }
		public List<Medico> ListaMedicos { get; set; }
		public List<EspecialidadxMedico> ListaEspecialidadesxMedico { get; set; }



		protected void Page_Load(object sender, EventArgs e)
		{
			NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
			ListaEspecialidades = negocioEspecialidad.listar();

			NegocioMedico negocioMedico = new NegocioMedico();
			ListaMedicos = negocioMedico.listar();

			NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
			ListaEspecialidadesxMedico = negocioEspecialidadxMedico.listar();



		}
	}
}