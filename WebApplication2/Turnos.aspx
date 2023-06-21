<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="WebApplication2.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="nav nav-tabs justify-content-center" id="myTab" role="tablist">
        <li class="nav-item" role="presentation">
            <button class="nav-link active" id="MisTurnos-tab" data-bs-toggle="tab" data-bs-target="#MisTurnos" type="button" role="tab" aria-controls="Misturnos" aria-selected="true">Mis Turnos</button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="NuevoTurno-tab" data-bs-toggle="tab" data-bs-target="#NuevoTurno" type="button" role="tab" aria-controls="NuevoTurno" aria-selected="false">Nuevo Turno</button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="Estudios-tab" data-bs-toggle="tab" data-bs-target="#Estudios" type="button" role="tab" aria-controls="Estudios" aria-selected="false">Estudios</button>
        </li>
    </ul>
    <div class="tab-content " id="myTabContent">
        <div class="tab-pane fade show active" id="MisTurnos" role="tabpanel" aria-labelledby="MisTurnos-tab">Seba</div>
        <div class="tab-pane fade" id="NuevoTurno" role="tabpanel" aria-labelledby="NuevoTurno-tab">

            <div class="container">
                <div class="row justify-content-center">
                    <div class="col">
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtObraSocial" AutoPostBack="true" CssClass="form-control " placeholder="Obra Social" />
                        </div>
                    <div class="col">
                        </div>
                </div>

                    <div class="row">
                        <div class="col-3">
                            <asp:DropDownList runat="server" ID="txtEspecialidad" AutoPostBack="true" CssClass="form-control" placeholder="Especialidad" OnTextChanged="txtEspecialidad_TextChanged" />

                        </div>
                        <div class="col-2">
                            <asp:TextBox runat="server" ID="txtMedico" AutoPostBack="true" CssClass="form-control" placeholder="Medico" />
                    </div>

                        </div>

                        <div class="col">
                            <asp:TextBox runat="server" ID="txtFecha" AutoPostBack="true" CssClass="form-control" placeholder="Fecha" />
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtHora" AutoPostBack="true" CssClass="form-control" placeholder="Hora" />
                        </div>
            </div>
        </div>
        </div>
            <div class="tab-pane fade" id="Estudios" role="tabpanel" aria-labelledby="Estudios-tab">1234</div>
  
</asp:Content>
