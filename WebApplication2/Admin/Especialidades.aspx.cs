using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Dominio;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.FriendlyUrls;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Especialidades : Page
    {
        
        public List<Especialidad> ListaEspecialidades { get; set; }
        public NegocioEspecialidad negocioEspecialidad;
        public Especialidad especialidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }

            if (!IsPostBack)
            {
                Session["OK"] = null;
                Session["class"] = null;
                Session["error"] = null;
            }
            /*formGroupIdDelete.Text = "";
            formGroupId.Text = "";
            formGroupNameEdit.Text = "";
            formGroupDescEdit.Text = "";
            formGroupURLEdit.Text = "";
            formGroupName.Text = "";
            formGroupDesc.Text = "";
            formGroupURL.Text = "";*/
                
            
            negocioEspecialidad = new NegocioEspecialidad();
            ListaEspecialidades = new List<Especialidad>();
            ListaEspecialidades = negocioEspecialidad.listar();
            ListaEspecialidades.OrderBy(x => x.id);
            
        }

        protected void AltaEscpecialidad(object sender, EventArgs e)
        {
            
            try
            {
                
                especialidad = new Especialidad();
                negocioEspecialidad = new NegocioEspecialidad();
                
                especialidad.nombre = formGroupName.Text;
                especialidad.descripcion = formGroupDesc.Text;
                especialidad.url_img_esp = formGroupURL.Text;
                especialidad.id =negocioEspecialidad.RegistrarEspecialidad(especialidad);
                if (especialidad.id > 0)
                {
                    ListaEspecialidades.Add(especialidad);
                    ListaEspecialidades.OrderBy(x => x.id);
                    seetval();
                    Session.Add("OK", "SE CREO LA ESPECIALIDAD CON EXITO");
                    Session.Add("class", "succes");
                    
                }

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
            
            try
            {

                especialidad = new Especialidad();
                
                negocioEspecialidad= new NegocioEspecialidad();
                
                string pro = formGroupId.Text;
                especialidad.nombre = formGroupNameEdit.Text;
                especialidad.descripcion = formGroupDescEdit.Text;
                especialidad.url_img_esp = formGroupURLEdit.Text;
                if (ListaEspecialidades.Find(x => x.id.Equals(int.Parse(pro))) != null){
                    negocioEspecialidad.RegistrarEspecialidad(especialidad, int.Parse(pro));
                    ListaEspecialidades.Find(x => x.id == int.Parse(pro)).nombre = especialidad.nombre;
                    ListaEspecialidades.Find(x => x.id == int.Parse(pro)).descripcion = especialidad.descripcion;
                    ListaEspecialidades.Find(x => x.id == int.Parse(pro)).url_img_esp = especialidad.url_img_esp;
                    ListaEspecialidades.OrderBy(x => x.id);
                    
                    
                    Session.Add("OK", "SE Actualizo Manito EXITO id: "+pro);
                    Session.Add("class", "succes");
                    
                }
                else
                {
                    Session.Add("Error", "No existe la especialidad con ese ID");
                    Session.Add("class", "warning");
                    
                }
                seetval();
                
                
            }
            catch (Exception exception)
            {
                Session.Add("Error", exception.ToString());
                Console.WriteLine(exception);
                throw;
                
            }
        }

        protected void EliminaEscpecialidad(object sender, EventArgs e)
        {
            
            try
            {
                string pro = formGroupIdDelete.Text;
                
                if (ListaEspecialidades.Find(x => x.id.Equals(int.Parse(pro)) )!= null )
                {
                    negocioEspecialidad = new NegocioEspecialidad();
                    negocioEspecialidad.eliminar(int.Parse(pro));
                    ListaEspecialidades.Remove(ListaEspecialidades.Find(x => x.id == int.Parse(pro)));
                    
                    Session.Add("OK", "SE Elimino con EXITO id :"+ pro);
                    Session.Add("class", "danger");
                }
                else{
                    
                    Session.Add("Error", "No existe la especialidad con ese ID");
                    Session.Add("class", "warning");
                }

                seetval();
            }
            catch (Exception exception)
            {
                Session.Add("Error", exception.ToString());
                Console.WriteLine(exception);
                throw;

            }
        }

        protected void seetval()
        {
            formGroupIdDelete.Text = "";
            formGroupId.Text = "";
            
            formGroupNameEdit.Text = "";
            formGroupDescEdit.Text = "";
            formGroupURLEdit.Text = "";
            formGroupName.Text = "";
            formGroupDesc.Text = "";
            formGroupURL.Text = "";
            
            
        }
    }
}