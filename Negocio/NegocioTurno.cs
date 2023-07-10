using System;
using System.Collections.Generic;
using ConexionDB;
using Dominio;

namespace Negocio
{
    public class NegocioTurno
    {
        public List<Turnos> listar(string fecha = "", int idMedico= 0)
        		{
        			List<Turnos> turnero = new List<Turnos>();
        			DBConnection db = new DBConnection();
        
        			try
        			{
        
        				
        				if(fecha != "")
                        {
	                        db.setearConsulta(
		                        "SELECT ID_TURNO, FECHA, ESTADO, ID_MEDICO, ID_PACIENTE,ID_HORA, ID_ESPECIALIDAD  FROM TURNO WHERE FECHA = " +
		                        fecha + " and ESTADO = "+ idMedico);
                        }
        				else
        				{
        					db.setearConsulta("SELECT ID_TURNO, FECHA, ESTADO, ID_MEDICO, ID_PACIENTE,ID_HORA, ID_ESPECIALIDAD  FROM TURNO");
        				}
        				db.ejecutarLectura();
        
        				while (db.Lector.Read())
        				{
        					Turnos aux = new Turnos();
        					aux.Id_Turno = db.Lector.GetInt32(0);
                            aux.fecha= db.Lector.GetDateTime(1);
                            aux.Estado = db.Lector.GetBoolean(2);
                            aux.Id_Medico = db.Lector.GetInt32(3);
                            aux.Id_Paciente = db.Lector.GetInt32(4);
                            aux.Id_Hora = db.Lector.GetInt32(5);
                            aux.Id_Especialidad = db.Lector.GetInt32(6);
                            turnero.Add(aux);
        				}
        				db.cerrarConexion();
        				return turnero;
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
        public int RegistrarTurno(Turnos nuevo, int id=0)
        {
            DBConnection db = new DBConnection();
            try
            {
                Console.WriteLine(id);
                if (id > 0)
                {
                    db.setearProcedimiento("ActualizarTurno");
                    db.setearParametro("@Id_turno", id);
                    db.setearParametro("@Fecha", nuevo.fecha);
                    db.setearParametro("@Estado", nuevo.Estado);
                    db.setearParametro("@Id_Medico", nuevo.Id_Medico);
                    db.setearParametro("@Id_Paciente", nuevo.Id_Paciente);
                    db.setearParametro("@Id_Hora", nuevo.Id_Hora);
                    db.setearParametro("@Id_Especialidad", nuevo.Id_Especialidad);
                    db.setearParametro("@observacion", nuevo.observacion);
                }
                else
                {
                    db.setearProcedimiento("RegistrarTurno");
                    db.setearParametro("@Fecha", nuevo.fecha);
                    db.setearParametro("@Estado", nuevo.Estado);
                    db.setearParametro("@Id_Medico", nuevo.Id_Medico);
                    db.setearParametro("@Id_Paciente", nuevo.Id_Paciente);
                    db.setearParametro("@Id_Hora", nuevo.Id_Hora);
                    db.setearParametro("@Id_Especialidad", nuevo.Id_Especialidad);
                    db.setearParametro("@observacion", nuevo.observacion);
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