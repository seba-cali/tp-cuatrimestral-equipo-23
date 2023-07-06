﻿<%@ Page Title="Administracion" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="Administrar_Personas.aspx.cs" Inherits="WebApplication2.Admin.Administrar_Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2 style="text-align: center;">Administración de Pacientes</h2>
	<div style="display: flex; justify-content: center;">
		<asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered table-sm mx-auto" AutoGenerateColumns="false">
			<HeaderStyle HorizontalAlign="Center" />
			<RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
			<Columns>
				<asp:BoundField HeaderText="ID Paciente" DataField="id" />
				<asp:BoundField HeaderText="ID Usuario" Datafield="ID_USUARIO"/>
				<asp:BoundField HeaderText="Nombres" DataField="nombres" />
				<asp:BoundField HeaderText="Apellidos" DataField="apellidos" />
				<asp:BoundField HeaderText="DNI" DataField="dni" />
				<asp:CheckBoxField HeaderText="Estado" DataField="ESTADO" />
				<asp:TemplateField HeaderText="Acciones">
					<ItemTemplate>


						<asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary btn-sm" Text="Modificar" OnClick="btnModificar_Click"  CommandArgument='<%# Eval("id") + "," + Eval("ID_USUARIO") %>'/>




						<asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("id") %>' />
						<asp:Button ID="btnReactivar" runat="server" CssClass="btn btn-secondary btn-sm" Text="Reactivar" OnClick="btnReactivar_Click" CommandArgument='<%# Eval("id") %>' />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>















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
