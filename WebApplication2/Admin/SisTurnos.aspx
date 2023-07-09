<%@ Page Title="Title" Language="C#" MasterPageFile="~/Admin/Panel.master" CodeBehind="SisTurnos.aspx.cs" Inherits="WebApplication2.Admin.SisTurnos" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" xmlns:aps="http://www.w3.org/1999/html">

     <main>
                        <header class="page-header page-header-dark bg-gradient-primary-to-secondary pb-10">
                            <div class="container-xl px-4">
                                <div class="page-header-content pt-4">
                                    <div class="row align-items-center justify-content-between">
                                        <div class="col-auto mt-4">
                                            <h1 class="page-header-title">
                                                <div class="page-header-icon"><i data-feather="arrow-right-circle"></i></div>
                                                Seleccionar Turno
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
                                    <div class="nav nav-pills nav-justified flex-column flex-xl-row nav-wizard" id="cardTab" role="tablist">
                                        <!-- Wizard navigation item 1-->
                                        <a class="nav-item nav-link <%: Session["class"]== "btn1" ? "active":" "%>" id="wizard1-tab" href="#wizard1" data-bs-toggle="tab" role="tab" aria-controls="wizard1" aria-selected="true">
                                            <div class="wizard-step-icon">1</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Especialidad</div>
                                                <div class="wizard-step-text-details">Primer Paso</div>
                                            </div>
                                        </a>
                                        <!-- Wizard navigation item 2-->
                                        <a class="nav-item nav-link <%: Session["class"]== "btn2" ? "active":" "%>" id="wizard2-tab" href="#wizard2" data-bs-toggle="tab" role="tab" aria-controls="wizard2" aria-selected="true">
                                            <div class="wizard-step-icon">2</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Medicos</div>
                                                <div class="wizard-step-text-details">Segundo Paso</div>
                                            </div>
                                        </a>
                                        <!-- Wizard navigation item 3-->
                                        <a class="nav-item nav-link <%: Session["class"]== "btn3" ? "active":" "%>" id="wizard3-tab" href="#wizard3" data-bs-toggle="tab" role="tab" aria-controls="wizard3" aria-selected="true">
                                            <div class="wizard-step-icon">3</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Fecha</div>
                                                <div class="wizard-step-text-details">Tercer Paso</div>
                                            </div>
                                        </a>
                                        <!-- Wizard navigation item 4-->
                                        <a class="nav-item nav-link <%: Session["class"]== "btn4" ? "active":" "%>" id="wizard4-tab" href="#wizard4" data-bs-toggle="tab" role="tab" aria-controls="wizard4" aria-selected="true">
                                            <div class="wizard-step-icon">4</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Confirmar</div>
                                                <div class="wizard-step-text-details">Ultimo Paso</div>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="tab-content" id="cardTabContent">
                                        <!-- Wizard tab pane item 1-->
                                        <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"]== "btn1" ? " show active":" "%>" id="wizard1" role="tabpanel" aria-labelledby="wizard1-tab">
                                            <div class="row justify-content-center">
                                                <div class="col-xxl-6 col-xl-8">
                                                    <h3 class="text-primary">Seccion 1</h3>
                                                    <h5 class="card-title mb-4">Seleccionar una especialidad</h5>
                                                    
                                                    
                                                        <div class="mb-3">
                                                            <asp:PlaceHolder ID="Muestra1"  runat="server"  />
                                                        </div>
                                                        <div class="mb-3">
                                                            <asp:ListBox CssClass="form-control"  OnSelectedIndexChanged="horarios_OnSelectedIndexChanged" ID="horarios" runat="server" AutoPostBack="true">
                                                                <asp:ListItem  Text="Turnos 6 am a 11 am" Value="0" />
                                                                <asp:ListItem Text="Turnos 11 am a 16 pm" Value="1" />
                                                                <asp:ListItem Text="Turnos 16 pm a 21 pm" Value="2" />
                                                            </asp:ListBox>
                                                            
                                                            
                                                            
                                                        </div>
                                                        
                                                        <hr class="my-4" />
                                                        <div class="d-flex justify-content-between">
                                                            <button class="btn btn-light disabled" type="button" disabled>anterior</button>
                                                            <asp:Button CssClass="btn btn-primary" ID="bt2" CommandArgument="btn2" OnClick="button1_OnClick"  Text="Siguiente" runat="server"/>
                                                        </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Wizard tab pane item 2-->
                                        <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"]== "btn2" ? " show active":" "%>" id="wizard2" role="tabpanel" aria-labelledby="wizard2-tab">
                                            <div class="row justify-content-center">
                                                <div class="col-xxl-6 col-xl-8">
                                                    <h3 class="text-primary">Paso 2</h3>
                                                    <h5 class="card-title mb-4">Seleccione Medico</h5>
                                                    
                                                        <div class="row gx-3">
                                                            <div class="mb-3 col-md-6">
                                                                <asp:PlaceHolder ID="Muestra2"  runat="server"  />
                                                            </div>
                                                        </div>
                                                        <div class="row gx-3">
                                                            <div class="mb-3 col-md-6">
                                                                <asp:TextBox ID="fechanow" CssClass="form-control ps-0 pointer"  runat="server" type="text"/>
                                                            </div>
                                                             
                                                            
                                                        </div>
                                                        <hr class="my-4" />
                                                        <div class="d-flex justify-content-between">
                                                            <asp:Button ID="bt1" CssClass="btn btn-light" text="anterior" CommandArgument="btn1" OnClick="button1_OnClick"  runat="server"/>
                                                            <asp:Button CssClass="btn btn-primary " Text="Siguiente" ID="bt3" CommandArgument="btn3" type="button" OnClick="button1_OnClick" runat="server" />
                                                        </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Wizard tab pane item 3-->
                                        <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"]== "btn3" ? " show active":" "%>" id="wizard3" role="tabpanel" aria-labelledby="wizard3-tab">
                                            <div class="row justify-content-center">
                                                <div class="col-xxl-6 col-xl-8">
                                                    <h3 class="text-primary">Paso 3</h3>
                                                    <h5 class="card-title mb-4">Seleccione Fecha</h5>
                                                    
                                                        <div class="form-check mb-2">
                                                            <asp:PlaceHolder ID="Fecha" runat="server"/>
                                                            <input class="form-check-input" id="checkAccountChanges" type="checkbox" checked />
                                                            <label class="form-check-label" for="checkAccountChanges">Changes made to your account</label>
                                                        </div>
                                                        <div class="form-check mb-2">
                                                            <input class="form-check-input" id="checkAccountGroups" type="checkbox" checked />
                                                            <label class="form-check-label" for="checkAccountGroups">Changes are made to groups you're part of</label>
                                                        </div>
                                                        <div class="form-check mb-2">
                                                            <input class="form-check-input" id="checkProductUpdates" type="checkbox" checked />
                                                            <label class="form-check-label" for="checkProductUpdates">Product updates for products you've purchased or starred</label>
                                                        </div>
                                                        <div class="form-check mb-2">
                                                            <input class="form-check-input" id="checkProductNew" type="checkbox" checked />
                                                            <label class="form-check-label" for="checkProductNew">Information on new products and services</label>
                                                        </div>
                                                        <div class="form-check mb-2">
                                                            <input class="form-check-input" id="checkPromotional" type="checkbox" />
                                                            <label class="form-check-label" for="checkPromotional">Marketing and promotional offers</label>
                                                        </div>
                                                        <div class="form-check">
                                                            <input class="form-check-input" id="checkSecurity" type="checkbox" checked disabled />
                                                            <label class="form-check-label" for="checkSecurity">Security alerts</label>
                                                        </div>
                                                        <hr class="my-4" />
                                                        <div class="d-flex justify-content-between">
                                                            <asp:Button CssClass="btn btn-light" ID="btn2" CommandArgument="btn2" OnClick="button1_OnClick" Text="anterior" runat="server"/>
                                                            <asp:Button CssClass="btn btn-primary" ID="btn4" CommandArgument="btn4" OnClick="button1_OnClick" Text="siguiente" runat="server"/>
                                                        </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Wizard tab pane item 4-->
                                        <div class="tab-pane py-5 py-xl-10 fade <%: Session["class"]== "btn4" ? " show active":" "%>" id="wizard4" role="tabpanel" aria-labelledby="wizard4-tab">
                                            <div class="row justify-content-center">
                                                <div class="col-xxl-6 col-xl-8">
                                                    <h3 class="text-primary">Paso 4</h3>
                                                    <h5 class="card-title mb-4">Confirmar pedido</h5>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Username:</em></div>
                                                        <div class="col">username</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Name:</em></div>
                                                        <div class="col">Valerie Luna</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Organization Name:</em></div>
                                                        <div class="col">Start Bootstrap</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Location:</em></div>
                                                        <div class="col">San Francisco, CA</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Email Address:</em></div>
                                                        <div class="col">name@example.com</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Phone Number:</em></div>
                                                        <div class="col">555-123-4567</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Birthday:</em></div>
                                                        <div class="col">06/10/1988</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Credit Card Number:</em></div>
                                                        <div class="col">**** **** **** 1111</div>
                                                    </div>
                                                    <div class="row small text-muted">
                                                        <div class="col-sm-3 text-truncate"><em>Credit Card Expiration:</em></div>
                                                        <div class="col">06/2024</div>
                                                    </div>
                                                    <hr class="my-4" />
                                                    <div class="d-flex justify-content-between">
                                                        <asp:Button CssClass="btn btn-light" Text="anterior" ID="btn3" CommandArgument="btn3" OnClick="button1_OnClick" runat="server"/>
                                                        <asp:Button CssClass="btn btn-primary" Text="Confirmar" ID="sube" runat="server"/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </main>
    
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
    <script >
       $(function (){
    
            $("#MainContent_fechanow").datepicker({
             minDate: 0,
             maxDate: "+7D",
             dateFormat: "dd/mm/yy",
             firstDay: 1,
             showAnim: "slideDown",
             dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
             
            });
    
       });
       </script>
    
</asp:Content>

