using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
using System.Reflection;

namespace Negocio
{
	public class NegocioEspecialidadxMedico
	{

		public List<EspecialidadxMedico> listar(string idEsp = "")
		{
			List<EspecialidadxMedico> especialidadesxmedico = new List<EspecialidadxMedico>();
			DBConnection db = new DBConnection();

			try
			{
				if (idEsp == "")
				{
					db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD,turno_horario FROM EspecialidadxMedico");
				}
				else
				{
					db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD, turno_horario FROM EspecialidadxMedico where ID_ESPECIALIDAD = " + idEsp);
				}
				db.ejecutarLectura();

				while (db.Lector.Read())
				{
					EspecialidadxMedico aux = new EspecialidadxMedico();
					aux.ID_MEDICO = db.Lector.GetInt32(0);
					aux.Id_Especialidad = db.Lector.GetInt32(1);
					aux.Turno_Horario = db.Lector.GetInt32(2);


					especialidadesxmedico.Add(aux);
				}
				db.cerrarConexion();
				return especialidadesxmedico;
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

        public List<EspecialidadxMedico> listarxMedico(string idMed = "")
        {
            List<EspecialidadxMedico> especialidadesxmedico = new List<EspecialidadxMedico>();
            DBConnection db = new DBConnection();

            try
            {
                if (idMed == "")
                {
                    db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD,turno_horario,Atiende_Lunes,Atiende_Martes, Atiende_Miercoles, Atiende_Jueves, Atiende_Viernes, Atiende_Sabado, Atiende_Domingo FROM EspecialidadxMedico");
                }
                else
                {
                    db.setearConsulta("SELECT E.ID_MEDICO, CONCAT_WS(', ', M.Nombre, M.Apellido) as Medico, E.ID_ESPECIALIDAD, Es.nombre as Especialidad, E.Turno_Horario, E.Atiende_Lunes, E.Atiende_Martes, E.Atiende_Miercoles, E.Atiende_Jueves, E.Atiende_Viernes, E.Atiende_Sabado, E.Atiende_Domingo FROM EspecialidadxMedico as E inner join Medico as M on E.ID_MEDICO = M.ID_MEDICO  inner join Especialidades as Es on E.ID_ESPECIALIDAD = Es.ID_ESP where E.ID_MEDICO = " + idMed);
                }
                db.ejecutarLectura();
                while (db.Lector.Read())
                {
                    EspecialidadxMedico aux = new EspecialidadxMedico();
                    aux.ID_MEDICO = db.Lector.GetInt32(0);
                    aux.Id_Especialidad = db.Lector.GetInt32(2);
                    aux.Name = db.Lector.GetString(1);
                    aux.Especialidad = db.Lector.GetString(3);
                    aux.Turno_Horario = db.Lector.GetInt32(4);
                    aux.Atiende_Lunes = db.Lector.GetBoolean(5);
					aux.Atiende_Martes = db.Lector.GetBoolean(6);
					aux.Atiende_Miercoles = db.Lector.GetBoolean(7);
					aux.Atiende_Jueves = db.Lector.GetBoolean(8);
					aux.Atiende_Viernes = db.Lector.GetBoolean(9);
					aux.Atiende_Sabado = db.Lector.GetBoolean(10);
					aux.Atiende_Domingo = db.Lector.GetBoolean(11);



                    especialidadesxmedico.Add(aux);
                }
                db.cerrarConexion();
                return especialidadesxmedico;
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


        public void eliminarfisico(int idmedico, int idespecialidad, int turno)
		{
			try
			{
				DBConnection datos = new DBConnection();
				datos.setearConsulta("DELETE FROM EspecialidadxMedico where ID_MEDICO = @idmedico and ID_ESPECIALIDAD = @idespecialidad and Turno_Horario = @turnohorario");
				datos.setearParametro("@idmedico", idmedico);
				datos.setearParametro("@idespecialidad", idespecialidad);
				datos.setearParametro("@turnohorario", turno);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}



		public void RegistrarEspecialidadxMedico(EspecialidadxMedico nuevo)
		{


			DBConnection db = new DBConnection();
			try
			{

				db.setearProcedimiento("RegistrarEspecialidadxMedico");
				db.setearParametro("@idmedico", nuevo.ID_MEDICO);
				db.setearParametro("@idespecialidad", nuevo.Id_Especialidad);
				db.setearParametro("@Turno", nuevo.Turno_Horario);

				db.ejecutarLectura();

			}

			catch (Exception ex)
			{
				Console.WriteLine("error manito");
				Console.WriteLine(ex.ToString());
				throw ex;


			}
			finally
			{
				db.cerrarConexion();
			}

		}

        public void reactivarDia(string dia, int idMed, int idEsp, int Turno)
        {
            try
            {
                DBConnection datos = new DBConnection();
                datos.setearParametro("@id", idMed);
				datos.setearParametro("@idesp", idEsp);
				datos.setearParametro("@turno", Turno);
                datos.setearConsulta("UPDATE EspecialidadxMedico SET "+dia+"=1 where ID_MEDICO=@id and ID_ESPECIALIDAD=@idEsp and turno_horario=@turno");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesactivarDia(string dia, int idMed, int idEsp, int Turno)
        {
            try
            {
                DBConnection datos = new DBConnection();
                datos.setearParametro("@id", idMed);
                datos.setearParametro("@idesp", idEsp);
                datos.setearParametro("@turno", Turno);
                datos.setearConsulta("UPDATE EspecialidadxMedico SET " + dia + "=0 where ID_MEDICO=@id and ID_ESPECIALIDAD=@idEsp and turno_horario=@turno");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
