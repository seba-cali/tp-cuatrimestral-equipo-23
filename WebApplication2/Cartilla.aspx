<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="WebApplication2.Cartilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Cartilla Médica</h1>
	<p>En esta sección podrás encontrar los profesionales que se encuentran disponibles para atenderte.</p>


	<div class="row row-cols-1 row-cols-md-3 g-4">

		<%
			foreach (Dominio.Especialidad espe in ListaEspecialidades)
			{
		%>

		<div class="col">
			<div class="card">

				<img src="<%:espe.url_img_esp.ToString()%>" class="card-img-top" alt="..." style="object-fit: cover">

				<div class="card-body">
					<h5 class="card-title"><%:espe.nombre %></h5>
					<p class="card-text"><%:espe.descripcion %></p>
					
				</div>
			</div>
		</div>
		<%	}%>
	</div>

</asp:Content>

