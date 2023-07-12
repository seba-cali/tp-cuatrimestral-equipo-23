<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="CrearEspecialidadyTurno.aspx.cs" Inherits="WebApplication2.Admin.CrearEspecialidadyTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align: center;">Crear Especialidad y Turno por Medico</h2>
    <div class="container">
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="ddlMedico">Medico</label>
                    <asp:DropDownList ID="ddlMedico" runat="server" CssClass="form-control">
                        <!-- Opciones del DropDownList -->
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlEspecialidad">Especialidad</label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
                        <!-- Opciones del DropDownList -->
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlTurno">Turno</label>
                    <asp:DropDownList ID="ddlTurno" runat="server" CssClass="form-control">
                        <!-- Opciones del DropDownList -->
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>