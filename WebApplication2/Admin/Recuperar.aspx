<%@ Page Title="Title" Language="C#" MasterPageFile="~/Admin/Panel.master" CodeBehind="Recuperar.aspx.cs" Inherits="WebApplication2.Admin.Recuperar" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container-xl px-4">
            <div class="row justify-content-center">
                <div class="col-lg-5">
                    <!-- Basic forgot password form-->
                    <div class="card shadow-lg border-0 rounded-lg mt-5">
                        <div class="card-header justify-content-center">
                            <h3 class="fw-light my-4">Recuperar Password</h3>
                        </div>
                        <div class="card-body">
                            <div class="small mb-3 text-muted">Ingrese correo electronico para generar nueva clave.</div>
                            <!-- Forgot password form-->
                            <% idcode=0;
                                if (pivot == 0)
                               { %>
                                <!-- Form Group (email address)-->
                                <div class="mb-3">
                                    <label class="small mb-1" for="inputEmailAddress">Correo</label>
                                    <asp:TextBox CssClass="form-control" id="inputEmailAddress" type="email"  aria-describedby="emailHelp" placeholder="Ingrese Correo" runat="server"/>
                                    
                                </div>
                                <!-- Form Group (submit options)-->
                                <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                    <a class="small" href="Default.aspx">Return to login</a>
                                    <asp:Button CssClass="btn btn-primary" ID="inputEmailAddressButton" OnClick="btnRecuperar_Click" Text="Recuperar Password"  runat="server"/>
                                </div>
                                <div class="mb-3">
                                    <% if (Session["OK"] != null)
                                       { %>
                                        <div class="alert alert-danger" role="alert">
                                            <p><%: Session["OK"] %></p>
                                        </div>
                                    <% } %>
                                </div>
                            <div class="mb-3">
                                <% if (Session["error"] != null)
                                   { %>
                                <div class="alert alert-danger" role="alert">
                                    <p><%: Session["error"] %></p>
                                </div>
                                <% } %>
                            </div>
                            <% }
                               else if(pivot== 1)
                               { %>
                                <div class="mb-3">
                                    <label class="small mb-1" for="inputCode">Ingrese codigo</label>
                                    <asp:TextBox CssClass="form-control" id="inputCode" type="text" aria-describedby="emailHelp" placeholder="codigo" runat="server"/>
                                    
                                </div>
                                <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                    
                                    <asp:Button CssClass="btn btn-primary" ID="inputFindButton" OnClick="btnFindPaswword" Text="Recuperar Password" runat="server"/>
                                </div>
                                <% }
                               else if(pivot == 2)
                               { %>
                                <div class="mb-3">
                                    <label class="small mb-1" for="inputCode">Ingrese Password</label>
                                    <asp:TextBox CssClass="form-control" id="inputPassword" type="password" aria-describedby="emailHelp" placeholder="password" runat="server"/>

                                </div>
                                <div class="mb-3">
                                    <label class="small mb-1" for="inputCode">Ingrese Re Password</label>
                                    <asp:TextBox CssClass="form-control" id="inputRePassword" type="password" aria-describedby="emailHelp" placeholder="password" runat="server"/>

                                </div>
                                <div class="d-flex align-items-center justify-content-between mt-4 mb-0">

                                    <asp:Button CssClass="btn btn-primary" ID="inputUpdatePassword" OnClick="btnUpdatePaswword" Text="Recuperar Password" runat="server"/>
                                </div>
                                <% } %>
                        </div>
                        <div class="card-footer text-center">
                            <div class="small">
                                <a href="Registrar.aspx">sin Cuenta? Date de alta!</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
