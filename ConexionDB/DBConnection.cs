using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace ConexionDB
{
	public class DBConnection
	{
		private SqlConnection conexion;
		public SqlCommand comando;
		private SqlDataReader lector;
		public SqlDataReader Lector
		{
			get { return lector; }
		}
		public DBConnection()
		{


			//NICO
			//conexion = new SqlConnection("server=127.0.0.1;database=CLINICA_DB;uid=sa;pwd=Nicosj999@;encrypt=false");


			////ERIK

			conexion = new SqlConnection("server=localhost\\lab3sv;database=CLINICA_DB;uid=sa;pwd=0856;encrypt=false");




			//SEBA
			//conexion = new SqlConnection("server=localhost\\LABO3; database=CLINICA_DB; integrated security = false; user=sa; password=123xx;");


			comando = new SqlCommand();
		}
		public void setearConsulta(string consulta)
		{
			comando.CommandType = System.Data.CommandType.Text;
			comando.CommandText = consulta;
		}
		public void setearProcedimiento(string sp)
		{
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.CommandText = sp;

		}
		public void setearConsultaInt(string consulta)
		{
			comando.CommandType = System.Data.CommandType.Text;
			comando.CommandText = consulta;
		}

		public void ejecutarLectura()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				lector = comando.ExecuteReader();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int ejecutarLecturaInt()
		{

			comando.Connection = conexion;
			try
			{
				conexion.Open();
				return Int32.Parse(comando.ExecuteScalar().ToString());
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool ejecutarAccion()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				comando.ExecuteNonQuery();
				return true;

			}
			catch (Exception ex)
			{
				throw ex;

			}

		}

		public void setearParametro(string nombre, object valor)
		{
			comando.Parameters.AddWithValue(nombre, valor);
		}

		public void cerrarConexion()
		{
			if (lector != null)
				lector.Close();
			conexion.Close();
		}
	}
}