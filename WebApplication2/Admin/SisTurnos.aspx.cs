using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using WebGrease.Css.Ast.MediaQuery;

namespace WebApplication2.Admin
{
    public partial class SisTurnos : Page
    {
        protected Usuario usuario { get; set; }
        public bool pivot = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["usuario"]==null)
            {
                Session.Add("debe", "Debe Completar el formulario para operar en el sistema");
                Response.Redirect("Default.aspx", false);
            }

            try
            {
                usuario = (Usuario)Session["usuario"];
                if (!VerificaUsuario(usuario.ID_USUARIO))
                {
                    Session.Add("debe", "Debe Completar el formulario para operar en el sistema");
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    pivot = true;


                    if (!IsPostBack)
                    {
                        Session.Add("idmedi", "0");
                        Session.Add("VerRep", false);
                        Session.Add("idesp", "0");
                        Session.Add("idturno", "0");
                        Session.Add("horario", "0");
                        Session.Add("idrepro", "0");
                        Session.Add("idPaciente", "0");
                        Session.Add("class", "btn1");
                        Session["error"] = null;
                        Session["OK"] = null;
                        Session["w"] = null;
                        Session.Add("MostrarEsp", null);
                        Session.Add("MostrarMed", null);
                        Session.Add("MostrarFecha", null);
                        Session.Add("MostrarHora", null);
                    }

                    //turnos del paciente
                    NegocioPaciente negocioPaciente = new NegocioPaciente();
                    Paciente paciente = new Paciente();
                    NegocioTurno negocioTurnos = new NegocioTurno();
                    List<Turnos> repro = new List<Turnos>();

                    if (usuario.ID_TIPOUSUARIO < 3)
                    {
                        //usuario.ID_USUARIO
                        if (dni.Text != "")
                        {
                            paciente = negocioPaciente.BuscarXId(Convert.ToInt32(dni.Text));
                            if (paciente == null)
                            {
                                Session["error"] = "No se encontro el paciente";
                                nompac.Text = "error";
                                dnipac.Text = ":No se encontro el paciente🚨";
                                bt2.Enabled = false;
                            }
                            else
                            {
                                Session["idPaciente"] = paciente.ID_PACIENTE;
                                nompac.Text = paciente.nombreCompleto;
                                dnipac.Text = paciente.DNI;
                                repro = negocioTurnos.listar(paciente.ID_PACIENTE);
                                bt2.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        paciente = negocioPaciente.BuscarXIdUsuario(usuario.ID_USUARIO);
                        Session["idPaciente"] = paciente.ID_PACIENTE;
                        if (usuario.ID_TIPOUSUARIO < 3)
                        {
                            nompac.Text = paciente.nombreCompleto;
                            dnipac.Text = paciente.DNI;
                        }

                        repro = negocioTurnos.listar(paciente.ID_PACIENTE);
                    }

                    //Turnos loco= new Turnos();


                    if (repro != null)
                    {
                        ListBox boxrepro = new ListBox();
                        boxrepro.SelectedIndexChanged += SelectRepro;
                        boxrepro.ID = "reprolist";
                        boxrepro.CssClass = "form-control findClose";
                        boxrepro.AutoPostBack = true;
                        if (repro.Count > 0)
                        {
                            Dictionary<int, string> piv = Turnos.GetRepro();
                            foreach (var pivot in repro)
                            {
                                if (pivot.fecha.Date > DateTime.Now.Date)
                                {
                                    KeyValuePair<int, string> mostrar =
                                        piv.First(x => x.Key == Convert.ToInt32(pivot.Id_Hora));
                                    if (pivot.Estado)
                                        boxrepro.Items.Add(new ListItem(
                                            "Fecha :" + pivot.fecha.Date.ToShortDateString() + " Hora:" + mostrar.Value,
                                            pivot.Id_Turno.ToString()));
                                }
                            }

                            reprogramoturno.Controls.Add(boxrepro);
                        }


                        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
                        List<Especialidad> ListaEspecialidades = new List<Especialidad>();
                        ListaEspecialidades = negocioEspecialidad.listar();
                        
                        ListBox checkBox = new ListBox();
                        checkBox.SelectedIndexChanged += SelectEspecialidad;
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
                        if (Session["idesp"].ToString() != "0")
                        {
                            Session["MostrarEsp"] =
                                ListaEspecialidades.Find(x => x.id == Convert.ToInt32(Session["idesp"])).nombre;
                            Medico medico = new Medico();

                            NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                            List<EspecialidadxMedico> ListaEspecialidadxMedico = new List<EspecialidadxMedico>();
                            ListaEspecialidadxMedico = negocioEspecialidadxMedico.listar(Session["idesp"].ToString());

                            ListBox medicos = new ListBox();
                            medicos.SelectedIndexChanged += SelectMedico;
                            medicos.ID = "mediselect";
                            medicos.CssClass = "form-control";
                            medicos.AutoPostBack = true;
                            foreach (EspecialidadxMedico medi in ListaEspecialidadxMedico)
                            {
                                medico = ListaMedicos.Find(x => x.ID_MEDICO == medi.ID_MEDICO);
                                if (medi.Turno_Horario == Convert.ToInt32(Session["idturno"]) &&
                                    medi.Id_Especialidad == Convert.ToInt32(Session["idesp"]))
                                {
                                    Session["horario"] = medi.Turno_Horario;
                                    medicos.Items.Add(new ListItem(medico.nombres + " " + medico.apellidos,
                                        medi.ID_MEDICO.ToString()));
                                }
                            }

                            Muestra2.Controls.Add(medicos);
                        }

                        Medico dato = new Medico();
                        Turnos tux = new Turnos();
                        NegocioTurno negocioTurno = new NegocioTurno();
                        List<Turnos> ListaTurnos = new List<Turnos>();
                        ListaTurnos = negocioTurno.listar();
                        ListBox turnero = new ListBox();
                        turnero.SelectedIndexChanged += turnnero_OnSelectedIndexChanged;
                        turnero.ID = "turnero";
                        turnero.CssClass = "form-control";
                        turnero.AutoPostBack = true;
                        //busca medico
                        Console.WriteLine(Session["idmedi"]+"asdddddddddd");
                        foreach (var medi in ListaMedicos)
                        {
                            Console.WriteLine(medi.ID_MEDICO+" --- "+medi.NombreCompleto);
                        }
                        dato = ListaMedicos.Find(x => x.ID_MEDICO == Convert.ToInt32(Session["idmedi"]));
        
                        //Busca turno ocupados
                        //tux = ListaTurnos.Find(x => x.Id_Medico == Convert.ToInt32(Session["idmedi"]));

                        if (dato != null )
                        {
                            Session["MostrarMed"] = dato.nombres + ", " + dato.apellidos;
                            Console.WriteLine("Medico: " + dato.nombres + ", " + dato.apellidos);

                            var tata = Turnos.GetTurnos(Convert.ToInt32(Session["horario"]));
                            foreach (KeyValuePair<int, string> slot in tata)
                            {
                                //Muestra los horarios disponibles
                                tux = ListaTurnos.Find(x =>
                                    x.Id_Medico == dato.ID_MEDICO && x.Id_Hora == slot.Key &&
                                    Convert.ToDateTime(x.fecha) == Convert.ToDateTime(fechanow.Text) && x.Estado);
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
                                var tito = Turnos.GetTurnos(Convert.ToInt32(Session["horario"]));
                                foreach (KeyValuePair<int, string> slot in tito)
                                {
                                    turnero.Items.Add(new ListItem(slot.Value, slot.Key.ToString()));
                                }
                            }
                        }

                        Fecha.Controls.Add(turnero);

                        if (Session["MostrarEsp"] != null && Session["MostrarMed"] != null)
                        {
                            thisEspe.Text = Session["MostrarEsp"].ToString();
                            thisMedico.Text = Session["MostrarMed"].ToString();
                            if (usuario.ID_TIPOUSUARIO < 3)
                            {
                                thisPaciente.Text = nompac.Text;
                                thisPacienteDni.Text = dnipac.Text;
                            }
                            else
                            {
                                thisPaciente.Text = paciente.nombreCompleto;
                                thisPacienteDni.Text = paciente.DNI;
                            }

                            thisFecha.Text = fechanow.Text ?? DateTime.Now.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            thisEspe.Text = "Especialidad";
                            thisMedico.Text = "Medico";
                            thisTurno.Text = "Turno";
                            thisFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                }
            }catch(Exception ex)
            {
                Response.Redirect("Default.aspx", false);
            }


        }
        private bool VerificaUsuario(int o)
        {
            
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            List<Paciente> ListaPacientes = new List<Paciente>();
            ListaPacientes = negocioPaciente.listar();
            Paciente paciente = ListaPacientes.Find(x => x.ID_USUARIO == o);
            return paciente==null?false:true;
        }

        private void SelectRepro(object sender, EventArgs e)
        {
            try
            {
                Session["idrepro"] = Convert.ToInt32(((ListBox)sender).SelectedValue);
                bt2.Enabled = true;
                
                NegocioEspecialidadxMedico negocioEspecialidadxMedico = new NegocioEspecialidadxMedico();
                List<EspecialidadxMedico> ListaEspecialidadxMedico = new List<EspecialidadxMedico>();

                Turnos turnorep = new Turnos();
                NegocioTurno negocioTurnos = new NegocioTurno();

                turnorep = negocioTurnos.turnRepro(Convert.ToInt32(Session["idrepro"]));

                ListaEspecialidadxMedico = negocioEspecialidadxMedico.listar();
                // if (turnorep != null)
                // {
                //     Dictionary<int, string> piv = Turnos.GetRepro();
                //
                //     KeyValuePair<int, string> mostrar = piv.First(x => x.Key == Convert.ToInt32(turnorep.Id_Hora));
                // }

                ListBox fafa = (ListBox)Muestra1.FindControl("nery");

                int loco = fafa.Items.IndexOf(fafa.Items.FindByValue(turnorep.Id_Especialidad.ToString()));
                fafa.SelectedIndex = loco;
                fafa.Enabled = false;

                fechanow.Text = turnorep.fecha.Date.ToShortDateString();
                int turnmedi = ListaEspecialidadxMedico.Find(x =>
                    x.Id_Especialidad == turnorep.Id_Especialidad && x.ID_MEDICO == turnorep.Id_Medico).Turno_Horario;
                horarios.SelectedIndex = turnmedi;

                Session["idturno"] = turnmedi;
                Session["idesp"] = turnorep.Id_Especialidad;
            }
            catch (Exception exception)
            {
                Session["idrepro"] = "0";
                Console.WriteLine(exception);
            }
        }

        private void turnnero_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = ((ListBox)sender).SelectedValue;
                if (selectedValue != null)
                    Session["idturnero"] = Convert.ToInt32(selectedValue);
                if (Session["idturnero"] == "0")
                    btn4.Enabled = false;
                else
                {
                    btn4.Enabled = true;
                    bt3.Enabled = false;
                    thisCode.Text = Turnos.generateRandom().ToString();
                }

                Dictionary<int, string> piv = Turnos.GetTurnos(Convert.ToInt32(Session["idturno"]));
                thisTurno.Text = piv[Convert.ToInt32(Session["idturnero"])];
            }
            catch (Exception exception)
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
                    bt3.Enabled = true;
                    // bt2.Enabled = false;
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
                Session["idesp"] = Convert.ToInt32(((ListBox)sender).SelectedValue);
                if (Session["idesp"] == "0")
                    bt2.Enabled = false;
                else
                    bt2.Enabled = true;
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
                Console.WriteLine(Session["idturno"]+"asdasdasd");
                if (Session["idturno"] == "0")
                    bt2.Enabled = false;
                else
                    bt2.Enabled = true;
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
            NegocioTurno negocioTurnos = new NegocioTurno();

            int index = 0;
            
            if (Session["idrepro"] != "0")
            {
                index = 4;
                negocioTurnos.UpdateTurno(Convert.ToInt32(Session["idrepro"]),index);//reprogramado
            }

            Turnos turnos = new Turnos();
            
            turnos.Id_Especialidad = Convert.ToInt32(Session["idesp"]);
            turnos.Id_Medico = Convert.ToInt32(Session["idmedi"]);
            turnos.Id_Hora = Convert.ToInt32(Session["idturnero"]);
            turnos.fecha = Convert.ToDateTime(fechanow.Text);
            turnos.observacion = Observaciones.Text;
            turnos.Id_Paciente = Convert.ToInt32(Session["idPaciente"]);
            turnos.Estado = true;
            turnos.EstadoInf = index;//Nuevo
            turnos.NumGenerado =Convert.ToInt32(thisCode.Text);
            negocioTurnos.RegistrarTurno(turnos);
            Session["OK"] = "Proceso Exitoso";

            EmailService emailService = new EmailService();
            StreamReader str = new StreamReader(Server.MapPath(@"~/assets/template/Truno.html"));
            string temlate = str.ReadToEnd();
            
            str.Close();
            temlate = temlate.Replace("[dni]", thisPacienteDni.Text.Trim());
            temlate = temlate.Replace("[pivot]", Turnos.EstadoInfArray[index].ToString());
            temlate = temlate.Replace("[nombre]", this.thisPaciente.Text.Trim());
            temlate = temlate.Replace("[especialidad]", this.thisEspe.Text.Trim());
            temlate = temlate.Replace("[medico]", this.thisMedico.Text.Trim());
            temlate = temlate.Replace("[fecha]", this.thisFecha.Text.Trim());
            temlate = temlate.Replace("[turno]", this.thisTurno.Text.Trim());
            temlate = temlate.Replace("[observacion]", this.Observaciones.Text.Trim());
            temlate = temlate.Replace("[code]", this.thisCode.Text.Trim());

            if (usuario.ID_TIPOUSUARIO == 4)
            {
                emailService.preparaCorreo(usuario.CORREO, Turnos.EstadoInfArray[index] + " - Turnero Dr. Seba",
                    temlate);
            }
            else
            {
                emailService.preparaCorreo(returnUsuarioXIdPaciente(turnos.Id_Paciente).CORREO, Turnos.EstadoInfArray[index] + " - Turnero Dr. Seba",
                    temlate);
            }

            emailService.enviarEmail();
            Response.Redirect("SisTurnos.aspx", false);
        }

        protected Usuario returnUsuarioXIdTurno(int idPaciente)
        {
            NegocioTurno negocioTurno = new NegocioTurno();
            Turnos turnos = negocioTurno.turnRepro(idPaciente);
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            Paciente paciente = negocioPaciente.BuscarXId(turnos.Id_Paciente);
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            Usuario usuario = negocioUsuario.BuscarXId(paciente.ID_USUARIO);
            return usuario;
        }
        protected Usuario returnUsuarioXIdPaciente(int idPaciente)
        {
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            Paciente paciente = negocioPaciente.BuscarXIdPaciente(idPaciente);
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            Usuario usuario = negocioUsuario.BuscarXId(paciente.ID_USUARIO);
            return usuario;
        }

        protected void buscaPaciente_OnClick(object sender, EventArgs e)
        {
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            Session["VerRep"] = chkVer.Checked;
            if (Convert.ToBoolean(Session["VerRep"]))
            {
                ListBox fafa = (ListBox)Muestra1.FindControl("nery");
                fafa.Enabled = false;
                sube.Text = "Reprogramar";
            }
            else
            {
                ListBox fafa = (ListBox)Muestra1.FindControl("nery");
                fafa.Enabled = true;
                sube.Text = "Confirmar";
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            if(Session["idrepro"]!="0"){
                butonEl.Text = "";
                NegocioTurno negocioTurnos = new NegocioTurno();
                Turnos tux= negocioTurnos.turnRepro(Convert.ToInt32(Session["idrepro"]));
                
                NegocioPaciente negocioPaciente = new NegocioPaciente();
                Paciente paciente = negocioPaciente.BuscarXIdPaciente(Convert.ToInt32(tux.Id_Paciente));
                
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                Usuario usuarioRec = negocioUsuario.BuscarXId(Convert.ToInt32(paciente.ID_USUARIO));
                
                NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
                List<Especialidad> especialidad = negocioEspecialidad.listar();
                
                NegocioMedico negocioMedico = new NegocioMedico();
                Medico medico = negocioMedico.buscaXId(Convert.ToInt32(tux.Id_Medico));
                
                negocioTurnos.UpdateTurno(Convert.ToInt32(tux.Id_Turno), 2);
                //****Email
                EmailService emailService = new EmailService();
                StreamReader str = new StreamReader(Server.MapPath(@"~/assets/template/TrunoCancel.html"));
                string temlate = str.ReadToEnd();
            
                str.Close();
                temlate = temlate.Replace("[dni]", paciente.DNI);
                temlate = temlate.Replace("[nombre]", paciente.nombreCompleto);
                temlate = temlate.Replace("[especialidad]", especialidad.Find(x => x.id == Convert.ToInt32(tux.Id_Paciente)).nombre);
                temlate = temlate.Replace("[medico]", medico.NombreCompleto);
                temlate = temlate.Replace("[fecha]", tux.fecha.Date.ToShortDateString());
                temlate = temlate.Replace("[cancel]", "Cancelado");
                //temlate = temlate.Replace("[observacion]", this.Observaciones.Text.Trim());
                //temlate = temlate.Replace("[code]", this.thisCode.Text.Trim());
            
                emailService.preparaCorreo(usuarioRec.CORREO, Turnos.EstadoInfArray[2]+" - Turnero Dr. Seba", temlate);
                
                
                emailService.enviarEmail();
                
            }
            else
            {
                butonEl.Text = "Error: Verifique el turno seleccionado";
            }
            
        }
    }
}