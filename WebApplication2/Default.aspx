<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<main>
		<%--Presenta--%>
		<section id="fondo" class="d-flex align-items-center">
			<div class="container">
				<h1>Bienvenido al Sistema de Turnos</h1>
				<h2>Nos destacamos por brindar el mejor servicio</h2>
				<a href="#contact" class="btn-get-started scrollto">Contactanos</a>
			</div>
		</section>

		<%-- Cards --%>
		<section class="vw-100">
			<div class="bg-light vw-100">
				<div class="row justify-content-md-center">
					<div class="col-md-4 col-sm-12 m-2  ">
						<div class="card bg-info">
							<div class="card-header border-0">
								<h3>¿Por Que Elegirnos?</h3>
							</div>
							<div class="card-body border-0">
								<p>
									Somos una empresa seria con años de experiencia en el mercado, brindando el mejor servicio a nuestros clientes.
								</p>
							</div>
						</div>
					</div>
					<div class="col-md-2 col-sm-12 m-1">
						<div class="card">
							<div class="card-header border-0">
								<h3>Medicina</h3>
							</div>
							<div class="card-body border-0">
								<p>
									<span>Nustros profesionales son médicos con gran vocación y pasión por su trabajo.</span>
								</p>
							</div>
						</div>
					</div>
					<div class="col-md-2 col-sm-12 m-1">
						<div class="card">
							<div class="card-header border-0">
								<h3>Laboratorio</h3>
							</div>
							<div class="card-body border-0">
								<p>
									<span>Contamos con un Laboratorio propio, agil en la gestión de muestras.</span>
								</p>
							</div>
						</div>
					</div>
					<div class="col-md-2 col-sm-12 m-1">
						<div class="card">
							<div class="card-header border-0">
								<h3>Enfermeria</h3>
							</div>
							<div class="card-body border-0">
								<p>
									<span>Enfermeria disponible las 24 hs del dia para el cuidado de nuestros pacientes.</span>
								</p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</section>

		<section class="vw-100">
			<div class="container bg-info">
				<div class="row">
					<div class="col-4"><i class="fas fa-users-medical"></i></div>
					<div class="col-4"><i class="fas fa-laptop-medical "></i></div>
					<div class="col-4"><i class="fas fa-clinic-medical "></i></div>
				</div>
				<div class="row">
					<div class="col-4"><i class="fas fa-users-medical fa-pulse"></i></div>
					<div class="col-4"><i class="fas fa-laptop-medical fa-pulse"></i></div>
					<div class="col-4"><i class="fas fa-clinic-medical fa-pulse"></i></div>
				</div>
			</div>
		</section>
		<%--Contact--%>
<%--		<section class="vw-100">
			<div class="bg-light ">
				<div class="container">
					<div class="row mt-5">

						<div class="col-lg-4">
							<div class="info">
								<div class="address">
									<i class="bi bi-geo-alt"></i>
									<h4>Domicilio:</h4>
									<p>Avenida siempre viva</p>
								</div>

								<div class="email">
									<i class="bi bi-envelope"></i>
									<h4>Email:</h4>
									<p>info@clinica.com</p>
								</div>

								<div class="phone">
									<i class="bi bi-phone"></i>
									<h4>Telefono:</h4>
									<p>+0303456</p>
								</div>

							</div>

						</div>

						<div class="col-lg-8 mt-5 mt-lg-0">

							<form method="post" role="form" class="php-email-form">
								<div class="row">
									<div class="col-md-12 form-group">
										<input type="text" name="name" class="form-control" id="name" placeholder="Nombre..." required>
									</div>
									<div class="col-md-12 form-group mt-3 mt-md-0">
										<input type="email" class="form-control" name="email" id="email" placeholder="Email..." required>
									</div>
								</div>
								<div class="col-md-12 form-group mt-3">
									<input type="text" class="form-control" name="subject" id="subject" placeholder="Asunto..." required>
								</div>
								<div class="col-md-12 form-group mt-3">
									<textarea class="form-control" name="message" rows="5" placeholder="Mensaje..." required></textarea>
								</div>
								<div class="my-3">
									<div class="loading">Loading</div>
									<div class="error-message"></div>
									<div class="sent-message">Your message has been sent. Thank you!</div>
								</div>
								<div class="text-center">
									<button type="submit">Enviar Mensaje</button></div>
							</form>

						</div>

					</div>

				</div>

			</div>
		</section>--%>
		<section>
			<div id="preloader"></div>
			<a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>
		</section>
	</main>


</asp:Content>
