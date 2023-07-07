<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="alta_Persona.aspx.cs" Inherits="WebApplication2.Admin.alta_Persona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<style>
		.container {
			display: flex;
			flex-direction: column;
			align-items: center;
			justify-content: flex-start;
			height: 100vh;
			margin-top: 50px;
			background-image: url("https://images.pexels.com/photos/281260/pexels-photo-281260.jpeg");
			background-repeat: no-repeat;
			background-size: cover;
		}

		.form-control {
			margin-bottom: 10px;
		}

		.form-select {
			margin-bottom: 10px;
		}

		.btn-submit {
			background-color: #007bff;
			color: #fff;
			border-color: #007bff;
			padding: 8px 16px;
			border-radius: 4px;
			font-size: 16px;
			cursor: pointer;
		}

			.btn-submit:hover {
				background-color: #0069d9;
				border-color: #0062cc;
			}

			.btn-submit:focus {
				outline: none;
				box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
			}

		.inline-checkboxes {
			display: flex;
			flex-wrap: wrap;
			justify-content: center; /* Centra los elementos horizontalmente */
		}

			.inline-checkboxes .form-check {
				flex-basis: calc(100% / 6 - 20px); /* Divide el espacio en 6 columnas y ajusta el margen derecho e izquierdo */
				margin: 10px;
			}

		.fixed-size-btn {
			width: 200px; /* Ajusta el tamaño según tus necesidades */
			height: 40px; /* Ajusta el tamaño según tus necesidades */
		}
	</style>

	<div class="container">
		<h1>Alta de Persona</h1>

		<asp:Label ID="lblmsg" Text="Cargue los datos del paciente"
			Style="color: black; font-weight: bold;" runat="server" />

		<asp:TextBox CssClass="form-control" ID="inputNombres" type="text" placeholder="Nombres" runat="server" />
		<%--//validacion nombres requerido--%>
		<asp:RequiredFieldValidator ID="rfvNombres" ControlToValidate="inputNombres" ErrorMessage="⚠ Ingrese sus Nombres." runat="server" ForeColor="pink" Font-Bold="true" />

		<asp:TextBox CssClass="form-control" ID="inputApellidos" type="text" placeholder="Apellidos" runat="server" />
		<%--//validacion apellidos requerido--%>
		<asp:RequiredFieldValidator ID="rfvApellidos" ControlToValidate="inputApellidos" ErrorMessage="⚠ Ingrese sus Apellidos." runat="server" ForeColor="pink" Font-Bold="true" />

		<asp:DropDownList ID="inputSexo" runat="server" CssClass="form-control">
			<asp:ListItem Text="Sexo" Value="" Selected="True"></asp:ListItem>
			<asp:ListItem Text="M" Value="M"></asp:ListItem>
			<asp:ListItem Text="F" Value="F"></asp:ListItem>
		</asp:DropDownList>
		<%--validacion sexo requerido--%>
		<asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="inputSexo" ErrorMessage="⚠ Seleccione un Sexo" InitialValue="" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>

		<asp:TextBox CssClass="form-control" ID="inputDNI" type="text" placeholder="DNI" runat="server" />
		<div class="form-inline">
			<%--validacion dni requerido--%>
			<asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="inputDNI" ErrorMessage="⚠ Ingrese DNI" ForeColor="pink" Font-Bold="true"/>
			<%--validacion dni solo numeros--%>
			<asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="inputDNI" ValidationExpression="^\d+$" ErrorMessage="⚠ Ingrese solo números" ForeColor="pink" Font-Bold="true"/>
		</div>
		<asp:TextBox CssClass="form-control" ID="inputFechaNacimiento" type="date" placeholder="Fecha de Nacimiento" runat="server" />
		<%--validacion fecha de nacimiento requerido--%>
		<asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="inputFechaNacimiento" ErrorMessage="⚠ Ingrese Fecha de Nacimiento" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
		<asp:TextBox CssClass="form-control" ID="inputTelefono" type="text" placeholder="Teléfono" runat="server" />
		<%--validacion telefono requerido--%>
		<asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="inputTelefono" ErrorMessage="⚠ Ingrese Teléfono" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
		<asp:TextBox CssClass="form-control" ID="inputDireccion" type="text" placeholder="Dirección" runat="server" />
		<%--validacion direccion requerido--%>
		<asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="inputDireccion" ErrorMessage="⚠ Ingrese Dirección" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
		<asp:TextBox CssClass="form-control" ID="inputUsuario" type="text" placeholder="Usuario" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputPassword" type="text" placeholder="Password" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputRePassword" type="text" placeholder="Re Password" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputEmail" type="email" placeholder="Email" runat="server" />


		<%if (!esPaciente)
			{%>
		<asp:CheckBox Text="El Usuario es Medico?" CssClass="" ID="chkMedico"
			runat="server" AutoPostBack="true" OnCheckedChanged="chkMedico_CheckedChanged" />
		<%}%>

		<% if (MedicoElegido && !esPaciente)
			{
		%>

		<asp:TextBox CssClass="form-control" ID="inputMatricula" type="text" placeholder="Matricula" runat="server" />

		<%--marcar casillas para determinar que especialidades tiene el medico--%>
		<p>Marque las especialidades del Médico</p>
		<asp:PlaceHolder ID="loco" runat="server"></asp:PlaceHolder>

		<asp:Button CssClass="btn-submit fixed-size-btn" runat="server" Text="Dar de Alta Medico" OnClick="AltaMedico_Click" />

		<%} %>

		<% if (!MedicoElegido && !esPaciente)

			{
		%>
		<asp:Button CssClass="btn-submit fixed-size-btn" runat="server" Text="Dar de Alta" OnClick="btnSubmit_Click" />

		<% }
			else if (esPaciente)
			{%>
		<asp:Button CssClass="btn-Actualizar fixed-size-btn" ID="btnActualizarPaciente" runat="server" Text="Actualizar Paciente" OnClick="btnActualizarPaciente_Click" /><%

	}%>
	</div>
</asp:Content>

