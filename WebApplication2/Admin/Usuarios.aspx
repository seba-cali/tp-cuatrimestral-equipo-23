<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.master" CodeBehind="Usuarios.aspx.cs" Inherits="WebApplication2.Admin.Usuarios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<main>
                        <header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
                            <div class="container-fluid px-4">
                                <div class="page-header-content">
                                    <div class="row align-items-center justify-content-between pt-3">
                                        <div class="col-auto mb-3">
                                            <h1 class="page-header-title">
                                                <div class="page-header-icon"><i data-feather="user"></i></div>
                                                Lista de Usuarios
                                            </h1>
                                        </div>
                                        <div class="col-12 col-xl-auto mb-3">
                                            
                                            <a class="btn btn-sm btn-light text-primary" href="alta_Persona.aspx">
                                                <i class="me-1" data-feather="user-plus"></i>
                                                Add New User
                                            </a>
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
                                                <th>Usuario</th>
                                                <th>Email</th>
                                                <th>Role</th>
                                                <th>Groups</th>
                                                <th>Joined Date</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>User</th>
                                                <th>Email</th>
                                                <th>Role</th>
                                                <th>Groups</th>
                                                <th>Joined Date</th>
                                                <th>Actions</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                        <% foreach (var pivot in usuariosx)
                                           {
                                               
                                            %>  
                                        <tr>
                                                <td>
                                                    <div class="d-flex align-items-center">
                                                        <div class="avatar me-2"><img class="avatar-img img-fluid" src="assets/img/illustrations/profiles/profile-1.png" /></div>
                                                        <%: pivot.username%>
                                                    </div>
                                                </td>
                                                <td>    <%: pivot.CORREO%></td>
                                                <td>    <%: pivot.ID_TIPOUSUARIO%></td>
                                                <td>asdsad</td>    
                                                <td>    <%: pivot.fechaNacimiento%></td>
                                            
                                                <td>
                                                    <a class="btn btn-datatable btn-icon btn-transparent-dark me-2" href="user-management-edit-user.html"><i data-feather="edit"></i></a>
                                                    <a class="btn btn-datatable btn-icon btn-transparent-dark" href="#!"><i data-feather="trash-2"></i></a>
                                                </td>
                                            </tr>
                                            <% } %>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </main>
</asp:Content>