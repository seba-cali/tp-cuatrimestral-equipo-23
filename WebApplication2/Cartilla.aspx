<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="WebApplication2.Cartilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="mt-5">Cartilla Médica</h1>
        <p>En esta sección podrás encontrar los profesionales que se encuentran disponibles para atenderte.</p>

        <div class="row row-cols-1 row-cols-md-4 g-4">
            <% foreach (Dominio.Especialidad espe in ListaEspecialidades)
               { %>
            <div class="col mb-4">
                <div class="card h-100">
                    <img src="<%:espe.url_img_esp.ToString()%>" class="card-img-top" alt="https://i.imgur.com/oWi25iT.png" style="object-fit: cover">

                    <div class="card-body">
                        <h5 class="card-title"><%:espe.nombre %></h5>
                        <p class="card-text"><%:espe.descripcion %></p>

                        <ul class="list-unstyled">
                            <% foreach (Dominio.EspecialidadxMedico medicoxesp in ListaEspecialidadesxMedico)
                               {
                                   if (medicoxesp.Id_Especialidad == espe.id)
                                   {
                                       foreach (Dominio.Medico medico in ListaMedicos)
                                       {
                                           if (medico.ID_MEDICO == medicoxesp.ID_MEDICO)
                                           { %>
                                                <li><%: $"{medico.nombres} {medico.apellidos} - M.N: {medico.Matricula}" %></li>
                                            <%}
                                       }%>
                                   <%}
                               }%>
                        </ul>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>


