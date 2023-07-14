using System;
using System.Web.UI;

namespace WebApplication2.Admin
{
    public partial class Perfil : Page
    {
        public string imgName ;
        public string imgPath ;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["usuario"]==null )
            {
                Response.Redirect("Default.aspx", false);
            }
            
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
                    
                }    
            }  
        }

        protected void guardar_OnClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
