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
			background-image: url("https://i.imgur.com/a4UOksY.jpg");
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
			flex-direction: row;
		}

			.inline-checkboxes .form-check {
				margin-right: 10px;
				margin-bottom: 10px;
			}

		.fixed-size-btn {
			width: 200px; /* Ajusta el tamaño según tus necesidades */
			height: 40px; /* Ajusta el tamaño según tus necesidades */
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

		<%--marcar casillas para determinar que especialidades tiene el medico--%>
		<p>Marque las especialidades del Médico</p>

		<%
			int contador = 0;
			foreach (Dominio.Especialidad espe in ListaEspecialidades)
			{
				if (contador % 6 == 0)
				{
					if (contador > 0)
					{
		%>
	</div>
	<%
		}
	%><div class="row">
		<%
			}
		%>
		<div class="col-md-2">
			<div class="inline-checkboxes">
				<div class="form-check form-switch">
					<input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault<%=contador+1%>">
					<label class="form-check-label" for="flexSwitchCheckDefault<%=contador+1%>"><%:espe.nombre %></label>
				</div>
			</div>
		</div>
		<%    
				contador++;
			}
		%>
		<% 
			// Cierre final de la etiqueta </div> si es necesario
			if (contador > 0 && contador % 6 != 0)
			{
		%>
	</div>
	<%
		}
	%>

	<%--		<div class="form-check form-switch"> XXX ESTO ES PARA QUE NAZCA YA CHECKEADO
			<input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckChecked" checked>
			<label class="form-check-label" for="flexSwitchCheckChecked">Checked switch checkbox input</label>
		</div>--%>

	<%--		<div class="form-check form-switch">  XXX ESTO ES PARA TENER ALGUNO DISABLEADO
			<input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckCheckedDisabled" checked disabled>
			<label class="form-check-label" for="flexSwitchCheckCheckedDisabled">Disabled checked switch checkbox input</label>
		</div>--%>

	<%--generar el evento onclick para el boton submit--%>

	<asp:Button CssClass="btn-submit fixed-size-btn" ID="btnSubmit" runat="server" Text="Dar de Alta" />
</asp:Content>

