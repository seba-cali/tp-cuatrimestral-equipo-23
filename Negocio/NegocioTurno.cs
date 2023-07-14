using System;
using System.Collections.Generic;
using ConexionDB;
using Dominio;

namespace Negocio
{
    public class NegocioTurno
    {
        public List<Turnos> listar(int idturno = 0)
        {
            List<Turnos> turnero = new List<Turnos>();
            DBConnection db = new DBConnection();

            try
            {
                if (idturno>0)
                {
                    db.setearConsulta(
                        "SELECT ID_TURNO, FECHA, ESTADO, ID_MEDICO, ID_PACIENTE,ID_HORA, ID_ESPECIALIDAD, observacion, ESTADOINFORME,OBSERVACIONMEDICO,NUMGENERADO  FROM TURNO WHERE ID_Paciente = @id_turno" );
                    db.setearParametro("@id_turno", idturno);
                    
                }
                else
                {
                    db.setearConsulta("SELECT ID_TURNO, FECHA, ESTADO, ID_MEDICO, ID_PACIENTE,ID_HORA, ID_ESPECIALIDAD, observacion, ESTADOINFORME,OBSERVACIONMEDICO,NUMGENERADO  FROM TURNO");
                }

                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    Turnos aux = new Turnos();
                    aux.Id_Turno = db.Lector.GetInt32(0);
                    aux.fecha = db.Lector.GetDateTime(1);
                    aux.Estado = db.Lector.GetBoolean(2);
                    aux.Id_Medico = db.Lector.GetInt32(3);
                    aux.Id_Paciente = db.Lector.GetInt32(4);
                    aux.Id_Hora = db.Lector.GetInt32(5);
                    aux.Id_Especialidad = db.Lector.GetInt32(6);
                    aux.observacion = db.Lector.GetString(7);
                    aux.EstadoInf = db.Lector.GetInt32(8);
                    aux.observacionMed = db.Lector.GetString(9);
                    aux.NumGenerado = db.Lector.GetInt32(10);
                    turnero.Add(aux);
                }

                db.cerrarConexion();
                return turnero==null?null:turnero;
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

        public void UpdateTurno(int idturno, int index)
        {
            DBConnection db = new DBConnection();
            try
            {
                db.setearConsulta(
                    "UPDATE Turno SET  ESTADO=@estado, EstadoInforme=@estadoinf  WHERE ID_TURNO =@id_turno");
                db.setearParametro("@id_turno", idturno);
                db.setearParametro("@estado", false);
                db.setearParametro("@estadoinf", index);
                
                db.ejecutarLectura();
                
            }catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
        public void UpdateTurnoMed(Turnos turno)
        {
            DBConnection db = new DBConnection();
            try
            {
                db.setearConsulta(
                    "UPDATE Turno SET EstadoInforme=@estadoinforme, ObservacionMedico=@obs  WHERE ID_TURNO =@id_turno");
                db.setearParametro("@id_turno",turno.Id_Turno);
                db.setearParametro("@estadoinforme", turno.EstadoInf);
                db.setearParametro("@obs", turno.observacionMed);
                
                db.ejecutarLectura();
                
            }catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
        public Turnos turnRepro(int idturno)
        {
            
            DBConnection db = new DBConnection();

            try
            {
                db.setearConsulta(
                        "SELECT ID_TURNO, FECHA, ESTADO, ID_MEDICO, ID_PACIENTE,ID_HORA, ID_ESPECIALIDAD, observacion FROM TURNO WHERE ID_TURNO =@id_turno");
                db.setearParametro("@id_turno", idturno);
                db.ejecutarLectura();
                Turnos aux = new Turnos();
                if (db.Lector.Read())
                {
                
                    aux.Id_Turno = db.Lector.GetInt32(0);
                    aux.fecha = db.Lector.GetDateTime(1);
                    aux.Estado = db.Lector.GetBoolean(2);
                    aux.Id_Medico = db.Lector.GetInt32(3);
                    aux.Id_Paciente = db.Lector.GetInt32(4);
                    aux.Id_Hora = db.Lector.GetInt32(5);
                    aux.Id_Especialidad = db.Lector.GetInt32(6);
                    aux.observacion = db.Lector.GetString(7);

                }

                db.cerrarConexion();
                return aux??null;
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

        public void RegistrarTurno(Turnos nuevo, int id = 0)
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
                    db.setearParametro("@EstadoInforme", nuevo.EstadoInf);
                    db.setearParametro("@ObservacionMedico", "");
                    db.setearParametro("@NumGenerado", nuevo.NumGenerado);
                }

                db.ejecutarLectura();
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