<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="WebApplication2.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
    <div class="tab-content" id="myTabContent">
        <div class="tab-pane fade show active" id="MisTurnos" role="tabpanel" aria-labelledby="MisTurnos-tab">Seba</div>
        <div class="tab-pane fade" id="NuevoTurno" role="tabpanel" aria-labelledby="NuevoTurno-tab">

           
  <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Email</label>
    <input type="email" class="form-control" id="inputEmail4">
  </div>
  <div class="col-md-6">
    <label for="inputPassword4" class="form-label">Password</label>
    <input type="password" class="form-control" id="inputPassword4">
  </div>
  <div class="col-12">
    <label for="inputAddress" class="form-label">Address</label>
    <input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St">
  </div>
  <div class="col-12">
    <label for="inputAddress2" class="form-label">Address 2</label>
    <input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor">
  </div>
  <div class="col-md-6">
    <label for="inputCity" class="form-label">City</label>
    <input type="text" class="form-control" id="inputCity">
  </div>
  <div class="col-md-4">
    <label for="inputState" class="form-label">State</label>
    <select id="inputState" class="form-select">
      <option selected>Choose...</option>
      <option>...</option>
    </select>
  </div>
  <div class="col-md-2">
    <label for="inputZip" class="form-label">Zip</label>
    <input type="text" class="form-control" id="inputZip">
  </div>
  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" id="gridCheck">
      <label class="form-check-label" for="gridCheck">
        Check me out
      </label>
    </div>
  </div>
  <div class="col-12">
    <button type="submit" class="btn btn-primary">Sign in</button>
  </div>



        </div>
        <div class="tab-pane fade" id="Estudios" role="tabpanel" aria-labelledby="Estudios-tab">1234</div>
    </div>


</asp:Content>
