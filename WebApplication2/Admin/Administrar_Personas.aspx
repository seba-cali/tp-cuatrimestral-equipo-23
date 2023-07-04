<%@ Page Title="Administracion" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="Administrar_Personas.aspx.cs" Inherits="WebApplication2.Admin.Administrar_Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <asp:GridView ID="dgvPacientes" runat="server" CssClass="table"></asp:GridView>















<%--<ul class="list-group">
    <li class="list-group-item">Pacientes</li>
    <%foreach (Dominio.Paciente paci in listPacientes)
        {%>
    <li class="list-group-item" id="pacienteFront">
        <%: paci.apellidos %>, <%: paci.nombres %> - DNI: <%: paci.DNI %>
        <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm" Text="✏" Onclick="btnEditar_Click" />
        <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger btn-sm" Text="💀" OnClick="btnBorrar_Click"  />
    </li>
    <%}%>
</ul>--%>




	<%--	<%foreach (Dominio.Medico paci in listMedicos)
		{

		}%>--%>
</asp:Content>
