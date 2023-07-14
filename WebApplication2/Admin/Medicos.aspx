<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.master" CodeBehind="Medicos.aspx.cs" Inherits="WebApplication2.Admin.Medicos" %>
<%@ Import Namespace="Dominio" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div id="layoutSidenav_content">
    <main>
        <header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
            <div class="container-fluid px-4">
                <div class="page-header-content">
                    <div class="row align-items-center justify-content-between pt-3">
                        <div class="col-auto mb-3">
                            <h1 class="page-header-title">
                                <div class="page-header-icon">
                                    <i data-feather="users"></i>
                                </div>
                                Turnos del dia
                            </h1>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <!-- Main page content-->
        <div class="container-fluid px-4">
            <div class="card">
                <div class="card-body">
                    <table id="datatablesSimple">
                        <thead>
                        <tr>
                            <th>id</th>
                            <th>Nombre</th>
                            <th>Dni</th>
                            <th>Especialidad</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Observacion</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                        </thead>
                        <tfoot>
                        <tr>
                            <th>id</th>
                            <th>Nombre</th>
                            <th>Dni</th>
                            <th>Especialidad</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Observacion</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                        </tfoot>
                        <tbody>
                        <%
                            foreach (Turnos tux in ListaTurnos)
                            {
                                var pac = ListaPacientes.Find(x => x.ID_PACIENTE == tux.Id_Paciente);
                                var esp = ListaEspecialidades.Find(x => x.id == tux.Id_Especialidad);
                                if (tux.fecha == DateTime.Today)
                                {
                        %>
                                <tr>
                                    <td class="esp<%= tux.Id_Turno %>"><%: tux.Id_Turno %></td>
                                    <td class="esp<%= pac.nombreCompleto %>"><%: pac.nombreCompleto %></td>
                                    <td><%: pac.DNI %></td>
                                    <td>
                                        <%: esp.nombre %>

                                    </td>
                                    <td><%: tux.fecha.ToShortDateString() %></td>
                                    <td><%= Turnos.GetRepro()[tux.Id_Hora] %></td>
                                    <td><%= tux.observacionMed %></td>
                                    <td><%= Turnos.EstadoInfArray[tux.EstadoInf] %></td>

                                    <td>
                                        <a id="<%= tux.Id_Turno %>" class="btn btn-datatable btn-icon btn-transparent-dark editar me-2" type="button" data-bs-toggle="modal" data-bs-target="#editGroupModal">
                                            <i data-feather="edit"></i>
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
                            
                                    <asp:TextBox class="form-control formGroupId" id="formGroupId" type="text" ReadOnly="True" AutoPostBack="True" runat="server"/>
                            
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupName">Nombre</label>
                            <asp:TextBox class="form-control formGroupNameEdit" id="inputId" ReadOnly="True" type="text" runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupDesc">Estado</label>
                            
                                    <asp:DropDownList ID="inputEstado" runat="server" CssClass="form-control" AutoPostBack="True">
                                        <asp:ListItem Text="Cambiar estado" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No Asistio" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Cerrado" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                            

                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupURL">Observacion</label>
                            
                                    <asp:TextBox class="form-control" TextMode="MultiLine" id="inputObs" AutoPostBack="True" runat="server"/>
                            
                        </div>
                        <div class="mb-0">
                            <img class="img-fluid w-25 imagen" alt="">
                        </div>


                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button2" runat="server" Text="Atender Paciente" CausesValidation="False" OnClientClick="return ;" OnClick="Button2_OnClick" CssClass="btn btn-primary-soft text-primary"/>
                    </div>

                </div>
            </div>
        </div>
        <%
            if
                (Session["OK"] != null)
            {
        %>
            <div style="position: absolute; bottom: 1rem; right: 1rem; visibility : <%: Session["OK"] == null ? "hidden" : "visible" %> ">
                <!-- Toast -->
                <div class="toast " id="toastBasic" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="3000">
                    <div class="toast-header bg-info">
                        <i data-feather="bell"></i>
                        <strong class="mr-auto">Alerta</strong>
                        <small class="text-muted ml-2">Exito:</small>
                        <button class="ml-2 mb-1 btn-close" type="button" data-bs-dismiss="toast" aria-label="Close"> </button>
                    </div>
                    <div class="toast-body"><%: Session["OK"] %></div>
                </div>
            </div>
        <% } %>
        <%
    if (Session["error"] != null)
    {
        %>
            <div style="position: absolute; bottom: 1rem; right: 1rem; visibility : <%: Session["error"] == null ? "hidden" : "visible" %> ">
                <!-- Toast -->
                <div class="toast " id="toastBasic" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="3000">
                    <div class="toast-header bg-info">
                        <i data-feather="bell"></i>
                        <strong class="mr-auto">Alerta</strong>
                        <small class="text-muted ml-2">Error: </small>
                        <button class="ml-2 mb-1 btn-close" type="button" data-bs-dismiss="toast" aria-label="Close"> </button>
                    </div>
                    <div class="toast-body"><%: Session["error"] %></div>
                </div>
            </div>
        <% }
                    Session["error"] = null;
        %>
    </main>
</div>
<script >
 		$(function() {
             
                
                    $("#toastBasic").toast("show");
                
              
       
               
                $('.editar').on('click',function() {
                     
               
                        var index=$(this).attr('id');             
                        var indextab=$(this).closest('tr').attr('data-index');
                        indextab++
                        $('.elementoedit').text(indextab);
                        $('.formGroupId').attr('value', index);
                        $('.formGroupNameEdit').attr('value',$("#datatablesSimple tbody tr:nth-child( "+ indextab +" ) td:nth-child(2)").text());
                        
                        
                    
 
                });
                
              
            });
    		
    		//elimina el parametro de la url previene el reenvio del formulario
            if ( window.history.replaceState ) {
              window.history.replaceState( null, null, window.location.href );
            }
    </script>
</asp:Content>