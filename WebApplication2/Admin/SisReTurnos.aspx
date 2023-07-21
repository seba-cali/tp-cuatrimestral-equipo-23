<%@ Page Title="Title" Language="C#" MasterPageFile="~/Admin/Panel.master" CodeBehind="SisReTurnos.aspx.cs" Inherits="WebApplication2.Admin.SisReTurnos" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" xmlns:aps="http://www.w3.org/1999/html">
<% if (usuario != null)
   {
       var loco = 3;
%>
    <div id="layoutSidenav_content">
    <main>
    <header class="page-header page-header-dark bg-gradient-primary-to-secondary pb-10">
        <div class="container-xl px-4">
            <div class="page-header-content pt-4">
                <div class="row align-items-center justify-content-between">
                    <div class="col-auto mt-4">
                        <h1 class="page-header-title">
                            <div class="page-header-icon">
                                <i data-feather="arrow-right-circle"></i>
                            </div>
                            Reprogramar o Cancelar Turno
                        </h1>

                    </div>
                </div>
            </div>
        </div>
    </header>
    <!-- Main page content-->
    <div class="container-xl px-4 mt-n10">
    <!-- Wizard card example with navigation-->
    <div class="card">
    <div class="card-header border-bottom">
        <!-- Wizard navigation-->
        <div class="nav nav-pills nav-justified flex-column flex-xl-row nav-wizard pe-none" id="cardTab" role="tablist">
            <!-- Wizard navigation item 1-->
            <div class="nav-item nav-link <%: Session["class"] == "btn1" ? "active" : " " %>" id="wizard1-tab" data-bs-toggle="tab" role="tab" aria-controls="wizard1" aria-selected="true">
                <div class="wizard-step-icon">1</div>
                <div class="wizard-step-text">
                    <div class="wizard-step-text-name">Especialidad</div>
                    <div class="wizard-step-text-details">Primer Paso</div>
                </div>
            </div>
            <!-- Wizard navigation item 2-->
            <div class="nav-item nav-link <%: Session["class"] == "btn2" ? "active" : " " %>" id="wizard2-tab" data-bs-toggle="tab" role="tab" aria-controls="wizard2" aria-selected="true">
                <div class="wizard-step-icon">2</div>
                <div class="wizard-step-text">
                    <div class="wizard-step-text-name">Medicos</div>
                    <div class="wizard-step-text-details">Segundo Paso</div>
                </div>
            </div>
            <!-- Wizard navigation item 3-->
            <div class="nav-item nav-link <%: Session["class"] == "btn3" ? "active" : " " %>" id="wizard3-tab" data-bs-toggle="tab" role="tab" aria-controls="wizard3" aria-selected="true">
                <div class="wizard-step-icon">3</div>
                <div class="wizard-step-text">
                    <div class="wizard-step-text-name">Fecha</div>
                    <div class="wizard-step-text-details">Tercer Paso</div>
                </div>
            </div>
            <!-- Wizard navigation item 4-->
            <div class="nav-item nav-link <%: Session["class"] == "btn4" ? "active" : " " %>" id="wizard4-tab" data-bs-toggle="tab" role="tab" aria-controls="wizard4" aria-selected="true">
                <div class="wizard-step-icon">4</div>
                <div class="wizard-step-text">
                    <div class="wizard-step-text-name">Confirmar</div>
                    <div class="wizard-step-text-details">Ultimo Paso</div>
                </div>
            </div>
        </div>
    </div>
    <div class="card-body">
    <div class="tab-content" id="cardTabContent">
    <!-- Wizard tab pane item 1-->

    <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"] == "btn1" ? " show active" : " " %>" id="wizard1" role="tabpanel" aria-labelledby="wizard1-tab">
        <div class="row justify-content-center">
            <div class="col-xxl-8 col-xl-8">

                <h3 class="text-primary">Seccion 1</h3>

                <% if (usuario.ID_TIPOUSUARIO < 3)
                   { %>
                    <div class="mb-3 VistSec">
                        <hr class="my-4"/>
                        <h3>Por favor Ingresar DNI:</h3>


                        <asp:TextBox ID="dni" runat="server" type="number" AutoPostBack="True"/>

                        <asp:Button ID="buscaPaciente" OnClick="buscaPacientes_OnClick" Text="Buscar" runat="server"/>
                        <hr class="my-4"/>
                        <asp:Label ID="nompac" runat="server"/>
                        <asp:Label ID="dnipac" runat="server"/>
                        <hr class="my-4"/>
                    </div>
                <% } %>
                <hr class="my-4"/>
                <div class="col-12 mb-3 <%: nompac.Text == "error" ? "pe-none" : "" %> ">
                    <div class="col-12 gx-3 ">
                        <h3>Usted posee los siguientes turnos activos</h3>

                    </div>
                    <hr class="my-4"/>
                    <div class="col-12">
                        <div class="container-fluid px-4">
                            <div class="card">
                                <div class="card-body">
                                    <table id="datatablesSimple">
                                        <thead>
                                        <tr>
                                            <th>id</th>
                                            <th>Dia del Turno</th>
                                            <th>Horario</th>
                                            <th>Especialidad</th>
                                            <th>Acciones</th>
                                        </tr>
                                        </thead>
                                        <tfoot>
                                        <tr>
                                            <th>id</th>
                                            <th>Dia del Turno</th>
                                            <th>Horario</th>
                                            <th>Especialidad</th>
                                            <th>Acciones</th>
                                        </tr>
                                        </tfoot>
                                        <tbody>
                                        <%
                                            if(repro!=null)
                                            foreach (Turnos tux in repro)
                                            {
                                                    
                                                Especialidad esp;
                                                    esp = ListaEspecialidades.Find(x => x.id == tux.Id_Especialidad);
                                                    if (esp != null && tux.Estado && tux.fecha > DateTime.Now )
                                                    {
                                        %>
                                                    <tr>
                                                        <td class="esp<%= tux.Id_Turno %>"><%: tux.Id_Turno %></td>
                                                        <td><%: tux.fecha.Date.ToShortDateString() %></td>
                                                        <td>
                                                            <%: Turnos.GetRepro()[tux.Id_Hora] %>

                                                        </td>
                                                        
                                                        <td><%= esp.nombre %></td>
                                                        

                                                        <td>
                                                            <a id="<%= tux.Id_Turno %>" class="btn  btn-primary editar me-2" type="button" data-bs-toggle="modal" data-bs-target="#editGroupModal">
                                                                <i data-feather="edit"></i> Reprogramar
                                                            </a>
                                                            <a id="<%= tux.Id_Turno %>" class="btn btn-danger delete me-2" type="button" data-bs-toggle="modal" data-bs-target="#eliminaGroupModal">
                                                                <i data-feather="trash"></i> Cancelar
                                                            </a>

                                                        </td>
                                                    </tr>

                                        <% }
                                            }
                                        %>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <hr class="my-4"/>
                <%--<div class="mb-3 <%: nompac.Text == "error" ? "pe-none" : "" %>">
                    <asp:PlaceHolder ID="Muestra1" runat="server"/>

                </div>--%>

                <%--<div class="mb-3 <%: nompac.Text == "error" ? "pe-none" : "" %>">

                    <asp:ListBox CssClass="form-control" OnSelectedIndexChanged="horarios_OnSelectedIndexChanged" ID="horarios" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="Turnos 6 a 11Hs" Value="0"/>
                        <asp:ListItem Text="Turnos 12 a 17Hs" Value="1"/>
                        <asp:ListItem Text="Turnos 18 a 21Hs" Value="2"/>
                    </asp:ListBox>

                </div>--%>

                
                <div class="d-flex justify-content-between">
                    
                </div>

            </div>
        </div>
    </div>


    <!-- Wizard tab pane item 2-->

    <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"] == "btn2" ? " show active" : " " %>" id="wizard2" role="tabpanel" aria-labelledby="wizard2-tab">
        <div class="row justify-content-center">
            <div class="col-xxl-6 col-xl-8">
                <h3 class="text-primary">Paso 2</h3>
                <h5 class="card-title mb-4">Seleccione Medico</h5>

                <div class="row gx-3">
                    <div class="mb-3 col-md-6">


                        <asp:PlaceHolder ID="Muestra2" runat="server"/>


                    </div>
                </div>
                <div class="row gx-3">
                    <div class="mb-3 col-md-6">

                        <asp:TextBox ID="fechanow" AutoPostBack="True" CssClass="form-control ps-0 pointer fecha" autocomplete="off" runat="server" type="text"/>

                    </div>
                </div>
                <hr class="my-4"/>
                <div class="d-flex justify-content-between">

                    <asp:Button ID="ant1" CssClass="btn btn-light" Text="anterior" CommandArgument="btn1" OnClick="button1_OnClick" runat="server"/>
                    <asp:Button CssClass="btn btn-primary " Text="Siguiente" ID="bt3" CommandArgument="btn3" type="button" Enabled="False" OnClick="button1_OnClick" runat="server"/>

                </div>

            </div>
        </div>
    </div>

    <!-- Wizard tab pane item 3-->
    <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"] == "btn3" ? " show active" : " " %>" id="wizard3" role="tabpanel" aria-labelledby="wizard3-tab">
        <div class="row justify-content-center">
            <div class="col-xxl-6 col-xl-8">
                <h3 class="text-primary">Paso 3</h3>
                <h5 class="card-title mb-4">Seleccione Fecha</h5>

                <div class="form-check mb-2">

                    <asp:PlaceHolder ID="Fecha" runat="server"/>

                </div>


                <hr class="my-4"/>
                <div class="d-flex justify-content-between">
                    <asp:Button CssClass="btn btn-light" ID="ant2" CommandArgument="btn2" OnClick="button1_OnClick" Text="anterior" runat="server"/>
                    <asp:Button CssClass="btn btn-primary" ID="btn4" CommandArgument="btn4" OnClick="button1_OnClick" Enabled="False" Text="siguiente" runat="server"/>
                </div>

            </div>
        </div>
    </div>

    <!-- Wizard tab pane item 4-->
    <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"] == "btn4" ? " show active" : " " %>" id="wizard4" role="tabpanel" aria-labelledby="wizard4-tab">
        <div class="row justify-content-center">
            <div class="col-xxl-6 col-xl-8">
                <h3 class="text-primary">Paso 4</h3>
                <h5 class="card-title mb-4">Confirmar Turno</h5>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Paciente:</em>
                    </div>
                    <div class="col">
                        <asp:Label ID="thisPaciente" Text="000000" runat="server" Enabled="True"/>
                        <asp:Label ID="thisPacienteDni" Text="000000" runat="server" Enabled="True"/>


                    </div>
                </div>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Codigo de Verificacion:</em>
                    </div>
                    <div class="col">
                        <asp:Label ID="thisCode" Text="000000" runat="server" Enabled="True"/>


                    </div>
                </div>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Especialidad:</em>
                    </div>
                    <div class="col">
                        <asp:Label ID="thisEspe" Text="000000" runat="server" Enabled="True"/>


                    </div>
                </div>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Medico:</em>
                    </div>
                    <div class="col">
                        <asp:Label ID="thisMedico" Text="000000" runat="server" Enabled="True"/>


                    </div>
                </div>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Fecha:</em>
                    </div>
                    <div class="col">
                        <asp:Label ID="thisFecha" Text="000000" runat="server" Enabled="True"/>
                    </div>
                </div>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Hora:</em>
                    </div>
                    <div class="col">
                        <asp:Label ID="thisTurno" Text="000000" runat="server" Enabled="True"/>
                    </div>
                </div>
                <div class="row small text-muted">
                    <div class="col-sm-3 text-truncate">
                        <em>Observaciones:</em>
                    </div>
                    <asp:TextBox ID="Observaciones" CssClass="form-control ps-0 pointer" runat="server" type="text"/>
                </div>

                <hr class="my-4"/>
                <div class="d-flex justify-content-between">
                    <asp:Button CssClass="btn btn-light" Text="anterior" ID="ant3" CommandArgument="btn3" OnClick="button1_OnClick" runat="server"/>
                    <asp:Button CssClass="btn btn-primary" Text="Reprogramar" CommandArgument="op1" Onclick="sube_Click" ID="sube" runat="server"/>
                </div>
            </div>
        </div>
    </div>


    </div>
    </div>
    </div>
    </div>
    </main>
    <!-- Edit group modal-->
        
        <div class="modal fade" id="editGroupModal" tabindex="-1" role="dialog" aria-labelledby="editGroupModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editGroupModalLabel">Edit Group</h5>
                        <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    
                    <div class="modal-body">
                        
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupName">Id</label>
                            <h3 class="elementoedit"></h3>
                            <asp:TextBox class="form-control formGroupId" id="formGroupId" type="text"   runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupName">Fecha</label>
                            <asp:TextBox class="form-control formGroupNameEdit" id="formGroupNameEdit" type="text" placeholder="nombre..." runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupDesc">Horarios</label>
                            <asp:TextBox class="form-control formGroupDescEdit" id="formGroupDescEdit" type="text" placeholder="descripcion..." runat="server"/>
                        </div>
                        <div class="mb-0">
                               <asp:UpdatePanel runat="server">
                                   <ContentTemplate>
                                       <asp:ListBox CssClass="form-control" OnSelectedIndexChanged="horarios_OnSelectedIndexChanged" ID="horarios" runat="server" AutoPostBack="true">
                                                                                           <asp:ListItem Text="Turnos 6 a 11Hs" Value="0"/>
                                                                                           <asp:ListItem Text="Turnos 12 a 17Hs" Value="1"/>
                                                                                           <asp:ListItem Text="Turnos 18 a 21Hs" Value="2"/>
                                                                                       </asp:ListBox>
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="bt2" runat="server" Text="Reprogramar" CommandArgument="btn2" CausesValidation="False" OnClientClick="return ;" OnClick="button1_OnClick" CssClass="btn btn-primary-soft text-primary" />
                    </div>
                    
                </div>
            </div>
        </div>
        <div class="modal fade" id="eliminaGroupModal" tabindex="-1" role="dialog" aria-labelledby="eliminaGroupModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="eliminaGroupModal">Edit Group</h5>
                        <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                        
                    <div class="modal-body">
                        <h1>Eliminar el elemento?</h1>
                        <h1 class="elemento"></h1>
                            <asp:TextBox class="form-control formGroupIdDelete" id="formGroupIdDelete" type="text" hidden  runat="server"/>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button3" runat="server"  Text="Eliminar Especialidad" CssClass="btn btn-primary-soft text-primary" CausesValidation="False" OnClick="cancelar_Click" />
                    </div>

                </div>
            </div>
            
        </div>
    </div>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
    <script>
        $(function () {
            
                $('#MainContent_sube').on("click",function(e) { 
                                     var self = $(this);
                                                                   e.preventDefault();  
                                   Swal.fire({
                                                       title: '¿Estas seguro?',
                                                       text: "No podras revertir esta accion!",
                                                       icon: 'warning',
                                                       showCancelButton: true,
                                                       confirmButtonColor: '#3085d6',
                                                       cancelButtonColor: '#d33',
                                                       confirmButtonText: 'Confirmar'
                                                   }).then((result) => {
                                                       if (result.isConfirmed) {
                                                           Swal.fire(
                                                               'Confirmado!',
                                                               'Tu turno fue reservado.',
                                                               'success'
                                                           )
                                                           self.off("click").click();
                                                       }
                                                   })
                                });
            $('.editar').on('click',function() {
                                 
                           
                                    var index=$(this).attr('id');             
                                    var indextab=$(this).closest('tr').attr('data-index');
                                    indextab++
                                    $('.elementoedit').text(indextab);
                                    $('.formGroupId').attr('value', index);
                                    $('.formGroupNameEdit').attr('value',$("#datatablesSimple tbody tr:nth-child( "+ indextab +" ) td:nth-child(2)").text());
                                    $('.formGroupDescEdit').attr('value',$("#datatablesSimple tbody tr:nth-child( "+ indextab +" ) td:nth-child(3)").text());
                                    
                                    
                                
             
                            });
                            
                            $('.delete').on('click',function() {
                                
                                var self = $(this);
                           
                                                        var index=self.attr('id');                
                                                        $('.formGroupIdDelete').attr('value', index);
                                                        $('.elemento').text(index);
                                                        
                            });
                        
            
            
            $(".findClose").find(function () {
                var selectedText = $(this).find("option:selected").text();
                $(".elemento").text(selectedText)/*.html("</br>")*/;
            });
            $(".mostrar").hide();
            $(".fecha").prop('readonly', true);
            $("#MainContent_fechanow").datepicker({
                minDate: 0,
                maxDate: "+7D",
                dateFormat: "dd/mm/yy",
                firstDay: 1,
                showAnim: "slideDown",
                dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
                monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                beforeShowDay: noMondays
            });
            
           function noMondays(date){
                                      <%: idespef%>
                                      <%: idmedicof%>
                                      <%  
                                          if(ListaEspecialidadxMedico!=null)
                                              foreach (var tux in ListaEspecialidadxMedico)
                                              {
                                                  
                                                  if (idespef == tux.Id_Especialidad && tux.ID_MEDICO==idmedicof)
                                                  { %>
                                                  
                                                   var my_array = new Array(<%: tux.Atiende_Lunes?1:8 %>,<%:tux.Atiende_Martes?2:8%>,<%:tux.Atiende_Miercoles?3:8%>,
                                                   <%:tux.Atiende_Jueves?4:8%>,
                                                   <%:tux.Atiende_Viernes?5:8%>,
                                                   <%:tux.Atiende_Sabado?6:8%>,
                                                   <%:tux.Atiende_Domingo?0:8%>);
                                                                               
                                              <% }
                                              } %>
                                              
                                                                         if (date.getDay() !== my_array.find(x=> x === date.getDay() ) )  /* Monday */
                                                                          return [ false, "closed", "Closed on Monday" ]
                                                                           else
                                                                               return [ true, "", "" ]
                                  }
        });
       
    </script>
<% }
   else if (pivot)
       Response.Redirect("~/Admin/Perfil.aspx", false);
   else
       Response.Redirect("Default.aspx", false);
%>
</asp:Content>