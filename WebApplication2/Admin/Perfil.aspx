<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.master" CodeBehind="Perfil.aspx.cs" Inherits="WebApplication2.Admin.Perfil" %>

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
                    <div class="col-xl-4">
                        <!-- Profile picture card-->
                        <div class="card mb-4 mb-xl-0">
                            <div class="card-header">Tu Foto</div>
                            <div class="card-body text-center">

                                <asp:Image CssClass="img-account-profile rounded-circle mb-2" ID="Image1" runat="server"/>

                                <asp:FileUpload CssClass="btn btn-secondary" ID="FileUpload1" runat="server"/>

                                <div class="small font-italic text-muted mb-4">JPG or PNG Maximo 5 MB</div>
                                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server"
                                            Text="subir imagen" onclick="Button1_Click"/>
                                <br/>


                            </div>
                        </div>
                    </div>
                    <div class="col-xl-8">
                        <!-- Account details card-->
                        <div class="card mb-4">
                            <div class="card-header">Datos Personales</div>
                            <div class="card-body">

                                <!-- Form Group (username)-->
                                <div class="mb-3">

                                    <asp:Label ID="mensaje" runat="server"/>
                                    <asp:Label ID="userlabel" runat="server"/>
                                </div>
                                <!-- Form Row-->
                                <div class="row gx-3 mb-3">
                                    <!-- Form Group (first name)-->
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="MainContent_inputNombre">Nombre</label>
                                        <asp:TextBox CssClass="form-control" id="inputNombre" type="text" name="inputNombre" placeholder="nombre" value="Valerie" runat="server"/>
                                    </div>
                                    <!-- Form Group (last name)-->
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="MainContent_inputLastApellido">Apellido</label>
                                        <asp:TextBox CssClass="form-control" id="inputApellido" type="text" placeholder="apellido" value="Luna" runat="server"/>
                                    </div>
                                </div>
                                <!-- Form Row        -->
                                <div class="row gx-3 mb-3">
                                    <!-- Form Group (organization name)-->
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="MainContent_inputSexo">Sexo</label>
                                        <asp:DropDownList CssClass="form-control" id="inputSexo" type="text" runat="server"/>

                                    </div>
                                    <!-- Form Group (location)-->
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="MainContent_inputFNacimiento">Fecha Nacimiento</label>
                                        <asp:TextBox CssClass="form-control" id="inputFNacimiento" type="text" placeholder="9/12/2018" runat="server"/>

                                    </div>
                                </div>
                                <!-- Form Group (email address)-->
                                <div class="mb-3">
                                    <label class="small mb-1" for="MainContent_inputDomicilio">Domicilio</label>
                                    <asp:TextBox CssClass="form-control" id="inputDomicilio" type="text" placeholder="av siempre viva" runat="server"/>
                                </div>
                                <!-- Form Row-->
                                <div class="row gx-3 mb-3">
                                    <!-- Form Group (phone number)-->
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="MainContent_inputTelefono">Telefono</label>
                                        <asp:TextBox CssClass="form-control" id="inputTelefono" type="tel" placeholder="0303456" runat="server"/>
                                    </div>
                                    <!-- Form Group (birthday)-->
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="MainContent_inputDNI">DNI</label>
                                        <asp:TextBox CssClass="form-control" id="inputDNI" type="text" placeholder="00.0000.000" runat="server"/>
                                    </div>
                                </div>

                                <!-- Save changes button-->
                                <asp:Button CssClass="btn btn-primary" ID="guardar"  OnClick="guardar_OnClick" Text="guardar" runat="server"/>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </div>
</asp:Content>