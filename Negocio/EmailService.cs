using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Negocio
{
	public class EmailService
	{
		private MailMessage email;
		private SmtpClient server;

		public EmailService()
		{
			server = new SmtpClient();
			//server.Credentials = new NetworkCredential("8f21cfba9301b4", "1e3abbd19c7280");
			server.Credentials = new NetworkCredential("nico.river09.9@gmail.com", "MfOG8dc0FkrZPhAI");
			server.EnableSsl = true;
			server.Port = 587;
			//server.Port = 2525;
			server.Host = "smtp-relay.sendinblue.com";
			//server.Host = "smtp.mailtrap.io";
			//server.Host = "smtp.mailtrap.io";
		}

		public void preparaCorreo(string emailDestino, string asunto, string cuerpo)
		{
			email = new MailMessage();
			email.From = new MailAddress("noresponder@drseba.ar");
			email.To.Add(emailDestino);
			email.Subject = asunto;
			email.IsBodyHtml = true;
			email.Body = cuerpo;
		}

		public void enviarEmail()
		{
			try
			{
				server.Send(email);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
