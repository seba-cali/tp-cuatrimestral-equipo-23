using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Usuarios : Page
    {
        public List<Usuario> usuariosx { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioUsuario negocioUsuarios = new NegocioUsuario();
            usuariosx = negocioUsuarios.listar();
        }
    }
}