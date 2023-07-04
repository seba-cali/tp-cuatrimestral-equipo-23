using System;
using System.Collections.Generic;
using ConexionDB;
using Dominio;

namespace Negocio
{
    public class NegocioUsuario
    {

	    public Usuario login(Usuario usuario)
	    {
		    DBConnection db = new DBConnection();
		    Usuario aux = new Usuario();
		    try
		    {
			    
			   
        
			    db.setearConsulta("SELECT ID_USUARIO, DNI, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO FROM USUARIO WHERE DNI= @DNI AND PASSWORD = @password");
			    db.setearParametro("@DNI", usuario.DNI);
			    db.setearParametro("@password", usuario.PASSWORD);
			    db.ejecutarLectura();


			    if (db.Lector.Read())
			    {
				    
				    usuario.ID_USUARIO = db.Lector.GetInt32(0);
				    usuario.DNI = db.Lector.GetString(1);
				    usuario.PASSWORD = db.Lector.GetString(2);
				    usuario.CORREO = db.Lector.GetString(3);
				    usuario.ESTADO = db.Lector.GetBoolean(4);
				    usuario.ID_USUARIO = db.Lector.GetInt32(5);
				    db.cerrarConexion();
				    return usuario; 
			    }
			    else
			    {
				    db.cerrarConexion();
				    return null; 
				    
			    }
			    
			 
				  
			    
			    
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
        public List<Usuario> listar()
        		{
        			List<Usuario> especialidades = new List<Usuario>();
        			DBConnection db = new DBConnection();
        
        			try
        			{
        
        				db.setearConsulta("SELECT ID_USUARIO, DNI, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO FROM USUARIO");
        				db.ejecutarLectura();
        
        				while (db.Lector.Read())
        				{
        					Usuario aux = new Usuario();
                            aux.ID_USUARIO = db.Lector.GetInt32(0);
                            aux.DNI = db.Lector.GetString(1);
                            aux.PASSWORD = db.Lector.GetString(2);
        
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
        				datos.setearConsulta("DELETE FROM USUARIO where ID_USUARIO = @id");
        				datos.setearParametro("@id", id);
        				datos.ejecutarAccion();
        			}
        			catch (Exception ex)
        			{
        
        				throw ex;
        			}
        
        		}

	    public Usuario BuscarXId(int val)
	    {
		    DBConnection db = new DBConnection();
		    Usuario aux = new Usuario();
		    try
		    {
			    db.setearConsulta("SELECT ID_USUARIO, DNI, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO FROM USUARIO WHERE ID_USUARIO= @id");
			    db.setearParametro("@id", val);
			    db.ejecutarLectura();
			    if (db.Lector.Read())
			    {

				    aux.ID_USUARIO = db.Lector.GetInt32(0);
				    aux.DNI = db.Lector.GetString(1);
				    aux.PASSWORD = db.Lector.GetString(2);
				    aux.CORREO = db.Lector.GetString(3);
				    aux.ESTADO = db.Lector.GetBoolean(4);
				    aux.ID_USUARIO = db.Lector.GetInt32(5);
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
	    public int RegistrarUsuario(Usuario nuevo, int id = 0)
                {
	                DBConnection db = new DBConnection();
	                try
	                {
		                if(id > 0)
		                {
								db.setearProcedimiento("ActualizarUsuario");
				                db.setearParametro("@id", id);
				                db.setearParametro("@dni", nuevo.DNI);
				                db.setearParametro("@correo", nuevo.CORREO);
				                db.setearParametro("@password", nuevo.PASSWORD);
				                db.setearParametro("@estado", 1);
				                db.setearParametro("@tipoUsuario", 4);
				                
			                
		                }else{
		                
			                db.setearProcedimiento("RegistrarUsuario");
			                db.setearParametro("@dni", nuevo.DNI);
			                db.setearParametro("@correo", nuevo.CORREO);
			                db.setearParametro("@password", nuevo.PASSWORD);
			                db.setearParametro("@estado", 1);
			                db.setearParametro("@tipoUsuario", 4);
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