using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Especialidades : Page
    {
        public List<Especialidad> ListaEspecialidades { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
            ListaEspecialidades = negocioEspecialidad.listar();
        }

        protected void AltaEscpecialidad(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void EditarEscpecialidad(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}