﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
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
                Session.Add("MostrarEsp",null);
                Session.Add("MostrarMed", null);
                Session.Add("MostrarFecha", null);
                Session.Add("MostrarHora", null);
                
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
                if(Session["idesp"].ToString()!="0"){
                    Session["MostrarEsp"]= ListaEspecialidades.Find(x => x.id== Convert.ToInt32(Session["idesp"])).nombre;
                    Medico medico = new Medico();
                    
                    NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                    List<EspecialidadxMedico> ListaEspecialidadxMedico = new List<EspecialidadxMedico>();
                    ListaEspecialidadxMedico = negocioEspecialidadxMedico.listar(Session["idesp"].ToString());
                    
                ListBox medicos = new ListBox();
                medicos.SelectedIndexChanged += new EventHandler(SelectMedico);
                medicos.ID = "mediselect";
                medicos.CssClass = "form-control";
                medicos.AutoPostBack = true;
                    foreach (EspecialidadxMedico medi in ListaEspecialidadxMedico)
                    {
                        medico= ListaMedicos.Find(x => x.ID_MEDICO == medi.ID_MEDICO);
                        if(medico.turno == Convert.ToInt32(Session["idturno"]) && medi.Id_Especialidad == Convert.ToInt32(Session["idesp"]))
                        {
                            medicos.Items.Add(new ListItem(medico.nombres + " " + medico.apellidos, medi.ID_MEDICO.ToString()));
                            
                        }

                    }
                Muestra2.Controls.Add(medicos);
                }
                
                Medico dato = new Medico();
                Turnos tux = new Turnos();
                NegocioTurno negocioTurno = new NegocioTurno();
                List<Turnos> ListaTurnos = new List<Turnos>();
                ListaTurnos = negocioTurno.listar();
                ListBox turnero= new ListBox();
                turnero.SelectedIndexChanged += new EventHandler(turnnero_OnSelectedIndexChanged);
                turnero.ID = "turnero";
                turnero.CssClass = "form-control";
                turnero.AutoPostBack = true;
                //busca medico
                
                dato=ListaMedicos.Find(x => x.ID_MEDICO == Convert.ToInt32(Session["idmedi"]));
               
                //Busca turno ocupados
                tux = ListaTurnos.Find(x => x.Id_Medico == Convert.ToInt32(Session["idmedi"]));
                
                if (dato != null && tux != null)
                {Console.WriteLine("tux: " + tux.Id_Hora + " --dfdsf--- " + dato.nombres);
                    Session["MostrarMed"] = dato.nombres + ", " + dato.apellidos;

                    var tata = Turnos.GetTurnos(Convert.ToInt32(dato.turno));
                    foreach (KeyValuePair<int, string> slot in tata)
                    {
                        
                        //Muestra los horarios disponibles
                        tux = ListaTurnos.Find(x => x.Id_Medico == dato.ID_MEDICO && x.Id_Hora == slot.Key && Convert.ToDateTime(x.fecha) == Convert.ToDateTime(fechanow.Text))??null;
                        if (tux == null)
                        {
                            turnero.Items.Add(new ListItem(slot.Value, slot.Key.ToString()));
                        }



                    }
                }
                else
                {
                    if (dato != null)
                    {
                        var tito = Turnos.GetTurnos(Convert.ToInt32(dato.turno));
                        foreach (KeyValuePair<int, string> slot in tito)
                        {
                            turnero.Items.Add(new ListItem(slot.Value, slot.Key.ToString()));
                        }
                    }
                }

                Fecha.Controls.Add(turnero);
                if(Session["MostrarEsp"]!=null&& Session["MostrarMed"]!=null)
                {
                    thisEspe.Text = Session["MostrarEsp"].ToString();
                    thisMedico.Text = Session["MostrarMed"].ToString();
                   
                    thisFecha.Text = fechanow.Text??DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    thisEspe.Text = "Especialidad";
                    thisMedico.Text = "Medico";
                    thisTurno.Text = "Turno";
                    thisFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                

        }
        
        private void turnnero_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["idturnero"] = Convert.ToInt32(((ListBox)sender).SelectedValue);
                if (Session["idturnero"] == "0")
                    btn4.Enabled = false;
                else
                {
                    btn4.Enabled= true;
                    bt3.Enabled = false;
                }
                Dictionary<int, string> piv = Turnos.GetTurnos(Convert.ToInt32(Session["idturno"]));
                thisTurno.Text = piv[Convert.ToInt32(Session["idturnero"])];
            }catch (Exception exception)
            {
                Session["idturnero"] = "0";
                Console.WriteLine(exception);
            }

        }
        private void SelectMedico(object sender, EventArgs e)
        {
            try
            {
                Session["idmedi"] = Convert.ToInt32(((ListBox)sender).SelectedValue);
                Console.WriteLine(Session["idmedi"] + "seeeeee");
                if (Session["idmedi"] == "0")
                    bt3.Enabled = false;
                else
                {
                    bt3.Enabled= true;
                    bt2.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                Session["idmedi"] = "0";
                Console.WriteLine(exception);
            }

        }


        protected void SelectEspecialidad(object sender, EventArgs e)
        {
            try
            {
                Session["idesp"]= Convert.ToInt32(((ListBox)sender).SelectedValue);
                if (Session["idesp"] == "0")
                    bt2.Enabled = false;
                else
                    bt2.Enabled= true;
            }
            catch (Exception exception)
            {
                Session["idesp"] = "0";
                Console.WriteLine(exception);
            }
        }

        protected void horarios_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["idturno"] = Convert.ToInt32(((ListBox)sender).SelectedValue);
                if (Session["idturno"] == "0")
                    bt2.Enabled = false;
                else
                    bt2.Enabled= true;
                
                
            }
            catch (Exception exception)
            {
                Session["idturn"] = "0";
                Console.WriteLine(exception);
            }
        }

        protected void button1_OnClick(object sender, EventArgs e)
        {
            Session["class"] = (((Button)sender).CommandArgument);
            
            
        }

        protected void sube_Click(object sender, EventArgs e)
        {
            Turnos turnos = new Turnos();
            NegocioTurno negocioTurno = new NegocioTurno();
            turnos.Id_Especialidad= Convert.ToInt32(Session["idesp"]);
            turnos.Id_Medico = Convert.ToInt32(Session["idmedi"]);
            turnos.Id_Hora = Convert.ToInt32(Session["idturnero"]);
            turnos.fecha = Convert.ToDateTime(fechanow.Text);
            turnos.observacion= Observaciones.Text;
            turnos.Id_Paciente = 1;
            turnos.Estado = true;
            negocioTurno.RegistrarTurno(turnos);
            Session["OK"] = "Exito al registrar turno";
            Response.Redirect("Default.aspx", false);

        }
    }
}