﻿<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.master" CodeBehind="Password.aspx.cs" Inherits="WebApplication2.Admin.Password" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="layoutSidenav_content">
        <main>
            <header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
                <div class="container-xl px-4">
                    <div class="page-header-content">
                        <div class="row align-items-center justify-content-between pt-3">
                            <div class="col-auto mb-3">
                                <h1 class="page-header-title">
                                    <div class="page-header-icon">
                                        <i data-feather="user"></i>
                                    </div>
                                    Perfil
                                </h1>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <!-- Main page content-->
            <div class="container-xl px-4 mt-4">
                <!-- Account page navigation-->
                <nav class="nav nav-borders">
                    <a class="nav-link ms-0" href="Perfil.aspx">Perfil</a>
                    <a class="nav-link" href="Password.aspx">Cambiar Contraseña</a>
                </nav>
                <hr class="mt-0 mb-4"/>
                <div class="row">
                    <div class="col-lg-12">
                        <!-- Change password card-->
                        <div class="card mb-4">
                            <div class="card-header">Cambiar Password</div>
                            <div class="card-body">
                                
                                    <!-- Form Group (current password)-->
                                    <div class="mb-3">
                                        <label class="small mb-1" for="MainContent_inputPassword">Password actual</label>
                                        <asp:TextBox CssClass="form-control" id="inputPassword" type="password" runat="server"/>
                                    </div>
                                    <!-- Form Group (new password)-->
                                    <div class="mb-3">
                                        <label class="small mb-1" for="MainContent_inputNuevoPassword">Nuevo Password</label>
                                        <asp:TextBox CssClass="form-control" id="inputNuevoPassword" type="password" runat="server" />
                                    </div>
                                    <!-- Form Group (confirm password)-->
                                    <div class="mb-3">
                                        <label class="small mb-1" for="MainContent_inputconfirmaPassword">Confirma Password</label>
                                        <asp:TextBox CssClass="form-control" id="inputConfirmaPassword" type="password"  runat="server"/>
                                    </div>
                                    <asp:Button ID="guardaPassword" CssClass="btn btn-primary" Text="Guardar" runat="server"/>
                                
                            </div>
                        </div>
                        
                    </div>
                  
                </div>
            </div>
        </main>
    </div>
</asp:Content>