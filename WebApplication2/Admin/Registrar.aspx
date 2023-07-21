<%@ Page Title="Title" Language="C#" MasterPageFile="~/Admin/Panel.Master" CodeBehind="Registrar.aspx.cs" Inherits="WebApplication2.Admin.Registrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div id="layoutAuthentication">
		<div id="layoutAuthentication_content">
			<main>
				<div class="container-xl px-4">
					<div class="row justify-content-center">
						<div class="col-lg-7">
							
							<div class="card shadow-lg border-0 rounded-lg mt-5">
								<div class="card-header justify-content-center">
									<h3 class="fw-light my-4">Crear cuenta</h3>
								</div>
								<div class="card-body">
							
							

										<div class="row gx-3">
											<div class="mb-3">
							
												<div class=" md-6">
													<label class="small mb-1" for="inputDNI">username</label>
													<asp:TextBox CssClass="form-control" ID="inputDNI" type="text" placeholder="username" requerid runat="server" />
												</div>
											</div>
											
										</div>
							
										<div class="mb-3">
											<label class="small mb-1" for="inputCorreo">Correo</label>
											<asp:TextBox CssClass="form-control" ID="inputCorreo" type="email" aria-describedby="emailHelp" requerid placeholder="correo electronico" runat="server" />
										</div>
							
										<div class="row gx-3">
											<div class="col-md-6">
							
												<div class="mb-3">
													<label class="small mb-1" for="inputPassword">Password</label>
													<asp:TextBox CssClass="form-control" ID="inputPassword" type="password" placeholder="Enter password"  requerid runat="server" />
												</div>
											</div>
											<div class="col-md-6">
							
												<div class="mb-3">
													<label class="small mb-1" for="inputConfirmPassword">Confirm Password</label>
													<asp:TextBox CssClass="form-control" ID="inputConfirmPassword" type="password" placeholder="Confirm password" requerid runat="server" />
												</div>
											</div>
										</div>
							
										<asp:Button class="btn btn-primary btn-block" Text="Crear Cuenta" OnClick="btnRegistrarse_Click" runat="server" />
									
								</div>
								<div class="card-footer text-center">
									<div class="small"><a href="Default.aspx">Si ya posee una cuenta, por favor ingrese aquí</a></div>
								</div>
								<%
									if (Session["errorreg"] != null)
									{
								%>
								<div class="alert alert-danger toast" id="toastBasic" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="3000">
									<%: Session["errorreg"] %>
								</div>
								<%
									
									}
									
								%>
							</div>
						</div>
					</div>
				</div>
			</main>
		</div>

	</div>
	<script>
            $(function() {
                         
                            
                                $("#toastBasic").toast("show");
                                });
            </script>
</asp:Content>
