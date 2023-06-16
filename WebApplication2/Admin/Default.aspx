<%@ Page Title="Title" AutoEventWireup="true" Language="C#" MasterPageFile="~/Admin/Panel.master" CodeBehind="~/Default.aspx.cs" Inherits="WebApplication2.Admin.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div id="layoutAuthentication">
                <div id="layoutAuthentication_content">
                    <main class="text-center">
                        <div class="container-xl px-4">
                            <div class="row justify-content-center">
                                <div class="col-lg-12">
                                    
                                    <div class="card shadow-lg border-0 rounded-lg mt-5">
                                        <div class="card-header justify-content-center"><h3 class="fw-light my-4">Sistema V1.0</h3></div>
                                        <div class="card-body">
                                            
                                            
                                            
                                                <div class="mb-3">
                                                    <label class="small mb-1" for="inputEmailAddress">DNI</label>
                                                    <asp:TextBox  CssClass="form-control" id="DNIUSER"   placeholder="Ingrese DNI"  runat="server"/>
                                                </div>
                                                
                                                <div class="mb-3">
                                                    <label class="small mb-1" for="inputPassword">Password</label>
                                                    <asp:TextBox CssClass="form-control" id="PASSWORDUSER"    placeholder="Ingrese password"  runat="server"/>
                                                </div>
                                                

                                                
                                                <div class=" align-items-center  mt-4 mb-0">
                                                    <asp:Button runat="server"  CssClass="btn btn-lg btn-primary"  Text="Login" OnClick="btn_Login" />
                                                </div>
                                                <%
                                                    if (Session["error"] != null)
                                                    {
                                                        %>
                                                    <div class="alert alert-danger" role="alert">
                                                        <%: Session["error"] %>
                                                    </div>
                                                <%
                                                    }
                                                %>
                                            
                                        </div>
                                        <div class="card-footer text-center">
                                            <div class="small"><a  id="create" href="Registrar.aspx">Crear</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </main>
                </div>
                
            </div>
            
     
</asp:Content>