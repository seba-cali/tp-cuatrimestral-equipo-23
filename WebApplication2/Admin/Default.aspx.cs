﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using Dominio;
using Negocio;

namespace WebApplication2.Admin
{
    public partial class Default : Page
    {
        protected Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            usuario= (Usuario)Session["usuario"];
            


        }
        private bool VerificaUsuario(int o)
        {
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            ListaPacientes = negocioPaciente.listar();
            Paciente paciente = ListaPacientes.Find(x => x.ID_USUARIO == o);
            return paciente==null?false:true;
        }

        public List<Paciente> ListaPacientes { get; set; }

        protected void btn_Login(object sender, EventArgs e)
        {
            
            
            
            try
            {
                Usuario usuuario= new Usuario();
                NegocioUsuario negocioUsuario = new NegocioUsuario();    
                usuuario.username= DNIUSER.Text;
                usuuario.PASSWORD = usuuario.encriptar(PASSWORDUSER.Text);
                
                if(usuuario.username.Length<=4|| usuuario.PASSWORD.Length<=8)
                {
                    Session.Add("error", "Complete los campos");
                    Response.Redirect("Default.aspx", false);
                }
                else if (negocioUsuario.login(usuuario) != null)
                {
                    if(!usuuario.ESTADO)
                    {
                        Session.Add("error", "Usuario bloqueado");
                        Response.Redirect("Default.aspx", false);
                    }else{
                    Session.Remove("error");
                    Session.Add("usuario", usuuario);
                    Response.Redirect("~/Admin/Tablero.aspx", false);
                    }
                }
                else
                {
                    
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Default.aspx", false);
                }
                
                

            }
            catch (Exception exception)
            {
                Session.Add("error", "no ingreso datos solicitados");
                Response.Redirect("Default.aspx", true);
                Console.WriteLine(exception);
            }

        }
       
    }
}