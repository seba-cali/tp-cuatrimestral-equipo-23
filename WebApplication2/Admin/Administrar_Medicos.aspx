<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="Administrar_Medicos.aspx.cs" Inherits="WebApplication2.Admin.Administrar_Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<%--MEDICOS--%>
	<h2 style="text-align: center;">Administración de Médicos</h2>
	<asp:UpdatePanel runat="server">
		<ContentTemplate>
			<div style="display: flex" class="d-flex justify-content-center">
				<asp:Label Text="🔍 Filtrar" runat="server" CssClass="mx-2"></asp:Label>
				<asp:TextBox runat="server" ID="filtro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
			</div>
			<br />

			<div style="display: flex; justify-content: center;">
				<asp:GridView ID="dgvMedicos" runat="server" CssClass="table table-striped table-bordered table-sm mx-auto" AutoGenerateColumns="false">
					<%--<!-- Columnas del GridView para administración de médicos -->--%>
					<HeaderStyle HorizontalAlign="Center" />
					<RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
					<Columns>
						<%--agregar encabezados--%>
						<asp:BoundField HeaderText="ID Medico" DataField="ID_MEDICO" />
						<asp:BoundField HeaderText="ID Usuario" DataField="ID_USUARIO" />
						<asp:BoundField HeaderText="Nombres" DataField="NOMBRES" />
						<asp:BoundField HeaderText="Apellidos" DataField="APELLIDOS" />
						<asp:BoundField HeaderText="DNI" DataField="DNI" />
						<asp:CheckBoxField HeaderText="Estado" DataField="ESTADO" />
						<asp:TemplateField HeaderText="Acciones">
							<ItemTemplate>
								<asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary btn-sm" Text="🛠" OnClick="btnModificar_Click" CommandArgument='<%# Eval("ID_MEDICO") + "," + Eval("ID_USUARIO") %>' />
								<asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" Text="🗑" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("ID_MEDICO") %>' />
								<asp:Button ID="btnReactivar" runat="server" CssClass="btn btn-success btn-sm" Text="🌱" OnClick="btnReactivar_Click" CommandArgument='<%# Eval("ID_MEDICO") %>' />
								<asp:Button ID="btnEspecialidad" runat="server" CssClass="btn btn-warning btn-sm" Text="🎃" OnClick="btnEspecialidad_Click"  CommandArgument='<%# Eval("ID_MEDICO") %>' />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
