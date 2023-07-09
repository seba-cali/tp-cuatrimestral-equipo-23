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
    }
}