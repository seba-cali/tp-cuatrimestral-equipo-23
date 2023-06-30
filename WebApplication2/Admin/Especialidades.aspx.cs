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
        public NegocioEspecialidad negocioEspecialidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("OK", null);
            
             negocioEspecialidad= new NegocioEspecialidad();
             ListaEspecialidades = negocioEspecialidad.listar();
        }

        protected void AltaEscpecialidad(object sender, EventArgs e)
        {
            Session.Add("OK", "");
            try
            {
                
                Especialidad especialidad = new Especialidad();
                especialidad.nombre = formGroupName.Text;
                especialidad.descripcion = formGroupDesc.Text;
                especialidad.url_img_esp = formGroupURL.Text;
                especialidad.id =negocioEspecialidad.RegistrarEspecialidad(especialidad,0);
                Session.Add("OK", "SE CREO LA ESPECIALIDAD CON EXITO");

            }
            catch (Exception exception)
            {
                Session.Add("Error", "Que paso Manito");
                Console.WriteLine(exception);
                throw;
            }
            
        }

        protected void EditarEscpecialidad(object sender, EventArgs e)
        {
            Session.Add("OK", "");
            try
            {

                Especialidad especialidad = new Especialidad();
                string pro = formGroupId.Text;
                Console.WriteLine(pro+"---tito");
                especialidad.nombre = formGroupNameEdit.Text;
                especialidad.descripcion = formGroupDescEdit.Text;
                especialidad.url_img_esp = formGroupURLEdit.Text;
                negocioEspecialidad.RegistrarEspecialidad(especialidad, int.Parse(pro));
                Session.Add("OK", "SE Actualizo Manito EXITO");

            }
            catch (Exception exception)
            {
                Session.Add("Error", exception.ToString());
                Console.WriteLine(exception);
                
            }
        }

        protected void EliminaEscpecialidad(object sender, EventArgs e)
        {
            Session.Add("OK", "");
            try
            {

                Especialidad especialidad = new Especialidad();
                string pro = formGroupId.Text;
                Console.WriteLine(pro + "---tito");
                negocioEspecialidad.eliminar(int.Parse(pro));
                Session.Add("OK", "SE Elimino Manito EXITO");

            }
            catch (Exception exception)
            {
                Session.Add("Error", exception.ToString());
                Console.WriteLine(exception);

            }
        }
    }
}