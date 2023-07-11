using Dominio;
using System.Collections.Generic;
using System;
using ConexionDB;
namespace Negocio
{
    public class NegocioMedico
    {
        public List<Medico> listar(string idMedico="")
        {
            List<Medico> medico = new List<Medico>();
            DBConnection db = new DBConnection();

            try
            {
                if(idMedico==""){
                    db.setearConsulta("SELECT ID_MEDICO, NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO, TELEFONO, ID_USUARIO, DNI,MATRICULA  FROM MEDICO");
                }
                else
                {
                    db.setearConsulta("SELECT ID_MEDICO, NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO, TELEFONO, ID_USUARIO, DNI,MATRICULA  FROM MEDICO where ID_MEDICO = " + idMedico);
                }
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.ID_MEDICO = db.Lector.GetInt32(0);
                    aux.nombres = db.Lector.GetString(1);
                    aux.apellidos = db.Lector.GetString(2);
                    aux.direccion = db.Lector.GetString(3);
                    aux.fechaNacimiento = db.Lector.GetDateTime(4);
                    aux.sexo = db.Lector.GetString(5);
                    aux.ESTADO = db.Lector.GetBoolean(6);
                    aux.telefono = db.Lector.GetString(7);
                    aux.ID_USUARIO = db.Lector.GetInt32(8);
                    aux.DNI = db.Lector.GetString(9);
                    aux.Matricula = db.Lector.GetString(10);


                    medico.Add(aux);
                }
                db.cerrarConexion();
                return medico;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }


		public void eliminarMedico(int id)
		{
			try
			{
				DBConnection datos = new DBConnection();
				datos.setearParametro("@id", id);
				datos.setearConsulta("UPDATE MEDICO SET ESTADO=0 where ID_MEDICO=@id");
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		public void reactivarMedico(int id)
		{
			try
			{
				DBConnection datos = new DBConnection();
				datos.setearParametro("@id", id);
				datos.setearConsulta("UPDATE MEDICO SET ESTADO=1 where ID_MEDICO=@id");
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public int RegistrarMedico(Medico nuevo, int id)
        {
            DBConnection db = new DBConnection();
            try
            {
                Console.WriteLine(id);
                if (id > 0)
                {
                    db.setearProcedimiento("ActualizaMedico");
                    db.setearParametro("@Id_Medico", id);
                    db.setearParametro("@nombre", nuevo.nombres);
                    db.setearParametro("@apellido", nuevo.apellidos);
                    db.setearParametro("@direccion", nuevo.direccion);
                    db.setearParametro("@fecha_nacimiento", nuevo.fechaNacimiento);
                    db.setearParametro("@sexo", nuevo.sexo);
                    db.setearParametro("@estado", nuevo.ESTADO);
                    db.setearParametro("@telefono", nuevo.telefono);
                    db.setearParametro("@id_Usuario", nuevo.ID_USUARIO);
                    db.setearParametro("@DNI", nuevo.DNI);
                    db.setearParametro("@turno", nuevo.turno);
                    db.setearParametro("@matricula", nuevo.Matricula);
                }
                else
                {
                    db.setearProcedimiento("RegistrarMedico");
                    db.setearParametro("@nombre", nuevo.nombres);
                    db.setearParametro("@apellido", nuevo.apellidos);
                    db.setearParametro("@direccion", nuevo.direccion);
                    db.setearParametro("@fecha_nacimiento", nuevo.fechaNacimiento);
                    db.setearParametro("@sexo", nuevo.sexo);
                    db.setearParametro("@estado", nuevo.ESTADO);
                    db.setearParametro("@telefono", nuevo.telefono);
                    db.setearParametro("@id_Usuario", nuevo.ID_USUARIO);
                    db.setearParametro("@DNI", nuevo.DNI);
                    db.setearParametro("@turno", nuevo.turno);
                    db.setearParametro("@matricula", nuevo.Matricula);
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