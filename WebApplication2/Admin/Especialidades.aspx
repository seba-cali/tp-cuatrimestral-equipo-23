<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.master" CodeBehind="Especialidades.aspx.cs" Inherits="WebApplication2.Admin.Especialidades" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                                Lista de Especialidades
                            </h1>
                        </div>
                        <div class="col-12 col-xl-auto mb-3">
                            
                            <button class="btn btn-sm btn-light text-primary" type="button" data-bs-toggle="modal" data-bs-target="#createGroupModal">
                                <i class="me-1" data-feather="plus"></i>
                                Crear Nueva Especialidad
                            </button>
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
                            <th>Especialidad</th>
                            <th>Descripcion</th>
                            <th>Imagen</th>
                            <th>Acciones</th>
                        </tr>
                        </thead>
                        <tfoot>
                        <tr>
                            <th>id</th>
                            <th>Especialidad</th>
                            <th>Descripcion</th>
                            <th>Imagen</th>
                            <th>Acciones</th>
                        </tr>
                        </tfoot>
                        <tbody>
                        <% 
                            foreach (Dominio.Especialidad espe in ListaEspecialidades)
                           {  %>
                            <tr>
                                <td class="esp<%= espe.id %>"><%: espe.id %></td>
                                <td class="esp<%= espe.nombre%>"><%: espe.nombre %></td>
                                <td><%: espe.descripcion %></td>
                                <td>
                                    <img src="<%: espe.url_img_esp %>" class="img-fluid w-25" alt="">

                                </td>
                                <td>
                                    <a id="<%= espe.id %>"  class="btn btn-datatable btn-icon btn-transparent-dark editar me-2" type="button"   data-bs-toggle="modal" data-bs-target="#editGroupModal">
                                        <i data-feather="edit"></i>
                                    </a>
                                    <a id="<%= espe.id %>" class="btn btn-datatable btn-icon btn-transparent-dark delete" type="button"   data-bs-toggle="modal" data-bs-target="#eliminaGroupModal">
                                        <i data-feather="trash-2"></i>
                                    </a>
                                </td>
                            </tr>
                        <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- Create group modal-->
        <div class="modal fade" id="createGroupModal" tabindex="-1" role="dialog" aria-labelledby="createGroupModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="createGroupModal">Crear o Editar Especialidad</h5>
                        <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    
                    <div class="modal-body">
                        
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupName">Nombre</label>
                            <asp:TextBox class="form-control" id="formGroupName" type="text" placeholder="nombre..." runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupDesc">Descripcion</label>
                            <asp:TextBox class="form-control" id="formGroupDesc" type="text" placeholder="descripcion..." runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupURL">Imagen</label>
                            <asp:TextBox class="form-control" id="formGroupURL" type="text" placeholder="url imagen" runat="server"/>
                        </div>
                        <div class="mb-0">
                        <% if (Session["OK"] != null)
                           { %>
                                <div class="alert alert-success" role="alert">
                                									<%: Session["OK"] %>
                                								</div>
                                <% } %>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button1" runat="server" Text="Crear Nueva Especialidad" CssClass="btn btn-primary-soft text-primary" OnClick="AltaEscpecialidad"/>
                    </div>
                     
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
                            <asp:TextBox class="form-control formGroupId" id="formGroupId" type="text" hidden  runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupName">Nombre</label>
                            <asp:TextBox class="form-control formGroupNameEdit" id="formGroupNameEdit" type="text" placeholder="nombre..." runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupDesc">Descripcion</label>
                            <asp:TextBox class="form-control formGroupDescEdit" id="formGroupDescEdit" type="text" placeholder="descripcion..." runat="server"/>
                        </div>
                        <div class="mb-0">
                            <label class="mb-1 small text-muted" for="formGroupURL">Imagen</label>
                            <asp:TextBox class="form-control formGroupURLEdit" id="formGroupURLEdit" type="text" placeholder="url imagen" runat="server"/>
                        </div>
                        <div class="mb-0">
                            <img class="img-fluid w-25 imagen" alt="">
                        </div>


                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button2" runat="server" Text="Modificar Especialidad" CssClass="btn btn-primary-soft text-primary" OnClick="EditarEscpecialidad"/>
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
                        <asp:Button ID="Button3" runat="server" Text="Eliminar Especialidad" CssClass="btn btn-primary-soft text-primary" OnClick="EliminaEscpecialidad"/>
                    </div>

                </div>
            </div>
        </div>
    </main>
    <script >
    		$(function() {
                
               
            
               
                $('.editar').click(function() {
                     var self = $(this);
               
                        var index=self.attr('id');                
                        $('.formGroupId').attr('value', index);
                        $('.formGroupNameEdit').attr('value',$("#datatablesSimple tbody tr:nth-child( "+ index +" ) td:nth-child(2)").text());
                        $('.formGroupDescEdit').attr('value',$("#datatablesSimple tbody tr:nth-child( "+ index +" ) td:nth-child(3)").text());
                        $('.formGroupURLEdit').attr('value',$("#datatablesSimple tbody tr:nth-child( "+ index +" ) td:nth-child(4) img").attr("src"));
                        $('.imagen').attr('src',$("#datatablesSimple tbody tr:nth-child( "+ index +" ) td:nth-child(4) img").attr("src"));
                    
 
                });
                $('.delete').click(function() {
                    
                    var self = $(this);
               
                                            var index=self.attr('id');                
                                            $('.formGroupIdDelete').attr('value', index);
                                            $('.elemento').attr('value', index);
                                            
                });
            });
    		
    		
    </script>
</asp:Content>
