<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="alta_Medico.aspx.cs" Inherits="WebApplication2.Admin.alta_Medico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .container {
            background-image: url("https://static.vecteezy.com/system/resources/previews/006/712/972/large_2x/abstract-health-medical-science-consist-doctor-digital-wireframe-concept-modern-medical-technology-treatment-medicine-on-blue-background-for-template-web-design-or-presentation-vector.jpg");
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
    <div class="container justify-content-center">
        <h1 style="color: white;">Alta de Medico</h1>
        <asp:Label ID="lblmsg" Text="Cargue los datos del Medico"
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
            <div class="col-3 col-sm-3">
                <asp:TextBox CssClass="form-control" ID="inputMatricula" type="text" placeholder="Matricula" runat="server" />
                <%--validacion matricula requerido--%>
                <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="inputMatricula" ErrorMessage="⚠ Ingrese Matricula" ForeColor="pink" Font-Bold="true"></asp:RequiredFieldValidator>
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
        <div class="row my-3">
            <div class="col-3 my-3">
                <%
                    if (!esMedico)
                    {%>
                <asp:Button runat="server" type="button" Text="Dar de Alta Medico" class="btn btn-primary btn-lg" OnClick="AltaMedico_Click" />
                <%}%>
                <%
                    if (esMedico)
                    {%>
                <asp:Button ID="btnActualizarMedico" type="button" class="btn btn-primary btn-lg" runat="server" Text="Actualizar Medico" OnClick="btnActualizarMedico_Click" />
                <%}%>
            </div>
        </div>
    </div>
</asp:Content>
