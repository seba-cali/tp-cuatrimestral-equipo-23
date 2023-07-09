using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    
    public partial class SisTurnos : Page
    {
        public int id_medico {get;set;}

        public void LimpiarControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = (TextBox)c;
                    textBox.Text = string.Empty;
                }
                else if (c is DropDownList)
                {
                    DropDownList dropDownList = (DropDownList)c;
                    dropDownList.ClearSelection();
                }
                else if (c is CheckBoxList)
                {
                    CheckBoxList checkBoxList = (CheckBoxList)c;
                    foreach (ListItem item in checkBoxList.Items)
                    {
                        item.Selected = false;
                    }
                }
                else if (c is RadioButtonList)
                {
                    RadioButtonList radioButtonList = (RadioButtonList)c;
                    radioButtonList.ClearSelection();
                }

                if (c.HasControls())
                {
                    LimpiarControles(c);
                }
            }
        }
        
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Add("idmedi", "0");
                Session.Add("idesp", "0");
                Session.Add("idturno", "0");
                Session.Add("class", "btn1");
                Session["error"] = null;
                Session["OK"] = null;
                Session["w"] = null;
                int id_horario=0;
                int id_especialidad=0;
            }
            
            
            //ession["idturno"]==null ? "0": id_horario.ToString();
            
            /*if(Session["usuario"]==null)
            {
                Response.Redirect("Default.aspx", false);
            }*/
            
                NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
                List<Especialidad> ListaEspecialidades=new List<Especialidad>();
                ListaEspecialidades= negocioEspecialidad.listar();
                
            
                ListBox checkBox = new ListBox();
                
                checkBox.SelectedIndexChanged += new EventHandler(SelectEspecialidad);
                checkBox.ID = "nery";
                checkBox.CssClass = "form-control";
                checkBox.AutoPostBack = true;
                foreach (Especialidad pivot in ListaEspecialidades)
                {
                    checkBox.Items.Add(new ListItem(pivot.nombre, pivot.id.ToString()));
                    
                }
                Muestra1.Controls.Add(checkBox);
                NegocioMedico negocioMedico = new NegocioMedico();
                List<Medico> ListaMedicos = new List<Medico>();
                ListaMedicos = negocioMedico.listar();
                
                ListBox medicos = new ListBox();
                medicos.SelectedIndexChanged += new EventHandler(SelectMedico);
                medicos.ID = "mediselect";
                medicos.CssClass = "form-control";
                medicos.AutoPostBack = true;
                foreach (Medico medi in ListaMedicos)
                {
                    if (medi.turno == Convert.ToInt32(Session["idturno"]) && medi.ID_ESPECIALIDAD == Convert.ToInt32(Session["idesp"]))
                    {
                        medicos.Items.Add(new ListItem(medi.nombres + " " + medi.apellidos, medi.ID_MEDICO.ToString()));
                        
                    }

                }
                Muestra2.Controls.Add(medicos);
                Console.WriteLine(Session["idturno"]+"- sadasdsad -" +Session["idesp"]);
                //Console.WriteLine(id_horario+"- sadasdsad -" +id_especialidad);

        }

        private void SelectMedico(object sender, EventArgs e)
        {

            Session["idmedi"] = Convert.ToInt32(((ListBox)sender).SelectedValue);
            

        }


        protected void SelectEspecialidad(object sender, EventArgs e)
        {
            try
            {
                Session["idesp"]= Convert.ToInt32(((ListBox)sender).SelectedValue);
                
            }
            catch (Exception exception)
            {
                Session["idesp"] = 0;
            }
        }

        protected void horarios_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idturno"]=Convert.ToInt32(((ListBox)sender).SelectedValue);

        }

        protected void button1_OnClick(object sender, EventArgs e)
        {
            Session["class"] = (((Button)sender).CommandArgument);
        }
    }
}