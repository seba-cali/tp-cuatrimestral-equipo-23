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
        public List<EspecialidadxMedico> listar()
        {
            List<EspecialidadxMedico> especialidadesxmedico = new List<EspecialidadxMedico>();
            DBConnection db = new DBConnection();

            try
            {

                db.setearConsulta("SELECT ID_MEDICO,ID_ESPECIALIDAD FROM EspecialidadxMedico");
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

        public void eliminar(int idmedico, int idespecialidad)
        {
            try
            {
                DBConnection datos = new DBConnection();
                datos.setearConsulta("DELETE FROM ESPECIALIDADES where ID_MEDICO = @idmedico, ID_ESPECIALIDAD = @idespecialidad");
                datos.setearParametro("@idmedico", idmedico);
                datos.setearParametro("@idespecialidad", idespecialidad);
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
