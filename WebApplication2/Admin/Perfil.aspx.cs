using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Perfil : Page
    {
        public string imgName ;
        public string imgPath ;
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["usuario"]==null )
            {
                Response.Redirect("Default.aspx", false);
            }
            usuario = (Usuario)Session["usuario"];
            if (!IsPostBack)
            {
                
            }
            mensaje.Text = Session["debe"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e) {  
            StartUpLoad();  
        }  
     
        private void StartUpLoad() {  
             imgName = string.Empty;  
            int imgSize = 0;
             imgPath = string.Empty;       
       
            //validates the posted file before saving  
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "") {  
                //get the file name of the posted image           
                imgName = FileUpload1.PostedFile.FileName; 
                //sets the image path           
                imgPath = "../assets/img/" + imgName; 
                //get the size in bytes that  
                imgSize = FileUpload1.PostedFile.ContentLength;  
                // 10240 KB means 10MB, You can change the value based on your requirement  
                if (imgSize > 5242880) {  
                    Session.Add("error","Imagen grande");  
                }  else {  
                    //then save it to the Folder  
                    FileUpload1.SaveAs(Server.MapPath(imgPath));  
                    Image1.ImageUrl = imgPath;  
                    Session.Add("ok","Exito");  
                    usuario.img_url = imgPath??usuario.img_url;
                }    
            }  
        }

        protected void guardar_OnClick(object sender, EventArgs e)
        {
            try
            {
                
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                    
                NegocioPaciente negocioPaciente = new NegocioPaciente();
                Paciente paciente = new Paciente();
                paciente.ID_USUARIO = usuario.ID_USUARIO;
                paciente.nombres = inputNombre.Text;
                paciente.apellidos = inputApellido.Text;
                paciente.DNI = inputDNI.Text;
                paciente.fechaNacimiento = Convert.ToDateTime(inputFNacimiento.Text);
                paciente.direccion = inputDomicilio.Text;
                paciente.telefono = inputTelefono.Text;
                paciente.sexo = inputSexo.SelectedValue;
                
                usuario.img_url = imgPath??usuario.img_url;
                negocioUsuario.updateImg(usuario);
                
                negocioPaciente.RegistrarPaciente(paciente,0);
                
                Session.Add("ok","Exito: Se Creo Cliente");
                Response.Redirect("Default.aspx",false);

            }
            catch (Exception ex)
            {
                Session.Add("error",ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
