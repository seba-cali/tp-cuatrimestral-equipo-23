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
		<h4>Seleccione si la Persona a dar de alta es Médico o Paciente</h4>

		<select class="form-select" aria-label="...">
			<option selected>Paciente o Médico?</option>
			<option value="1">Paciente</option>
			<option value="2">Médico</option>
		</select>

		<p>Ingrese los datos de la Persona</p>

		<asp:TextBox CssClass="form-control" ID="inputNombres" type="text" placeholder="Nombres" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputApellidos" type="text" placeholder="Apellidos" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputUsuario" type="text" placeholder="Usuario" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputPassword" type="text" placeholder="Password" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputRePassword" type="text" placeholder="Re PAssword" runat="server" />

		<asp:DropDownList ID="inputSexo" runat="server" CssClass="form-control">
		<asp:ListItem Text="Sexo" Value="" Selected="True"></asp:ListItem>
		<asp:ListItem Text="M" Value="1"></asp:ListItem>
		<asp:ListItem Text="F" Value="2"></asp:ListItem>
		</asp:DropDownList>

		<asp:TextBox CssClass="form-control" ID="inputDNI" type="text" placeholder="DNI" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputFechaNacimiento" type="date" placeholder="Fecha de Nacimiento" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputTelefono" type="text" placeholder="Teléfono" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputEmail" type="email" placeholder="Email" runat="server" />
		<asp:TextBox CssClass="form-control" ID="inputDireccion" type="text" placeholder="Dirección" runat="server" />

		<%--marcar casillas para determinar que especialidades tiene el medico--%>
		<p>Marque las especialidades del Médico</p>

		        <div class="inline-checkboxes">
            <% 
				int contador = 0;
				foreach (Dominio.Especialidad espe in ListaEspecialidades)
				{
            %>
            <div class="form-check form-switch">
	            <asp:CheckBox CssClass="form-check-input" runat="server"/>
                <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault<%=contador+1%>">
                <label class="form-check-label" for="flexSwitchCheckDefault<%=contador+1%>"><%:espe.nombre %></label>
            </div>
            <%    
                    contador++;
                }
            %>
        </div>


        <asp:Button CssClass="btn-submit fixed-size-btn"  runat="server" Text="Dar de Alta" OnClick="Button1_Click" />

    </div>
</asp:Content>

