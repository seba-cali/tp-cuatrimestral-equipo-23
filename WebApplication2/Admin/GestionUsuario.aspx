<%@ Page Title="Title" Language="C#" MasterPageFile="Panel.master" CodeBehind="GestionUsuario.aspx.cs" Inherits="WebApplication2.Admin.GestionUsuario" %>

<%@ Import Namespace="Dominio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div id="layoutSidenav_content">
		<main>
			<header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
				<div class="container-fluid px-4">
					<div class="page-header-content">
						<div class="row align-items-center justify-content-between pt-3">
							<div class="col-auto mb-3">
								<h1 class="page-header-title">
									<div class="page-header-icon">
										<i data-feather="users"></i>
									</div>
									Gestion de Usuarios
								</h1>
							</div>
						</div>
					</div>
				</div>
			</header>
			<!-- Main page content-->
			<div class="container-fluid px-4">
				<div class="card">
					<div class="card-body">
						<table id="datatablesSimple">
							<thead>
								<tr>
									<th>id</th>
									<th>Nombre</th>
									<th>DNI</th>
									<th>Correo</th>
									<th>Estado</th>
									<th>Tipo Usuario</th>
									<th>Avatar</th>
									<th>Acciones</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>id</th>
									<th>Nombre</th>
									<th>DNI</th>
									<th>Correo</th>
									<th>Estado</th>
									<th>Tipo Usuario</th>
									<th>Avatar</th>
									<th>Acciones</th>
								</tr>
							</tfoot>
							<tbody>
								<%
									foreach (Usuario tux in ListaUsuarios)
									{
										if (tux.ID_TIPOUSUARIO == 4)
										{
											Paciente pac;
											pac = ListaPacientes.Find(x => x.ID_USUARIO == tux.ID_USUARIO);
											if (pac != null)
											{
								%>
								<tr>
									<td class="esp<%= tux.ID_USUARIO %>"><%: tux.ID_USUARIO %></td>
									<td><%: pac.nombreCompleto %></td>
									<td>
										<%: pac.DNI %>

									</td>
									<td><%: tux.CORREO %></td>
									<td><%= tux.ESTADO ? "Activado" : "Desactivado" %></td>
									<td><%= Usuario.TipoUSUARIO[tux.ID_TIPOUSUARIO] %></td>
									<td><%= tux.img_url %></td>

									<td>
										<a id="<%= tux.ID_USUARIO %>" class="btn btn-datatable btn-icon btn-transparent-dark editar me-2" type="button" data-bs-toggle="modal" data-bs-target="#editGroupModal">
											<i data-feather="edit"></i>
										</a>

									</td>
								</tr>
								<%
										}
									}
									else if (tux.ID_TIPOUSUARIO == 3)
									{
										Medico med;
										med = ListaMedicos.Find(x => x.ID_USUARIO == tux.ID_USUARIO);
										if (med != null)
										{
								%>
								<tr>
									<td class="esp<%= tux.ID_USUARIO %>"><%: tux.ID_USUARIO %></td>
									<td><%: med.NombreCompleto %></td>
									<td>
										<%: med.DNI %>

									</td>
									<td><%: tux.CORREO %></td>
									<td><%= tux.ESTADO ? "Activado" : "Desactivado" %></td>
									<td><%= Usuario.TipoUSUARIO[tux.ID_TIPOUSUARIO] %></td>
									<td><%= tux.img_url %></td>

									<td>
										<a id="<%= tux.ID_USUARIO %>" class="btn btn-datatable btn-icon btn-transparent-dark editar me-2" type="button" data-bs-toggle="modal" data-bs-target="#editGroupModal">
											<i data-feather="edit"></i>
										</a>

									</td>
								</tr>
								<%
										}
									}
									else
									{
								%>
								<tr>
									<td class="esp<%= tux.ID_USUARIO %>"><%: tux.ID_USUARIO %></td>
									<td class="esp<%= tux.ID_TIPOUSUARIO == 1 ? "Administrador" : "Recepcionista" %>"><%: tux.ID_TIPOUSUARIO == 1 ? "Administrador" : "Recepcionista" %></td>
									<td><%: tux.DNI == null ? "" : "algo" %></td>
									<td><%: tux.CORREO %></td>
									<td><%= tux.ESTADO ? "Activado" : "Desactivado" %></td>
									<td><%= Usuario.TipoUSUARIO[tux.ID_TIPOUSUARIO] %></td>
									<td><%= tux.img_url %></td>

									<td>
										<a id="<%= tux.ID_USUARIO %>" class="btn btn-datatable btn-icon btn-transparent-dark editar me-2" type="button" data-bs-toggle="modal" data-bs-target="#editGroupModal">
											<i data-feather="edit"></i>
										</a>

									</td>
								</tr>
								<% }
									}
								%>
							</tbody>
						</table>
					</div>
				</div>
			</div>


			<div class="modal fade" id="editGroupModal" tabindex="-1" role="dialog" aria-labelledby="editGroupModalLabel" aria-hidden="true">
				<div class="modal-dialog" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title" id="editGroupModalLabel">Edit Group</h5>
							<button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
						</div>

						<div class="modal-body">

							<div class="mb-0">
								<label class="mb-1 small text-muted" for="formGroupName">Id</label>
								<h3 class="elementoedit"></h3>
								<asp:TextBox class="form-control formGroupId" ID="Verdura" type="text" ReadOnly="false" runat="server" />
							</div>
							<div class="mb-0">
								<label class="mb-1 small text-muted" for="formGroupName">Nombre</label>
								<asp:TextBox class="form-control formGroupNameEdit" ID="formGroupNameEdit" type="text" ReadOnly="True" placeholder="nombre..." runat="server" />
							</div>
							<div class="mb-0">
								<label class="mb-1 small text-muted" for="formGroupDesc">Descripcion</label>
								<asp:UpdatePanel runat="server">
									<ContentTemplate>
										<asp:DropDownList ID="inputSetUser" runat="server" CssClass="form-control">
											<%--ACA--%>
											<asp:ListItem Text="Rol" Value="" Selected="True"></asp:ListItem>
											<asp:ListItem Text="Admin" Value="1"></asp:ListItem>
											<asp:ListItem Text="Recepcionista" Value="2"></asp:ListItem>
											<asp:ListItem Text="Medico" Value="3"></asp:ListItem>
											<asp:ListItem Text="Paciente" Value="4"></asp:ListItem>
										</asp:DropDownList>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>

							<div class="mb-0">
								<label class="mb-1 small text-muted" for="formGroupURL">Estado</label>
								<asp:UpdatePanel runat="server">
									<ContentTemplate>
										<asp:DropDownList ID="inputEstado" runat="server" CssClass="form-control">
											<%--ACA BAJA LOGICA--%>
											<asp:ListItem Text="Cambiar estado" Value="" Selected="True"></asp:ListItem>
											<asp:ListItem Text="Activo" Value="true"></asp:ListItem>
											<asp:ListItem Text="Desactivado" Value="false"></asp:ListItem>
										</asp:DropDownList>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>


						</div>
						<div class="modal-footer">
							<button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
							<asp:Button ID="Button2" runat="server" Text="Modificar Especialidad" CausesValidation="False" OnClick="Button2_Click" CssClass="btn btn-primary-soft text-primary" />
						</div>

					</div>
				</div>
			</div>
			<%
				if
					 (Session["OK"] != null)
				{
			%>
			<div style="position: absolute; bottom: 1rem; right: 1rem; visibility: <%: Session["OK"] == null ? "hidden" : "visible" %>">
				<!-- Toast -->
				<div class="toast " id="toastBasic" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="3000">
					<div class="toast-header bg-info">
						<i data-feather="bell"></i>
						<strong class="mr-auto">Alerta</strong>
						<small class="text-muted ml-2">Exito:</small>
						<button class="ml-2 mb-1 btn-close" type="button" data-bs-dismiss="toast" aria-label="Close"></button>
					</div>
					<div class="toast-body"><%: Session["OK"] %></div>
				</div>
			</div>
			<% } %>
			<%
				if (Session["error"] != null)
				{
			%>
			<div style="position: absolute; bottom: 1rem; right: 1rem; visibility: <%: Session["error"] == null ? "hidden" : "visible" %>">
				<!-- Toast -->
				<div class="toast " id="toastBasic" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="3000">
					<div class="toast-header bg-info">
						<i data-feather="bell"></i>
						<strong class="mr-auto">Alerta</strong>
						<small class="text-muted ml-2">Error: </small>
						<button class="ml-2 mb-1 btn-close" type="button" data-bs-dismiss="toast" aria-label="Close"></button>
					</div>
					<div class="toast-body"><%: Session["error"] %></div>
				</div>
			</div>
			<% }
				Session["error"] = null;
			%>
		</main>
	</div>
	<script>
		$(function () {


			$("#toastBasic").toast("show");




			$('.editar').on('click', function () {


				var index = $(this).attr('id');
				var indextab = $(this).closest('tr').attr('data-index');
				indextab++
				$('.elementoedit').text(indextab);
				$('.formGroupId').attr('value', index);
				$('.formGroupNameEdit').attr('value', $("#datatablesSimple tbody tr:nth-child( " + indextab + " ) td:nth-child(2)").text());
				$('.formGroupDescEdit').attr('value', $("#datatablesSimple tbody tr:nth-child( " + indextab + " ) td:nth-child(3)").text());
				//$('.formGroupURLEdit').attr('value', $("#datatablesSimple tbody tr:nth-child( " + indextab + " ) td:nth-child(4) img").attr("src"));
				//$('.imagen').attr('src', $("#datatablesSimple tbody tr:nth-child( " + indextab + " ) td:nth-child(4) img").attr("src"));


			});

			$('.delete').on('click', function () {

				var self = $(this);

				var index = self.attr('id');
				$('.formGroupIdDelete').attr('value', index);
				$('.elemento').text(index);

			});
		});

		//elimina el parametro de la url previene el reenvio del formulario
		if (window.history.replaceState) {
			window.history.replaceState(null, null, window.location.href);
		}
	</script>
</asp:Content>
