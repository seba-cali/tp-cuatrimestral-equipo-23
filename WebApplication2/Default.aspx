<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <%--Presentación--%>
        <section id="fondo" class="d-flex align-items-center py-5" style="margin-top: -60px;">
            <div class="container text-center">
                <h1 class="display-4">Bienvenido al Sistema de Turnos</h1>
                <p class="lead">Nos destacamos por brindar el mejor servicio.</p>
                <a href="#contact" class="btn btn-primary btn-lg scrollto">Contáctanos</a>
            </div>
        </section>
        <%--Tarjetas de servicios--%>
        <section class="py-5 bg-light">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-4 col-sm-6 mb-4">
                        <div class="card h-100 shadow">
                            <div class="card-header bg-info text-white">
                                <h3 class="mb-0">¿Por Qué Elegirnos?</h3>
                            </div>
                            <div class="card-body">
                                <p>
                                    Somos una empresa seria con años de experiencia en el mercado, brindando el mejor servicio a nuestros clientes.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-6 mb-4">
                        <div class="card h-100 shadow">
                            <div class="card-header">
                                <h3 class="mb-0">Medicina</h3>
                            </div>
                            <div class="card-body">
                                <p>
                                    Nuestros profesionales son médicos con gran vocación y pasión por su trabajo.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-6 mb-4">
                        <div class="card h-100 shadow">
                            <div class="card-header">
                                <h3 class="mb-0">Laboratorio</h3>
                            </div>
                            <div class="card-body">
                                <p>
                                    Contamos con un Laboratorio propio, ágil en la gestión de muestras.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-6 mb-4">
                        <div class="card h-100 shadow">
                            <div class="card-header">
                                <h3 class="mb-0">Enfermería</h3>
                            </div>
                            <div class="card-body">
                                <p>
                                    Enfermería disponible las 24 hs del día para el cuidado de nuestros pacientes.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <%--Iconos de servicios--%>
        <section class="py-5 bg-info">
            <div class="container text-center text-white">
                <div class="row">
                    <div class="col-4 mb-3">
                        <i class="fas fa-users-medical fa-3x"></i>
                        <h4 class="mt-3">Médicos Calificados</h4>
                    </div>
                    <div class="col-4 mb-3">
                        <i class="fas fa-laptop-medical fa-3x"></i>
                        <h4 class="mt-3">Tecnología Avanzada</h4>
                    </div>
                    <div class="col-4 mb-3">
                        <i class="fas fa-clinic-medical fa-3x"></i>
                        <h4 class="mt-3">Instalaciones Modernas</h4>
                    </div>
                </div>
            </div>
        </section>

        <section>
            <div id="preloader"></div>
            <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>
        </section>
    </main>

</asp:Content>

