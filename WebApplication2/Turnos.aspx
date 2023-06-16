<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="WebApplication2.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div >
    <div class="row">
    <div class="col-md-12">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs">
          <li class="nav-item">
            <a class="nav-link active" data-bs-toggle="tab" href="#home">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" data-bs-toggle="tab" href="#menu1">Menu 1</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" data-bs-toggle="tab" href="#menu2">Menu 2</a>
          </li>
        </ul>
        
        <!-- Tab panes -->
        <div class="tab-content">
          <div class="tab-pane container  active" id="home">
              <input type="text" class="form-control " placeholder>
          </div>
          <div class="tab-pane container fade" id="menu1">...</div>
          <div class="tab-pane container fade" id="menu2">...</div>
        </div>
    </div>
    </div>
</div>

  
</asp:Content>
