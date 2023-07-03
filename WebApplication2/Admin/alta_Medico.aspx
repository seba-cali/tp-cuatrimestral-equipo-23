<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="alta_Medico.aspx.cs" Inherits="WebApplication2.Admin.alta_Medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<div class="cotainer">
		<h1>Alta de Médico</h1>
		<h4>Ingrese los datos del Médico</h4>
<%--		CREATE TABLE MEDICO(
                       ID_MEDICO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                       NOMBRE VARCHAR(50) NOT NULL,
                       APELLIDO VARCHAR(50) NOT NULL,
                       DIRECCION VARCHAR(50) NOT NULL,
                       FECHA_NACIMIENTO DATE NOT NULL,
                       SEXO VARCHAR(20) NOT NULL,
                       ESTADO BIT NOT NULL,
                       TELEFONO VARCHAR(20) NOT NULL,
                       ID_ESP INT NOT NULL FOREIGN KEY REFERENCES ESPECIALIDADES(ID_ESP),
                       ID_USUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIO(ID_USUARIO),
);--%>
      <asp:TextBox CssClass="form-control" ID="inputMedName" type="text" placeholder="Nombres" runat="server"  ></asp:TextBox>
<asp:TextBox CssClass="form-control" ID="inputMedLastName" type="text" placeholder="Apellidos" runat="server" ></asp:TextBox>
<asp:TextBox CssClass="form-control" ID="inputMedAddress" type="text" placeholder="Dirección" runat="server" ></asp:TextBox>
<asp:TextBox CssClass="form-control" ID="inputMedBirthDate" type="date" placeholder="Fecha de Nacimiento" runat="server" ></asp:TextBox>
<div class="radio-container">
        <label for="rb_Masculino">Sexo:</label>
        <asp:RadioButton ID="rb_Masculino" runat="server" Text="Masculino" GroupName="gender" />
        <asp:RadioButton ID="rb_Femenino" runat="server" Text="Femenino" GroupName="gender" />
    </div>

<asp:TextBox CssClass="form-control" ID="inputMedPhone" type="text" placeholder="Teléfono" runat="server" ></asp:TextBox>
<asp:DropDownList CssClass="form-control" ID="inputMedSpec" runat="server" ></asp:DropDownList>
<asp:DropDownList CssClass="form-control" ID="inputMedUser" runat="server" ></asp:DropDownList>
<asp:Button CssClass="btn btn-primary" ID="btnAltaMed" runat="server" Text="Alta" OnClick="btnAltaMed_Click" />


	</div>
</asp:Content>
