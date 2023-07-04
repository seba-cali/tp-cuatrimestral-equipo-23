using Dominio;
using System.Collections.Generic;
using System;
using ConexionDB;


namespace Negocio
{
	public class NegocioPaciente
	{
		public List<Paciente> listar()
		{
			List<Paciente> paciente = new List<Paciente>();
			DBConnection db = new DBConnection();

			try
			{

				db.setearConsulta("SELECT ID_PACIENTE, NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO, TELEFONO, ID_USUARIO, DNI  FROM PACIENTE");
				db.ejecutarLectura();

				while (db.Lector.Read())
				{
					Paciente aux = new Paciente();
					aux.ID_PACIENTE = db.Lector.GetInt32(0);
					aux.nombres = db.Lector.GetString(1);
					aux.apellidos = db.Lector.GetString(2);
					aux.direccion = db.Lector.GetString(3);
					aux.fechaNacimiento = db.Lector.GetDateTime(4);
					aux.sexo = db.Lector.GetString(5);
					aux.ESTADO = db.Lector.GetBoolean(6);
					aux.telefono = db.Lector.GetString(7);
					aux.ID_USUARIO = db.Lector.GetInt32(8);
					aux.DNI = db.Lector.GetString(9);


					paciente.Add(aux);
				}
				db.cerrarConexion();
				return paciente;
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				db.cerrarConexion();
			}
		}

		public void eliminarPaciente(int id)
		{
			try
			{
				DBConnection datos = new DBConnection();
				datos.setearParametro("@id", id);
				datos.setearConsulta("UPDATE PACIENTE SET ESTADO=0 where ID=@id");
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		public int RegistrarPaciente(Paciente nuevo, int id)
		{
			DBConnection db = new DBConnection();
			try
			{
				Console.WriteLine(id);
				if (id > 0)
				{
					db.setearProcedimiento("ActualizaPaciente");
					db.setearParametro("@Id_Paciente", id);
					db.setearParametro("@nombre", nuevo.nombres);
					db.setearParametro("@apellido", nuevo.apellidos);
					db.setearParametro("@direccion", nuevo.direccion);
					db.setearParametro("@fecha_nacimiento", nuevo.fechaNacimiento);
					db.setearParametro("@sexo", nuevo.sexo);
					db.setearParametro("@estado", nuevo.ESTADO);
					db.setearParametro("@telefono", nuevo.telefono);
					db.setearParametro("@id_Usuario", nuevo.ID_USUARIO);
					db.setearParametro("@DNI", nuevo.DNI);
				}
				else
				{
					db.setearProcedimiento("RegistrarPaciente");
					db.setearParametro("@nombre", nuevo.nombres);
					db.setearParametro("@apellido", nuevo.apellidos);
					db.setearParametro("@direccion", nuevo.direccion);
					db.setearParametro("@fecha_nacimiento", nuevo.fechaNacimiento);
					db.setearParametro("@sexo", nuevo.sexo);
					db.setearParametro("@estado", nuevo.ESTADO);
					db.setearParametro("@telefono", nuevo.telefono);
					db.setearParametro("@id_Usuario", nuevo.ID_USUARIO);
					db.setearParametro("@DNI", nuevo.DNI);
				}
				return db.ejecutarLecturaInt();
			}
			catch (Exception ex)
			{
				Console.WriteLine("error manito");
				throw ex;
			}
			finally
			{
				db.cerrarConexion();
			}

		}
	}
}
