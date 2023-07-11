using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
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
                    db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD FROM EspecialidadxMedico");
                }
                else
                {
                    db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD FROM EspecialidadxMedico where ID_ESPECIALIDAD = " + idEsp);
                }

                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    EspecialidadxMedico aux = new EspecialidadxMedico();
                    aux.ID_MEDICO = db.Lector.GetInt32(0);
                    aux.Id_Especialidad = db.Lector.GetInt32(1);


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

        public List<EspecialidadxMedico> listarconsulta(string idEsp = "")
        {
            List<EspecialidadxMedico> especialidadesxmedico = new List<EspecialidadxMedico>();
            DBConnection db = new DBConnection();

            try
            {
                if (idEsp == "")
                {
                    db.setearConsulta("SELECT E.ID_MEDICO, CONCAT_WS(', ',M.Nombre, M.Apellido) as Medico, E.ID_ESPECIALIDAD, Es.nombre as Especialidad, E.Turno_Horario FROM EspecialidadxMedico as E inner join Medico as M on E.ID_MEDICO = M.ID_MEDICO  inner join Especialidades as Es on E.ID_ESPECIALIDAD = Es.ID_ESP");
                }
                else
                {
                    db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD FROM EspecialidadxMedico where ID_ESPECIALIDAD = " + idEsp);
                }

                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    EspecialidadxMedico aux = new EspecialidadxMedico();
                    aux.ID_MEDICO = db.Lector.GetInt32(0);
                    aux.Name = db.Lector.GetString(1);
                    aux.Id_Especialidad = db.Lector.GetInt32(2);
                    aux.Especialidad = db.Lector.GetString(3);
                    aux.Turno_Horario = db.Lector.GetInt32(4);

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
                

            }
            finally
            {
                db.cerrarConexion();
            }

        }


    }
}
