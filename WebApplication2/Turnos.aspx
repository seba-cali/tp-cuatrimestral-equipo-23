<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="WebApplication2.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container">
  <div class="row">
    <div class="col-9">.col-9........................................................................................................................................</div>
    <div class="col-4">.col-4<br>Since 9 + 4 = 13 &gt; 12, this 4-column-wide div gets wrapped onto a new line as one contiguous unit.</div>
    <div class="col-6">.col-6<br>Subsequent columns continue along the new line.</div>
  </div>
</div>

            <div class="container">
  <div class="row">
    <div class="col">
      First in DOM, no order applied
    </div>
    <div class="col order-5">
      Second in DOM, with a larger order
    </div>
    <div class="col order-1">
      Third in DOM, with an order of 1
    </div>
  </div>
</div>
            <div class="container">
  <div class="row">
    <div class="col-md-4">.col-md-4</div>
    <div class="col-md-4 ms-auto">.col-md-4 .ms-auto</div>
  </div>
  <div class="row">
    <div class="col-md-3 ms-md-auto">.col-md-3 .ms-md-auto</div>
    <div class="col-md-3 ms-md-auto">.col-md-3 .ms-md-auto</div>
  </div>
  <div class="row">
    <div class="col-auto me-auto">.col-auto .me-auto</div>
    <div class="col-auto">.col-auto</div>
  </div>
</div>
    
            <div class="container">
                <div class="row">
                  
                        <div class="col-9">

                            <asp:TextBox runat="server" ID="TextBox1" AutoPostBack="true" CssClass="form-control w-100"  placeholder="---Obra Social---" />
                        </div>
                  
                </div>
            </div>

                    <div class="row">
                        <div class="col-3">
                            <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" CssClass="form-control" placeholder="Especialidad" OnTextChanged="txtEspecialidad_TextChanged" />

                        </div>
                        <div class="col-2">
                            <asp:TextBox runat="server" ID="TextBox2" AutoPostBack="true" CssClass="form-control" placeholder="Medico" />
                    </div>

                        </div>

                        <div class="col">
                            <asp:TextBox runat="server" ID="TextBox3" AutoPostBack="true" CssClass="form-control" placeholder="Fecha" />
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="TextBox4" AutoPostBack="true" CssClass="form-control" placeholder="Hora" />
                        </div>

    <ul class="nav nav-tabs justify-content-center" id="myTab" role="tablist">
        <li class="nav-item" role="presentation">
            <button class="nav-link active" id="MisTurnos-tab" data-bs-toggle="tab" data-bs-target="#MisTurnos" type="button" role="tab" aria-controls="Misturnos" aria-selected="true">Mis Turnos</button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="NuevoTurno-tab" data-bs-toggle="tab" data-bs-target="#NuevoTurno" type="button" role="tab" aria-controls="NuevoTurno" aria-selected="false">Nuevo Turno</button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="Estudios-tab" data-bs-toggle="tab" data-bs-target="#Estudios" type="button" role="tab" aria-controls="Estudios" aria-selected="false">Estudios</button>
        </li>
    </ul>
    <div class="tab-content " id="myTabContent">
        <div class="tab-pane fade show active" id="MisTurnos" role="tabpanel" aria-labelledby="MisTurnos-tab">Seba</div>
        <div class="tab-pane fade" id="NuevoTurno" role="tabpanel" aria-labelledby="NuevoTurno-tab">

            <div class="container">
  <div class="row">
    <div class="col-9">.col-9........................................................................................................................................</div>
    <div class="col-4">.col-4<br>Since 9 + 4 = 13 &gt; 12, this 4-column-wide div gets wrapped onto a new line as one contiguous unit.</div>
    <div class="col-6">.col-6<br>Subsequent columns continue along the new line.</div>
  </div>
</div>

            <div class="container">
  <div class="row">
    <div class="col">
      First in DOM, no order applied
    </div>
    <div class="col order-5">
      Second in DOM, with a larger order
    </div>
    <div class="col order-1">
      Third in DOM, with an order of 1
    </div>
  </div>
</div>
            <div class="container">
  <div class="row">
    <div class="col-md-4">.col-md-4</div>
    <div class="col-md-4 ms-auto">.col-md-4 .ms-auto</div>
  </div>
  <div class="row">
    <div class="col-md-3 ms-md-auto">.col-md-3 .ms-md-auto</div>
    <div class="col-md-3 ms-md-auto">.col-md-3 .ms-md-auto</div>
  </div>
  <div class="row">
    <div class="col-auto me-auto">.col-auto .me-auto</div>
    <div class="col-auto">.col-auto</div>
  </div>
</div>

            <div class="container">
                <div class="row">
                  
                        <div class="col-9">

                            <asp:TextBox runat="server" ID="txtObraSocial" AutoPostBack="true" CssClass="form-control w-100"  placeholder="---Obra Social---" />
                        </div>
                  
                </div>
            </div>

                    <div class="row">
                        <div class="col-3">
                            <asp:DropDownList runat="server" ID="txtEspecialidad" AutoPostBack="true" CssClass="form-control" placeholder="Especialidad" OnTextChanged="txtEspecialidad_TextChanged" />

                        </div>
                        <div class="col-2">
                            <asp:TextBox runat="server" ID="txtMedico" AutoPostBack="true" CssClass="form-control" placeholder="Medico" />
                    </div>

                        </div>

                        <div class="col">
                            <asp:TextBox runat="server" ID="txtFecha" AutoPostBack="true" CssClass="form-control" placeholder="Fecha" />
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtHora" AutoPostBack="true" CssClass="form-control" placeholder="Hora" />
                        </div>
        </div>
        </div>
            <div class="tab-pane fade" id="Estudios" role="tabpanel" aria-labelledby="Estudios-tab">1234</div>
  
</asp:Content>
