using System;
using System.Collections.Generic;
using ConexionDB;
using Dominio;

namespace Negocio
{
	public class NegocioUsuario
	{

		public Usuario login(Usuario usuario)
		{
			DBConnection db = new DBConnection();
			Usuario aux = new Usuario();
			try
			{
				db.setearConsulta(
					"SELECT ID_USUARIO, USERNAME, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO, IMG_URL FROM USUARIO WHERE USERNAME= @username AND PASSWORD = @password");
				db.setearParametro("@username", usuario.username);
				db.setearParametro("@password", usuario.PASSWORD);
				db.ejecutarLectura();

				if (db.Lector.Read())
				{
					usuario.ID_USUARIO = db.Lector.GetInt32(0);
					usuario.username = db.Lector.GetString(1);
					usuario.PASSWORD = db.Lector.GetString(2);
					usuario.CORREO = db.Lector.GetString(3);
					usuario.ESTADO = db.Lector.GetBoolean(4);
					usuario.ID_TIPOUSUARIO = db.Lector.GetInt32(5);
					usuario.img_url = db.Lector.GetString(6);
					db.cerrarConexion();
					return usuario;
				}
				else
				{
					db.cerrarConexion();
					return null;
				}
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

		public List<Usuario> listar(string idUsuario = "")
		{
			List<Usuario> usuario = new List<Usuario>();
			DBConnection db = new DBConnection();

			try
			{
				if (idUsuario != "")
				{
					db.setearConsulta(
						"SELECT ID_USUARIO, USERNAME, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO,IMG_URL FROM USUARIO where ID_USUARIO = " +
						idUsuario);
				}
				else
				{
					db.setearConsulta(
						"SELECT ID_USUARIO, USERNAME, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO,IMG_URL FROM USUARIO");
				}

				db.ejecutarLectura();



				while (db.Lector.Read())
				{
					Usuario aux = new Usuario();
					aux.ID_USUARIO = db.Lector.GetInt32(0);
					aux.username = db.Lector.GetString(1);
					aux.PASSWORD = db.Lector.GetString(2);
					aux.CORREO = db.Lector.GetString(3);
					aux.ESTADO = db.Lector.GetBoolean(4);
					aux.ID_TIPOUSUARIO = db.Lector.GetInt32(5);
					aux.img_url = db.Lector.GetString(6);
					usuario.Add(aux);
				}

				db.cerrarConexion();
				return usuario;
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

		public void eliminar(int id)
		{
			try
			{
				DBConnection datos = new DBConnection();
				datos.setearConsulta("DELETE FROM USUARIO where ID_USUARIO = @id");
				datos.setearParametro("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public Usuario BuscarXId(int val)
		{
			DBConnection db = new DBConnection();
			Usuario aux = new Usuario();
			try
			{
				db.setearConsulta(
					"SELECT ID_USUARIO, USERNAME, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO,IMG_URL FROM USUARIO WHERE ID_USUARIO= @id");
				db.setearParametro("@id", val);
				db.ejecutarLectura();
				if (db.Lector.Read())
				{
					aux.ID_USUARIO = db.Lector.GetInt32(0);
					aux.username = db.Lector.GetString(1);
					aux.PASSWORD = db.Lector.GetString(2);
					aux.CORREO = db.Lector.GetString(3);
					aux.ESTADO = db.Lector.GetBoolean(4);
					aux.ID_TIPOUSUARIO = db.Lector.GetInt32(5);
					aux.img_url = db.Lector.GetString(6);
					db.cerrarConexion();
					return aux;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return null;
		}

		public void BuscarXIdUpdate(int val, string password)
		{
			DBConnection db = new DBConnection();
			try
			{
				db.setearConsulta("UPDATE USUARIO SET PASSWORD = @password  WHERE ID_USUARIO= @id");
				db.setearParametro("@id", val);
				db.setearParametro("@password", password);
				db.ejecutarLectura();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public int RegistrarUsuario(Usuario nuevo, int id = 0)
		{
			DBConnection db = new DBConnection();
			try
			{
				if (id > 0)
				{
					db.setearProcedimiento("ActualizarUsuario");
					db.setearParametro("@Id_Usuario", id);
					db.setearParametro("@username", nuevo.username);
					db.setearParametro("@correo", nuevo.CORREO);
					db.setearParametro("@password", nuevo.PASSWORD);
					db.setearParametro("@estado", 1);
					db.setearParametro("@tipoUsuario", nuevo.ID_TIPOUSUARIO);
					db.ejecutarLectura();
					return 0;
				}
				else
				{
					db.setearProcedimiento("RegistrarUsuario");
					db.setearParametro("@username", nuevo.username);
					db.setearParametro("@correo", nuevo.CORREO);
					db.setearParametro("@password", nuevo.PASSWORD);
					db.setearParametro("@estado", 1);
					db.setearParametro("@tipoUsuario", nuevo.ID_TIPOUSUARIO);
					return db.ejecutarLecturaInt();
				}
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


		public void updateImg(Usuario usuario)
		{
			DBConnection db = new DBConnection();
			try
			{

				db.setearConsulta("UPDATE USUARIO SET IMG_URL=@imagen WHERE ID_USUARIO = @id");
				db.setearParametro("@id", Convert.ToInt32(usuario.ID_USUARIO));
				db.setearParametro("@imagen", usuario.img_url ?? DBNull.Value.ToString());
				db.ejecutarLectura();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				db.cerrarConexion();
			}


		}

		public void bajaLogica(int id, bool estado)
		{
			DBConnection db = new DBConnection();
			try
			{

				db.setearConsulta("UPDATE USUARIO SET ESTADO = @estado WHERE ID_USUARIO = @id");
				db.setearParametro("@id", id);
				db.setearParametro("@estado", estado ? 1 : 0); // 1 si estado es true (activado), 0 si estado es false (desactivado)
				db.ejecutarLectura(); // Ejecutar el UPDATE

			}
			catch (Exception ex)
			{


				throw ex;
			}
			finally
			{
				db.cerrarConexion();
			}



		}

		public void cambiarRol(int id, int nuevoRolId)
		{
			DBConnection db = new DBConnection();
			try
			{
				NegocioUsuario negocioUsuario = new NegocioUsuario();
				Usuario usuarioActual = negocioUsuario.BuscarXId(id);

				if (usuarioActual != null)
				{
					// Si el nuevoRolId es diferente del rol actual del usuario, entonces actualizar el rol
					if (nuevoRolId != usuarioActual.ID_TIPOUSUARIO)
					{
						db.setearConsulta("UPDATE USUARIO SET ID_TIPOUSUARIO = @nuevoRolId WHERE ID_USUARIO = @id");
						db.setearParametro("@id", id);
						db.setearParametro("@nuevoRolId", nuevoRolId);
						db.ejecutarLectura(); // Ejecutar el UPDATE
					}
				}
				else
				{
					// Mostrar mensaje de error: "No se encontró el usuario con el ID especificado."
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				db.cerrarConexion();
			}
		}
	}
}