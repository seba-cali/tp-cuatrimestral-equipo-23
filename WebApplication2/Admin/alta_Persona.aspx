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
	</style>

	<div class="container">
		<h1>Alta de Persona</h1>
		<h4>Seleccione si la Persona a dar de alta es Médico o Paciente</h4>

		<select class="form-select" aria-label="...">
			<option selected>Paciente o Médico?</option>
			<option value="1">Paciente</option>
			<option value="2">Médico</option>
		</select>

		<p>Ingrese los datos de la Persona</p>

		<asp:TextBox CssClass="form-control" ID="inputNombres" type="text" placeholder="Nombres" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputApellidos" type="text" placeholder="Apellidos" runat="server" />

		<select class="form-select" aria-label="Sexo">
			<option selected>Sexo</option>
			<option value="1">M</option>
			<option value="2">F</option>
			<option value="3">NoBooleano</option>
		</select>

		<asp:TextBox CssClass="form-control" ID="inputDNI" type="text" placeholder="DNI" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputFechaNacimiento" type="date" placeholder="Fecha de Nacimiento" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputTelefono" type="text" placeholder="Teléfono" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputEmail" type="email" placeholder="Email" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputDireccion" type="text" placeholder="Dirección" runat="server" />

		<%--generar el evento onclick para el boton submit--%>

		<asp:Button CssClass="btn-submit" ID="btnSubmit" runat="server" Text="Dar de Alta" />
	</div>
</asp:Content>

