using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Perfil : Page
    {
        public string imgName;
        public string imgPath;
        public Usuario usuario { get; set; }
        public Paciente paciente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null )
            {
                Response.Redirect("Default.aspx", false);
            }
            
            usuario = (Usuario)Session["usuario"];
            if (usuario.ID_TIPOUSUARIO == 3)
            {
                Response.Redirect("Tablero.aspx", false);
            }
            mensaje.Text = Session["debe"] != null ? Session["debe"].ToString() : "";
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            paciente = negocioPaciente.listar().Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
            if (!IsPostBack)
            {
                
            if (paciente != null)
            {
                inputNombre.Text = paciente.nombres;
                inputApellido.Text = paciente.apellidos;
                inputDNI.Text = paciente.DNI;
                inputFNacimiento.Text = paciente.fechaNacimiento.ToString("dd-MM-yyyy");
                inputDomicilio.Text = paciente.direccion;
                inputTelefono.Text = paciente.telefono;
                inputSexo.SelectedValue = paciente.sexo;
                Image1.ImageUrl = usuario.img_url;
            }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StartUpLoad();
        }

        private void StartUpLoad()
        {
            imgName = string.Empty;
            int imgSize = 0;
            imgPath = string.Empty;
            
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                           
                imgName = FileUpload1.PostedFile.FileName;
                           
                imgPath = "../assets/img/" + imgName;
                  
                imgSize = FileUpload1.PostedFile.ContentLength;
                  
                if (imgSize > 5242880)
                {
                    Session.Add("error", "Imagen grande");
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath(imgPath));
                    Image1.ImageUrl = imgPath;
                    Session.Add("ok", "Exito");
                    //usuario.img_url = imgPath ?? usuario.img_url;
                    NegocioUsuario negocioUsuario = new NegocioUsuario();
                    usuario.img_url = imgPath ?? usuario.img_url;
                    negocioUsuario.updateImg(usuario);
                }
            }
        }

        protected void guardar_OnClick(object sender, EventArgs e)
        {
            try
            {
                

                NegocioPaciente negocioPaciente = new NegocioPaciente();

                paciente = negocioPaciente.listar().Find(x => x.ID_USUARIO == usuario.ID_USUARIO);
                if (paciente == null)
                {Console.WriteLine("sdasdasd");
                    paciente = new Paciente();
                    paciente.ID_PACIENTE = 0;
                }

                paciente.ID_USUARIO = usuario.ID_USUARIO;
                paciente.nombres = inputNombre.Text;
                paciente.apellidos = inputApellido.Text;
                paciente.DNI = inputDNI.Text;
                paciente.ESTADO = true;
                paciente.fechaNacimiento = Convert.ToDateTime(inputFNacimiento.Text);
                paciente.direccion = inputDomicilio.Text;
                paciente.telefono = inputTelefono.Text;
                paciente.sexo = inputSexo.SelectedValue;

                

                if (paciente.ID_PACIENTE > 0 )
                {
                    
                    negocioPaciente.RegistrarPaciente(paciente, paciente.ID_PACIENTE);
                    Session.Add("ok", "Exito: Se Actualizo Cliente");
                }
                else
                {
                    negocioPaciente.RegistrarPaciente(paciente, 0);
                    Session.Add("ok", "Exito: Se Creo Cliente");
                    
                }

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}