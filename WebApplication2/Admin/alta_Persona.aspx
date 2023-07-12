<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="alta_Persona.aspx.cs" Inherits="WebApplication2.Admin.alta_Persona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<style>
		.container {
			background-image: url("https://i.imgur.com/NS76HWq.jpg");
			/*background-image: url("https://images.pexels.com/photos/281260/pexels-photo-281260.jpeg");*/
			background-repeat: no-repeat;
			background-size: cover;
		}
	</style>

	<div class="container">
		<h1 style="color: white;">Alta de Usuario</h1>


		<asp:Label ID="lblmsg" Text="Cargue los datos del Usuario"
			Style="color: white; font-weight: bold;" runat="server" />
		<div class="row">
			<div class="col-4">
				<asp:TextBox CssClass="form-control" ID="inputNombres" type="text" placeholder="Nombres" runat="server" />
				<asp:RequiredFieldValidator ID="rfvNombres" ControlToValidate="inputNombres" ErrorMessage="⚠ Ingrese sus Nombres." runat="server" ForeColor="pink" Font-Bold="true" />
				<%--//validacion nombres requerido--%>
			</div>
			<div class="col-4">
				<asp:TextBox CssClass="form-control" ID="inputApellidos" type="text" placeholder="Apellidos" runat="server" />
				<asp:RequiredFieldValidator ID="rfvApellidos" ControlToValidate="inputApellidos" ErrorMessage="⚠ Ingrese sus Apellidos." runat="server" ForeColor="pink" Font-Bold="true" />
				<%--//validacion apellidos requerido--%>
			</div>
		</div>
		<div class="row">
			<div class="col-3">
				<asp:TextBox CssClass="form-control" ID="inputDNI" type="text" placeholder="DNI (Usuario)" runat="server" />
				<div class="form-inline">
					<%--validacion dni requerido--%>
					<asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="inputDNI" ErrorMessage="⚠ Ingrese DNI" ForeColor="pink" Font-Bold="true" />
					<%--validacion dni solo numeros--%>
					<asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="inputDNI" ValidationExpression="^\d+$" ErrorMessage="⚠ Ingrese solo números" ForeColor="pink" Font-Bold="true" />
				</div>
			</div>
			<div class="col-2">
				<asp:DropDownList ID="inputSexo" runat="server" CssClass="form-control">
					<asp:ListItem Text="Sexo" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="M" Value="M"></asp:ListItem>
					<asp:ListItem Text="F" Value="F"></asp:ListItem>
				</asp:DropDownList>
				<%--validacion sexo requerido--%>
				<asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="inputSexo" ErrorMessage="⚠ Seleccione un Sexo" InitialValue="" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
			</div>
		</div>
		<div class="row">
			<div class="col-3">
				<asp:TextBox CssClass="form-control" ID="inputFechaNacimiento" type="date" placeholder="Fecha de Nacimiento" runat="server" />
				<%--validacion fecha de nacimiento requerido--%>
				<asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="inputFechaNacimiento" ErrorMessage="⚠ Ingrese Fecha de Nacimiento" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
			</div>
		</div>
		<div class="row">
			<div class="col-4">

				<asp:TextBox CssClass="form-control" ID="inputDireccion" type="text" placeholder="Dirección" runat="server" />
				<%--validacion direccion requerido--%>
				<asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="inputDireccion" ErrorMessage="⚠ Ingrese Dirección" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
			</div>
			<div class="col-4">
				<asp:TextBox CssClass="form-control" ID="inputTelefono" type="text" placeholder="Teléfono" runat="server" />
				<%--validacion telefono requerido--%>
				<asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="inputTelefono" ErrorMessage="⚠ Ingrese Teléfono" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
			</div>
		</div>

		<%--<div class="row">--%>
		<%--<div class="col-4">--%>
		<%--<asp:TextBox CssClass="form-control" ID="inputUsuario" type="text" placeholder="Usuario" runat="server" />--%>
		<%--validacion usuario requerido--%>
		<%--<asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="inputUsuario" ErrorMessage="⚠ Ingrese Usuario" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>--%>
		<%--hacer que el usuario sea unico y ademas, que sea igual al DNI--%>
		<%--<asp:CompareValidator ID="cvUsuario" runat="server" ControlToCompare="inputDNI" ControlToValidate="inputUsuario" ErrorMessage="⚠ El Usuario debe ser igual al DNI" ForeColor="pink" Font-Bold="true"></asp:CompareValidator>--%>
		<%--</div>--%>
		<%--</div>--%>
		<div class="row">
			<div class="col-4">

				<asp:TextBox CssClass="form-control" ID="inputPassword" type="password" placeholder="Password" runat="server" />
				<%--validacion password requerido--%>
				<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="inputPassword" ErrorMessage="⚠ Ingrese Password" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
			</div>
			<div class="col-4">
				<asp:TextBox CssClass="form-control" ID="inputRePassword" type="password" placeholder="Re Password" runat="server" />
				<%--validacion repassword requerido--%>
				<asp:RequiredFieldValidator ID="rfvRePassword" runat="server" ControlToValidate="inputRePassword" ErrorMessage="⚠ Repita Password" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
				<%--validacion repassword igual a password--%>
				<asp:CompareValidator ID="cvRePassword" runat="server" ControlToCompare="inputPassword" ControlToValidate="inputRePassword" ErrorMessage="⚠ Password no coincide" ForeColor="pink" Font-Bold="true"></asp:CompareValidator>
			</div>
		</div>
		<div class="row">

			<div class="col-4">
				<asp:TextBox CssClass="form-control" ID="inputEmail" type="email" placeholder="Email" runat="server" />
				<%--validacion email requerido--%>
				<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="inputEmail" ErrorMessage="⚠ Ingrese Email" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
			</div>
		</div>

		<div class="row my-4">


			<%if (!esPaciente)
				{%>
			<div class="col-3 ">
				<asp:CheckBox Text="El Usuario es Medico?" class="form-check-label text-light" ID="chkMedico"
					runat="server" AutoPostBack="true" OnCheckedChanged="chkMedico_CheckedChanged" />

			</div>
			<%}%>
		</div>
		<% if (MedicoElegido && !esPaciente)
			{
		%>
		<div class="row">
			<div class="col-6 col-sm-3">
				<asp:TextBox CssClass="form-control" ID="inputMatricula" type="text" placeholder="Matricula" runat="server" />
				<%--validacion matricula requerido--%>
				<asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="inputMatricula" ErrorMessage="⚠ Ingrese Matricula" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>



			</div>

			<%//TODO: Comento esto si es que las relaciones de horarios laborales se hacen en otro lado%>
			<%--			<div class="col-3 col-sm-3">

				<asp:ListBox CssClass="form-control" ID="horarios" runat="server" AutoPostBack="false">
					<asp:ListItem Text="Turnos 6 a 13Hs" Value="0" />
					<asp:ListItem Text="Turnos 13 a 18Hs" Value="1" />
					<asp:ListItem Text="Turnos 18 a 23Hs" Value="2" />
				</asp:ListBox>

			</div>--%>
		</div>

		<div class="row">
<%--			<div class="col-4">
				<asp:Label ID="espMed" Text="Elija las especialidades del medico"
					Style="color: white; font-weight: bold;" runat="server" />

				<asp:PlaceHolder ID="loco" runat="server"></asp:PlaceHolder>
			</div>--%>
			<div class="row my-5">
				<div class="col-3">
					<asp:Button runat="server" type="button" Text="Dar de Alta Medico" class="btn btn-primary btn-lg" OnClick="AltaMedico_Click" />
				</div>
			</div>
		</div>
		<%} %>

		<div class="row my-5">
			<div class="col-3">

				<% if (!MedicoElegido && !esPaciente)

					{
				%>
				<asp:Button runat="server" type="button" class="btn btn-primary btn-lg" Text="Dar de Alta" OnClick="btnSubmit_Click" />

				<% }
					else if (esPaciente)
					{%>
				<asp:Button ID="btnActualizarPaciente" type="button" class="btn btn-primary btn-lg" runat="server" Text="Actualizar Paciente" OnClick="btnActualizarPaciente_Click" /><%

		}%>
			</div>
		</div>
	</div>


</asp:Content>

