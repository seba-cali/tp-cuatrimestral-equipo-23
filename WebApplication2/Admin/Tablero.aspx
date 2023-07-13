<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.Master" CodeBehind="Panel.aspx.cs" Inherits="WebApplication2.Admin.Tablero" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
.

<div id="layoutSidenav_content">
<main>
<header class="page-header page-header-dark bg-gradient-primary-to-secondary pb-10">
    <div class="container-xl px-4">
        <div class="page-header-content pt-4">
            <div class="row align-items-center justify-content-between">
                <div class="col-auto mt-4">
                    <h1 class="page-header-title">
                        <div class="page-header-icon">
                            <i data-feather="activity"></i>
                        </div>
                        Sistema de Turnos Dr. Seba
                    </h1>
                    <div class="page-header-subtitle">Sistema de Turnos V1.0 </div>
                </div>

            </div>
        </div>
    </div>
</header>
<!-- Main page content-->
<div class="container-xl px-4 mt-n10">
<div class="row">
    <div class="col-xxl-4 col-xl-12 mb-4">
        <div class="card h-100">
            <div class="card-body h-100 p-5">
                <div class="row align-items-center">
                    <div class="col-xl-8 col-xxl-12">
                        <div class="text-center text-xl-start text-xxl-center mb-4 mb-xl-0 mb-xxl-4">
                            <h1 class="text-primary">Hola! <%: usuario.username %>.  </h1>
                            <p class="text-gray-700 mb-0">Fecha: <%: DateTime.Now%></p>
                        </div>
                    </div>
                    <div class="col-xl-4 col-xxl-12 text-center">
                        <img class="img-fluid" src="../assets/img/medico.png" style="max-width: 16rem"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xxl-8 col-xl-12 mb-4">
        <div class="card card-header-actions h-100">
            <div class="card-header">
                Turnos Hoy
                <%--<div class="dropdown no-caret">
                                                                    <button class="btn btn-transparent-dark btn-icon dropdown-toggle" id="dropdownMenuButton" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="text-gray-500" data-feather="more-vertical"></i></button>
                                                                    <div class="dropdown-menu dropdown-menu-end animated--fade-in-up" aria-labelledby="dropdownMenuButton">
                                                                        <h6 class="dropdown-header">Filter Activity:</h6>
                                                                        <a class="dropdown-item" href="#!"><span class="badge bg-green-soft text-green my-1">Commerce</span></a>
                                                                        <a class="dropdown-item" href="#!"><span class="badge bg-blue-soft text-blue my-1">Reporting</span></a>
                                                                        <a class="dropdown-item" href="#!"><span class="badge bg-yellow-soft text-yellow my-1">Server</span></a>
                                                                        <a class="dropdown-item" href="#!"><span class="badge bg-purple-soft text-purple my-1">Users</span></a>
                                                                    </div>
                                                                </div>--%>
            </div>
            <div class="card-body">
                <div class="timeline timeline-xs">
                    <!-- Timeline Item 1-->
                    <% foreach (var tux in ListaTurnos)
                       {
                           var pac = ListaPacientes.Find(x => x.ID_PACIENTE == tux.Id_Paciente);
                           if (tux.fecha == DateTime.Today)
                           { %>
                    
                    <div class="timeline-item">
                        <div class="timeline-item-marker">
                            <div class="timeline-item-marker-text"><%= tux.fecha.Date.ToShortDateString()%></div>
                            <div class="timeline-item-marker-indicator bg-green"></div>
                        </div>
                        <div class="timeline-item-content">
                            <%= pac.nombreCompleto%>
                        </div>
                    </div>
                    <% }
                       } %>
                           </div>
            </div>
        </div>
    </div>
<%  if(usuario.ID_TIPOUSUARIO<3){ %>
</div>
<!-- Example Colored Cards for Dashboard Demo-->
<div class="row">
    <div class="col-lg-6 col-xl-3 mb-4">
        <div class="card bg-primary text-white h-100">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="me-3">
                        <div class="text-white-75 small">Turnos Activos</div>
                        <div class="text-lg fw-bold"><%= ListaTurnos.FindAll(x=> x.EstadoInf==0).Count%></div>
                    </div>
                    <i class="feather-xl text-white-50" data-feather="calendar"></i>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between small">
                <%--<a class="text-white stretched-link" href="#!">View Report</a>
                <div class="text-white">
                    <i class="fas fa-angle-right"></i>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="col-lg-6 col-xl-3 mb-4">
        <div class="card bg-warning text-white h-100">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="me-3">
                        <div class="text-white-75 small">No Asistio</div>
                        <div class="text-lg fw-bold"><%= ListaTurnos.FindAll(x=> x.EstadoInf==3).Count%></div>
                    </div>
                    <i class="feather-xl text-white-50" data-feather="calendar"></i>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between small">
                <%--<a class="text-white stretched-link" href="#!">View Report</a>
                <div class="text-white">
                    <i class="fas fa-angle-right"></i>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="col-lg-6 col-xl-3 mb-4">
        <div class="card bg-success text-white h-100">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="me-3">
                        <div class="text-white-75 small">Completados</div>
                        <div class="text-lg fw-bold"><%= ListaTurnos.FindAll(x=> x.EstadoInf==1).Count%></div>
                    </div>
                    <i class="feather-xl text-white-50" data-feather="check-square"></i>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between small">
                <%--<a class="text-white stretched-link" href="#!">View Tasks</a>
                <div class="text-white">
                    <i class="fas fa-angle-right"></i>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="col-lg-6 col-xl-3 mb-4">
        <div class="card bg-danger text-white h-100">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="me-3">
                        <div class="text-white-75 small">Turnos De Baja Cancelados</div>
                        <div class="text-lg fw-bold"><%= ListaTurnos.FindAll(x=> x.EstadoInf==2).Count%></div>
                    </div>
                    <i class="feather-xl text-white-50" data-feather="message-circle"></i>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between small">
                <%--<a class="text-white stretched-link" href="#!">View Requests</a>
                <div class="text-white">
                    <i class="fas fa-angle-right"></i>
                </div>--%>
            </div>
        </div>
    </div>
</div>
<!-- Example Charts for Dashboard Demo-->
<%--<div class="row">
    <div class="col-xl-6 mb-4">
        <div class="card card-header-actions h-100">
            <div class="card-header">
                Earnings Breakdown
                <div class="dropdown no-caret">
                    <button class="btn btn-transparent-dark btn-icon dropdown-toggle" id="areaChartDropdownExample" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="text-gray-500" data-feather="more-vertical"></i>
                    </button>
                    <div class="dropdown-menu dropdown-menu-end animated--fade-in-up" aria-labelledby="areaChartDropdownExample">
                        <a class="dropdown-item" href="#!">Last 12 Months</a>
                        <a class="dropdown-item" href="#!">Last 30 Days</a>
                        <a class="dropdown-item" href="#!">Last 7 Days</a>
                        <a class="dropdown-item" href="#!">This Month</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#!">Custom Range</a>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="chart-area">
                    <canvas id="myAreaChart" width="100%" height="30"></canvas>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xl-6 mb-4">
        <div class="card card-header-actions h-100">
            <div class="card-header">
                Monthly Revenue
                <div class="dropdown no-caret">
                    <button class="btn btn-transparent-dark btn-icon dropdown-toggle" id="areaChartDropdownExample" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="text-gray-500" data-feather="more-vertical"></i>
                    </button>
                    <div class="dropdown-menu dropdown-menu-end animated--fade-in-up" aria-labelledby="areaChartDropdownExample">
                        <a class="dropdown-item" href="#!">Last 12 Months</a>
                        <a class="dropdown-item" href="#!">Last 30 Days</a>
                        <a class="dropdown-item" href="#!">Last 7 Days</a>
                        <a class="dropdown-item" href="#!">This Month</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#!">Custom Range</a>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="chart-bar">
                    <canvas id="myBarChart" width="100%" height="30"></canvas>
                </div>
            </div>
        </div>
    </div>
</div>--%>
<% } %>
<!-- Example DataTable for Dashboard Demo-->
<div class="card mb-4">
    <div class="card-header">Administrador de Turnos</div>
    <div class="card-body">
        <table id="datatablesSimple">
            <thead>
            <tr>
                <th>Nombre</th>
                <th>DNI</th>
                <th>Especialidad</th>
                <th>Fecha</th>
                <th>Hora</th>
                <th>Estado</th>
                <%--<th>Actions</th>--%>
            </tr>
            </thead>
            <tfoot>
            <tr>
                <th>Nombre</th>
                <th>DNI</th>
                <th>Especialidad</th>
                <th>Fecha</th>
                <th>Hora</th>
                <th>Estado</th>
                <%--<th>Actions</th>--%>
            </tr>
            </tfoot>
            <tbody>
            <%--
            <tr>
                <td>Tiger Nixon</td>
                <td>System Architect</td>
                <td>Edinburgh</td>
                <td>61</td>
                <td>2011/04/25</td>
                <td>$320,800</td>
                <td>
                    <div class="badge bg-primary text-white rounded-pill">Full-time</div>
                </td>
                <td>
                    <button class="btn btn-datatable btn-icon btn-transparent-dark me-2">
                        <i data-feather="more-vertical"></i>
                    </button>
                    <button class="btn btn-datatable btn-icon btn-transparent-dark">
                        <i data-feather="trash-2"></i>
                    </button>
                </td>
                <
            </tr>
            --%>
            <% foreach

    (var tux in ListaTurnos)
               {
                        
                       var pac = ListaPacientes.Find(x => x.ID_PACIENTE == tux.Id_Paciente);
                       var esp = ListaEspecialidades.Find(x => x.id == tux.Id_Especialidad);
                   
            %>
                <tr>
                    <td><%= pac.nombreCompleto   %></td>
                    <td><%= pac.DNI   %></td>
                    <td><%= esp.nombre %></td>
                    <td><%= tux.fecha.Date.ToShortDateString() %></td>
                    <td><%= Turnos.GetRepro()[tux.Id_Hora] %></td>
                    <td>
                        <div class="badge bg-primary text-white rounded-pill"><%= Turnos.EstadoInfArray[tux.EstadoInf] %></div>
                    </td>
                    <%--<td>
                        <button class="btn btn-datatable btn-icon btn-transparent-dark me-2">
                            <i data-feather="more-vertical"></i>
                        </button>
                        <button class="btn btn-datatable btn-icon btn-transparent-dark">
                            <i data-feather="trash-2"></i>
                        </button>
                    </td>
                    --%>
                    
                </tr>
            <% } %>
            </tbody>
        </table>
    </div>
</div>
</div>
</main>
<footer class="footer-admin mt-auto footer-light">
    <div class="container-xl px-4">
        <div class="row">
            <div class="col-md-6 small">Copyright &copy; Your Website 2021</div>
            <div class="col-md-6 text-md-end small">
                <a href="#!">Privacy Policy</a>
                &middot;
                <a href="#!">Terms &amp; Conditions</a>
            </div>
        </div>
    </div>
</footer>
</div>
</asp:Content>