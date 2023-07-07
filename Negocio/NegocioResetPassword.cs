using System;
using ConexionDB;
using Dominio;

namespace Negocio
{
    public class NegocioResetPassword
    {
        public Usuario BuscarXCorreo(string val)
        {
            DBConnection db = new DBConnection();
            Usuario aux = new Usuario();
            
            try
            {
                db.setearConsulta("SELECT ID_USUARIO, DNI, CORREO FROM USUARIO WHERE CORREO= @CORREO");
                db.setearParametro("@correo", val);
                db.ejecutarLectura();
                if (db.Lector.Read())
                {

                    aux.ID_USUARIO = db.Lector.GetInt32(0);
                    aux.DNI = db.Lector.GetString(1);
                    aux.CORREO = db.Lector.GetString(2);
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
        public int generateCode(Dominio.ResetPassword val)
        {
            DBConnection db = new DBConnection();
            
            try
            {
                db.setearProcedimiento("RegistrarRecupero");
                db.setearParametro("@id_Usuario", val.id_Usuario);
                db.setearParametro("@codigo", val.codigo);
                db.setearParametro("@fecha", val.fecha);
                db.setearParametro("@estado", val.estado);
                
                return db.ejecutarLecturaInt();
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
            
        }
        public int updateCode(Dominio.ResetPassword val)
        {
            DBConnection db = new DBConnection();
            Usuario aux = new Usuario();
            try
            {
                db.setearProcedimiento("ActualizarRecupero");
                db.setearParametro("@id_Usuario", val.id_Usuario);
                db.setearParametro("@codigo", val.codigo);
                db.setearParametro("@fecha", val.fecha);
                db.setearParametro("@estado", val.estado);
                
                return db.ejecutarLecturaInt();
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
            return 0;
        }
        
        public int BuscarXCode(string val)
        {
            DBConnection db = new DBConnection();
            ResetPassword aux = new ResetPassword();
            
            try
            {
                db.setearConsulta("SELECT ID_ResetPassword, ID_USUARIO, CODIGO, ESTADO FROM ResetPassword WHERE codigo= @codigo");
                db.setearParametro("@codigo", val);
                db.ejecutarLectura();
                if (db.Lector.Read())
                {

                    aux.id_ResetPassword = db.Lector.GetInt32(0);
                    aux.id_Usuario = db.Lector.GetInt32(1);
                    aux.codigo = db.Lector.GetString(2);
                    aux.estado = db.Lector.GetBoolean(3);
                    db.cerrarConexion();    
                }

                if (val == aux.codigo && aux.estado == true)
                {
                    DBConnection dbx = new DBConnection();
                    dbx.setearProcedimiento("UpdateRecupero");
                    dbx.setearParametro("@codigo", val);
                    dbx.setearParametro("@Estado", false);
                    dbx.ejecutarLectura();
                    dbx.cerrarConexion();
                }
                else
                {
                    return -1;
                    
                }
                
                return aux.codigo == val ? aux.id_Usuario : 0;
                
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
            
        }
    }
    
}