﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;
using ConexionDB;

namespace Negocio
{
	public class NegocioEspecialidad
	{
		public List<Especialidad> listar()
		{
			List<Especialidad> especialidades = new List<Especialidad>();
			DBConnection db = new DBConnection();

			try
			{

				db.setearConsulta("SELECT ID_ESP, NOMBRE, DESCRIPCION FROM ESPECIALIDADES");
				db.ejecutarLectura();

				while (db.Lector.Read())
				{
					Especialidad aux = new Especialidad();
					aux.id = db.Lector.GetInt32(0);
					aux.nombre = db.Lector.GetString(1);
					aux.descripcion = db.Lector.GetString(2);

					especialidades.Add(aux);
				}
				db.cerrarConexion();
				return especialidades;
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
				datos.setearConsulta("DELETE FROM ESPECIALIDADES where ID_ESP = @id");
				datos.setearParametro("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

	}
}