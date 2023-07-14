<%@ Page Title="Administracion" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="Administrar_Personas.aspx.cs" Inherits="WebApplication2.Admin.Administrar_Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<%--PACIENTES--%>
	<h2 style="text-align: center;">Administración de Pacientes</h2>
	<%--<asp:ScriptManager runat="server"></asp:ScriptManager>--%>
	<asp:UpdatePanel runat="server">
		<ContentTemplate>

			<div style="display: flex" class="d-flex justify-content-center">
				<asp:Label Text="🔍 Filtrar" runat="server" CssClass="mx-2"></asp:Label>
				<asp:TextBox runat="server" ID="filtro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
			</div>
			<br />

			<div style="display: flex; justify-content: center;">
				<asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered table-sm mx-auto" AutoGenerateColumns="false">
					<HeaderStyle HorizontalAlign="Center" />
					<RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
					<Columns>
						<asp:BoundField HeaderText="ID Paciente" DataField="id" />
						<asp:BoundField HeaderText="ID Usuario" DataField="ID_USUARIO" />
						<asp:BoundField HeaderText="Nombres" DataField="nombres" />
						<asp:BoundField HeaderText="Apellidos" DataField="apellidos" />
						<asp:BoundField HeaderText="DNI" DataField="dni" />
						<asp:CheckBoxField HeaderText="Estado" DataField="ESTADO" />
						<asp:TemplateField HeaderText="Acciones">
							<%--BOTONES--%>
							<ItemTemplate>
								<asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary btn-sm" Text="🛠" OnClick="btnModificar_Click" CommandArgument='<%# Eval("id") + "," + Eval("ID_USUARIO") %>' />
								<asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" Text="🗑" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("id") %>' />
								<asp:Button ID="btnReactivar" runat="server" CssClass="btn btn-success btn-sm" Text="🌱" OnClick="btnReactivar_Click" CommandArgument='<%# Eval("id") %>' />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>


