<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="Administrar_EspeyTurnoxMed.aspx.cs" Inherits="WebApplication2.Admin.Administrar_EspeyTurnoxMed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    	<%--MEDICOS--%>
	<h2 style="text-align: center;">Administración de Turnos de trabajo y especialidades</h2>
	<div style="display: flex; justify-content: center;">
		<asp:GridView ID="dgvEspecialidadxTurno" runat="server" CssClass="table table-striped table-bordered table-sm mx-auto" AutoGenerateColumns="false">
			<%--<!-- Columnas del GridView para administración de médicos -->--%>
			<HeaderStyle HorizontalAlign="Center" />
			<RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
			<Columns>
				<%--agregar encabezados--%>
				<asp:BoundField HeaderText="ID Medico" DataField="ID_MEDICO" />
				<asp:BoundField HeaderText="Medico" DataField="Name" />
				<asp:BoundField HeaderText="ID Especialidad" DataField="ID_ESPECIALIDAD" />
				<asp:BoundField HeaderText="Especialidad" DataField="ESPECIALIDAD" />
				<asp:BoundField HeaderText="Turno" DataField="Turno_Horario" />
				<asp:TemplateField HeaderText="Acciones">
					<ItemTemplate>
<%--						<asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary btn-sm" Text="🛠" OnClick="btnModificar_Click" CommandArgument='<%# Eval("ID_MEDICO") + "," + Eval("ID_USUARIO") %>' />--%>
						<asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" Text="🗑" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("ID_MEDICO") + "," + Eval("ID_ESPECIALIDAD") + "," + Eval("Turno_Horario")%>' />
<%--						<asp:Button ID="btnReactivar" runat="server" CssClass="btn btn-success btn-sm" Text="🌱" OnClick="btnReactivar_Click" CommandArgument='<%# Eval("ID_MEDICO") %>' />--%>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
   
</asp:Content>
